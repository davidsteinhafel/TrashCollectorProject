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
            if (customer == null)
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
        public IActionResult Create(Customer customer, Address address)
        {
            if (customer.Id == 0)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Addresses.Add(address);
                _context.Customers.Add(customer);
                customer.Id = customer.Address.Id;
                
                

            }
            else
            {
                var customerInDb = _context.Customers.Single(x => x.Id == customer.Id);
                var addressInDb = _context.Customers.Single(x => x.AddressId == address.Id);
                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.RoutinePickUp = customer.RoutinePickUp;
                customerInDb.OnePickUp = customer.OnePickUp;
                customerInDb.Owed = customer.Owed;
                customerInDb.Start = customer.Start;
                customerInDb.End = customer.End;
                addressInDb.Address.State = address.State;
                addressInDb.Address.City = address.City;
                addressInDb.Address.ZipCode = address.ZipCode;
                addressInDb.Address.StreetName = address.StreetName;
                

            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public IActionResult AddressSet()
        //{
        //    var AddressOnDb = new Address();
        //    var address = _context.Customers.Where(x => x.Id == x.AddressId);
        //    return View(AddressOnDb);
        //}
        //[HttpPost]
        //public IActionResult AddressPost(Address address, Customer customer)
        //{
        //    var addressOnDb = _context.Customers.SingleOrDefault(x => x.AddressId == address.Id);
        //    addressOnDb.Address.State = customer.Address.State;
        //    addressOnDb.Address.City = customer.Address.City;
        //    addressOnDb.Address.ZipCode = customer.Address.ZipCode;
        //    addressOnDb.Address.StreetName = customer.Address.StreetName;
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");

        //}
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
        [HttpGet]
        public IActionResult Suspension(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            var suspensionViewModel = new SuspensionViewModel();
            return View(suspensionViewModel);
        }
        [HttpPost]
        public IActionResult Suspension(SuspensionViewModel suspension)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var customer = _context.Customers.SingleOrDefault(x => x.IdentityUserId == userId);

                customer.Start = suspension.StartDay;
                customer.End = suspension.EndDay;
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(suspension);
            }
        }
    }
}