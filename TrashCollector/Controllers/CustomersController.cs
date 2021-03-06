﻿using System;
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
        public IActionResult Create(DayCustomerViewModel dayCustomerViewModel)
        {
            if (dayCustomerViewModel.Customer.Id == 0)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                dayCustomerViewModel.Customer.IdentityUserId = userId;
                _context.Addresses.Add(dayCustomerViewModel.Customer.Address);
                _context.SaveChanges();
                dayCustomerViewModel.Customer.AddressId = dayCustomerViewModel.Customer.Address.Id;
                _context.Customers.Add(dayCustomerViewModel.Customer);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult OneTimePickUp(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            var dayViewModel = new DayCustomerViewModel();
            var days = _context.Days.Select(x => x.Name);
            dayViewModel.Day = new SelectList(days);
            return View(dayViewModel);
        }
        [HttpPost]
        public IActionResult OneTimePickUp(DayCustomerViewModel dayCustomerViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            dayCustomerViewModel.Customer.IdentityUserId = userId;
            var customerInDb = _context.Customers.Single(x => x.IdentityUserId == userId);
            customerInDb.OnePickUp = dayCustomerViewModel.Customer.OnePickUp;
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
        public IActionResult Edit(DayCustomerViewModel dayCustomerViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            dayCustomerViewModel.Customer.IdentityUserId = userId;
            var customerInDb = _context.Customers.Single(x => x.IdentityUserId == userId);
            customerInDb.FirstName = dayCustomerViewModel.Customer.FirstName;
            customerInDb.LastName = dayCustomerViewModel.Customer.LastName;
            customerInDb.RoutinePickUp = dayCustomerViewModel.Customer.RoutinePickUp;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
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