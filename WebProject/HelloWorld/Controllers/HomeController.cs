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
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            else
            {
                return View(guestResponse);
            }
        }

        // Product Action

        public IActionResult Product()
        {
            //var myProduct = new Product
            //{
            //    ProductId = 1,
            //    Name = "Kayak",
            //    Description = "A boat for one person",
            //    Category = "water-sports",
            //    Price = 200m,
            //};

            return View(productRepository.Products.First());
        }


        // Products Action - Collection
        public IActionResult Products()
        {
            //var products = new Product[]
            //{
            //   new Product{ ProductId = 1, Name = "First One", Price = 1.11m, ProductCount=0},
            //   new Product{ ProductId = 2, Name="Second One", Price = 2.22m, ProductCount=1},
            //   new Product{ ProductId = 3, Name="Third One", Price = 3.33m, ProductCount=10},
            //   new Product{ ProductId = 4, Name="Fourth One", Price = 4.44m, ProductCount=100},
            //};

            return View(productRepository.Products);
        }


        //====DI===========

        private IProductRepository productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }



    }
}
