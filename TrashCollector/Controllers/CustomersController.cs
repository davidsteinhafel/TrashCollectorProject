using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Include(x => x.IdentityUser).Where(x => x.IdentityUserId == userId).FirstOrDefault();
            if(customer == null)
            {
                return RedirectToAction("Create");
            }
            return View(customer);
        }
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x => x.IdentityUser).SingleOrDefault(x => x.Id == id);

            return View(customer);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var dayViewModel = new DayCustomerViewModel();
            var days = _context.Days.Select(x => x.Name);
            dayViewModel.Day = new SelectList(days);
            
            return View(dayViewModel);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (customer.Id == 0)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Customers.Add(customer);

            }
            else
            {
                var customerInDb = _context.Customers.Single(x => x.Id == customer.Id);
                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.RoutinePickUp = customer.RoutinePickUp;
                customerInDb.OnePickUp = customer.OnePickUp;
                customerInDb.Owed = customer.Owed;
                customerInDb.Start = customer.Start;
                customerInDb.End = customer.End;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            var dayViewModel = new DayCustomerViewModel();
            var days = _context.Days.Select(x => x.Name);
            dayViewModel.Day = new SelectList(days);
            return View(dayViewModel);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            var customerInDb = _context.Customers.Single(x => x.Id == customer.Id);
            customerInDb.FirstName = customer.FirstName;
            customerInDb.LastName = customer.LastName;
            customerInDb.RoutinePickUp = customer.RoutinePickUp;
            customerInDb.OnePickUp = customer.OnePickUp;
            customerInDb.Owed = customer.Owed;
            customerInDb.Start = customer.Start;
            customerInDb.End = customer.End;
            customerInDb.IdentityUserId = customer.IdentityUserId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            var customers = _context.Customers.Include(x => x.IdentityUser).ToList();
            return View("Index");
        }
        //[HttpGet]
        //public IActionResult SetPickUp(int id)
        //{
        //    var customer = _context.Customers.Single(x => x.Id == id);
        //    return View(customer);
        //}
        //[HttpPost]
        //public IActionResult SetPickUp(Customer customer)
        //{
        //    var customerInDb = _context.Customers.Single(x => x.Id == customer.Id);
        //    customerInDb.OnePickUp = customer.OnePickUp;

        //    if (customer.OnePickUp == null)
        //    {
        //        return View(customer);
        //    }
        //    else
        //    {

        //    }
        //}
    }
}