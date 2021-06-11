using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HelloWorld.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Phone] // Exercise 1 - ASP Validation
        [Required(ErrorMessage = "Please enter your phone")]
        public string Phone { get; set; }

        // Exercise 1 - Models - Add the Email
        [EmailAddress] // Exercise 1 - ASP Validation
        [Required(ErrorMessage = "Please enter your email")]
        public string Email { get; set; }

        // Exercise 1 - ASP Validation
        [Required(ErrorMessage = "Please enter your will attend status")]
        public bool? WillAttend { get; set; }
    }
}
