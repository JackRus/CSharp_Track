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

		public IActionResult Register()
        {
            return View();
        }

		public IActionResult Buy()
        {
            return View();
        }
	}
}