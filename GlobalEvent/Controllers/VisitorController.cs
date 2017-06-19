using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobalEvent.Data;
using GlobalEvent.Models.VisitorViewModels;
using GlobalEvent.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using GlobalEvent.Models.EBinfo;

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

        public IActionResult CheckInEdit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CheckInEditForm()
        {
            return View("CheckInEdit");
        }

        [HttpPost]
        public IActionResult CheckInEditForm(Visitor regNumber)
        {
            var visitorList = _newContext.Visitors.ToList();
            foreach (Visitor n in visitorList)
            {
                if (n.RegistrationNumber == regNumber.RegistrationNumber)
                {
                    if (n.CheckIned)
                    {
                        ViewData["CheckMessage"] = "This Registration number was already used for Check In and name tag was printed. If you still would like to change some information displayed on the name tag, please refer to the administrator.";
                        return View("CheckInEdit");
                    }
                    else return View(n);
                }
            }
            ViewData["CheckMessage"] = "This Registration number isn't correct. Please try again";
            return View("CheckIn");
        }

        [HttpPost]
        public IActionResult AfterEdit(Visitor edited)
        {
            Visitor visitor = (
                from v in _newContext.Visitors
                where v.RegistrationNumber == edited.RegistrationNumber
                select v
                ).SingleOrDefault();
            visitor.Name = edited.Name;
            visitor.Last = edited.Last;
            visitor.Occupation = edited.Occupation;
            visitor.Company = edited.Company;
            _newContext.SaveChanges();
            return View("CheckInForm", visitor);
        }


        [HttpGet]
        public IActionResult CheckInForm()
        {
            return View("CheckIn");
        }

        [HttpPost]
        public IActionResult CheckInForm(Visitor regNumber)
        {
            var visitorList = _newContext.Visitors.ToList();
            foreach (Visitor n in visitorList)
            {
                if (n.RegistrationNumber == regNumber.RegistrationNumber)
                {
                    if (n.CheckIned)
                    {
                        ViewData["CheckMessage"] = "This Registration number was alredy used for Check In. If you have any questions, please refer to one of the administrators.";
                        return View("CheckIn");
                    }
                    else return View(n);
                }
            }
            ViewData["CheckMessage"] = "This Registration number isn't correct. Please try again";
            return View("CheckIn");
        }

        [HttpGet]
        public IActionResult CheckInOk()
        {
            return View("CheckIn");
        }

        [HttpPost]
        public IActionResult CheckInOk(Visitor checkVisitor)
        {
            Visitor visitor = (
                from v in _newContext.Visitors
                where v.RegistrationNumber == checkVisitor.RegistrationNumber
                select v
                ).SingleOrDefault();
            visitor.CheckIned = true;
            _newContext.SaveChanges();
            return View(visitor);
        }

		public IActionResult Register()
        {
            // get request to Eventbrite
            var text = new Models.EBinfo.EBGet();
            // deserializing json to Atendee list.
            var visitors = JsonConvert.DeserializeObject<Attendees>(text.responseE);
            
            // finds the latest added order
            var lastOrder = _newContext.Orders.Last().Number;

            // remove all duplicates with the same order number
            var query = visitors.attendees
                .Where(s => Int32.Parse(s.order_id) > lastOrder)
                .GroupBy(x => x.order_id)
                .Select(y => new { Number = y.Key, Count = y.Count()})
                .OrderBy(o => o.Number).ToList();
            
            // add to the database
            foreach(var a in query)
            {
                var order = new Order();
                order.Number = Int32.Parse(a.Number);
                order.Amount = a.Count;
                _newContext.Orders.Add(order);
            }
            _newContext.SaveChanges();
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
                    if (n.Full)
                    {
                        ViewData["OrderMessage"] = "All visitors with this ORDER number were registered. Please use another ORDER number or purchase the additional ticket.";
                        return View("Register");
                    }
                    ViewData["myOrder"] = myOrder.Number;
                    return View();
                }
            }
            ViewData["OrderMessage"] = "This ORDER number isn't correct. Please try again";
            return View("Register");
        }

        [HttpGet]
        public IActionResult RegisterOk()
        {
            return View("Register");
        }
        
        [HttpPost]
        public IActionResult RegisterOk(Visitor regVisitor)
        {
            Visitor visitor = (
                from v in _newContext.Visitors
                where v.Name == regVisitor.Name && v.Last == regVisitor.Last && v.Email == regVisitor.Email
                select v
                ).SingleOrDefault();
            if (visitor != null && visitor.Registered)
                return View(visitor);
            
            // generates random REGISTRATION number
            string rand = new Random().Next(1000000000,2140999999).ToString();
            regVisitor.RegistrationNumber = rand;
            regVisitor.Registered = true;

            //  update Order checked-in number
            Order result = (from o in _newContext.Orders
                where o.Number.ToString() == regVisitor.OrderNumber
                select o).SingleOrDefault();
            result.CheckedIn++;
            if (result.CheckedIn >= result.Amount) 
                result.Full = true;

            // saves new visitor info to DB
            _newContext.Visitors.Add(regVisitor);
            _newContext.SaveChanges();
            ViewData["code"] = regVisitor.RegistrationNumber;
            return View(regVisitor);
        }
	}
}