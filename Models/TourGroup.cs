using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IS413_Project1.Models
{
    // Tour Group Model. Gives a group necessary information in order to save them to the DB.
    public class TourGroup
    {
        [Key]
        public int TourGroupId { get; set; }
        [Required(ErrorMessage = "Tour Name is required")]
        public string TourName { get; set; }
        [Required(ErrorMessage = "Tour Size is required")]
        public int TourSize { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Please enter a valid phone number XXX-XXX-XXXX")]
        public string PhoneNumber { get; set; }
        public string TourTime { get; set; }
    }
}
