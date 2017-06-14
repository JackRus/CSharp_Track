using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalEvent.Data;
using GlobalEvent.Models.VisitorViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GlobalEvent.Controllers
{
     public class VisitorController : Controller
    {
        private VisitorDbContext _newContext;
        
        public VisitorController(VisitorDbContext visitorContext)
        {
            _newContext = visitorContext;
        }
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

        [HttpGet]
        public IActionResult RegisterForm()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult RegisterForm(Order myOrder)
        {
            var orderList = _newContext.Orders.ToList();
            foreach (Order n in orderList)
            {
                if (n.Number == myOrder.Number)
                {
                    ViewData["myOrder"] = myOrder.Number;
                    return View();
                }
            }
            ViewData["OrderMessage"] = "This ORDER number isn't correct. Please try again";
            return View("Register");
        }


        public IActionResult RegisterOk(Visitor regVisitor)
        {
            string rand = new Random().Next(1000000000,499999999).ToString();
            regVisitor.RegistrationNumber = rand;
            regVisitor.Registered = true;

            //  update Order checked-in number
            Order result = (from o in _newContext.Orders
                where o.Number.ToString() == regVisitor.OrderNumber
                select o).SingleOrDefault();
            result.CheckedIn++;
            _newContext.SaveChanges();

            // saves new order info to DB
            _newContext.Visitors.Add(regVisitor);
            _newContext.SaveChanges();
            
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

        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(Order newOrder)
        {
            if (newOrder.CheckedIn >= newOrder.Amount)
                newOrder.Full = true;

            // saves new order info to DB
            _newContext.Orders.Add(newOrder);
            _newContext.SaveChanges();

            // sends it to view to display confirmation for user
            return View("SubmissionOk");
        }
	}
}