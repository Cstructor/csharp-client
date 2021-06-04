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

        public string Phone { get; set; }
        
        // Exercise 1 - Models
        public string Email { get; set; }
        
        public bool? WillAttend { get; set; }
    }
}
