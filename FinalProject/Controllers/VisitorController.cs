using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CheckIn.Controllers
{
    public class VisitorController : Controller
    {
        public IActionResult CheckIn()
        {
            return View();
        }

        public IActionResult CheckInForm()
        {
            return View();
        }


		public IActionResult Register()
        {
            return View();
        }

        public IActionResult RegisterForm()
        {
            return View();
        }

        public IActionResult RegisterOk()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

		public IActionResult Buy()
        {
            return View();
        }
	}
}