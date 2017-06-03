using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pset3.Models;

namespace Pset3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
			return View();
        }

		[HttpPost]
        public IActionResult Submition(Product toUse)
        {
            ViewData["Message"] = "Your contact page.";
            return View(toUse);
        }

		public IActionResult List()
        {
            ViewData["Message"] = "TODO List.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
