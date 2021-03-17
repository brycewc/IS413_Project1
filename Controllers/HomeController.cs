using IS413_Project1.Models;
using IS413_Project1.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Project1.Controllers
{
    public class HomeController : Controller
    {
        private TourDbContext context { get; set; }

        private ITourRepo _repository;

        //Constructor
        public HomeController(TourDbContext con, ITourRepo repository)
        {
            context = con;
            _repository = repository;
        }


        public static List<DateTime> Times = new List<DateTime>();
        
        // Bubble sort to generate times dates for tour times. The first loop generates week days, the inner loops generates hours
        public List<DateTime> CreateTimes()
        {
            
            for (int iOuter = 15; iOuter < 27; iOuter++)
            {
                for (int iInner = 8; iInner < 21; iInner++)
                {
                    Times.Add(new DateTime(
                                year: 2021,
                                month: 3,
                                day: iOuter,
                                hour: iInner,
                                minute: 00,
                                second: 00
                                )
                    );
                }
            }
            return Times;
        }

        public static string GroupTime;
        // Returns the Index view on startup
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            List<DateTime> returnTimes = Times;
            if (Times.Count == 0)
            {
                returnTimes = CreateTimes();
            }
            return View(returnTimes);
        }
        // Post action that allows users to select the time for their appointment and then sends them to the form where they will enter their group information.
        [HttpPost]
        public IActionResult SignUp(IFormCollection form)
        {
                GroupTime = form["time"];
                Times.Remove(Convert.ToDateTime(GroupTime));
                return View("Form", new TourListViewModel { TourGroup = new TourGroup(), Time = form["time"] });
        }
        // Post action from the form of adding a group to a tour time. Passes in the tour time and adds, then saves the group information attached to that tour time.
        [HttpPost]
        public IActionResult Form(TourListViewModel t)
        {
            if (ModelState.IsValid)
            {
                t.TourGroup.TourTime = GroupTime;
                context.Group.Add(t.TourGroup);
                context.SaveChanges();
                return View("ViewApps", context.Group);
            }
            else
            {
                return View();
            }
        }
        // View Appointments action. Passes the group information from the context model file.
        [HttpGet]
        public IActionResult ViewApps()
        {
            return View(context.Group);
        }
    }
}
