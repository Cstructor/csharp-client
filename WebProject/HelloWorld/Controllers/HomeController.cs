using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View(new GuestResponse());
        }
        [HttpPost]
        public IActionResult RsvpForm(Models.GuestResponse guestResponse)
        {
            return View("Thanks", guestResponse);
        }

    }
}
