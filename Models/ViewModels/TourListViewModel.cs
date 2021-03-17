using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Project1.Models.ViewModels
{
    // View model to associate a TourGroup with a time for that group.
    public class TourListViewModel
    {
        //public IEnumerable<TourGroup> IGroup { get; set; }
        public string Time { get; set; }
        public TourGroup TourGroup { get; set; }
    }
}
