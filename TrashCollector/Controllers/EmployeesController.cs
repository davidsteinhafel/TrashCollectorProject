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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var today = DateTime.Now;
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.SingleOrDefault(x => x.IdentityUserId == userId);
            var customerZip = _context.Customers.Include(x => x.Address).Where(y => y.Address.ZipCode == employee.ZipCode);
            var customers = _context.Customers.Where(x => x.Address.ZipCode == employee.ZipCode && x.Charged == true && (x.Start >= today && x.End <= today));
            if (employee == null)
            {
                return RedirectToAction("Create");
            }
            return View(customers);
        }
        public IActionResult Details(int id)
        {
            var employee = _context.Employees.Include(x => x.IdentityUser).SingleOrDefault(x => x.Id == id);
            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var employee = new Employee();
            return View(employee);
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            employee.IdentityUserId = userId;
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employees = _context.Employees.SingleOrDefault(x => x.IdentityUserId == userId);
            var employeeInDb = _context.Employees.Single(x => x.IdentityUserId == userId);
            employeeInDb.FirstName = employee.FirstName;
            employeeInDb.LastName = employee.LastName;
            employeeInDb.ZipCode = employee.ZipCode;
            userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ConfirmPickUp(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.SingleOrDefault(x => x.IdentityUserId == userId);
            var dayViewModel = new DayCustomerViewModel();
            dayViewModel.Customer = customer;
            dayViewModel.Employee = employee;
            return View(new DayCustomerViewModel { Customer = dayViewModel.Customer, Employee = dayViewModel.Employee });
        }
        [HttpPost]
        public IActionResult ConfirmPickup(DayCustomerViewModel dayCustomerViewModel)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == dayCustomerViewModel.Customer.Id);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.SingleOrDefault(x => x.IdentityUserId == userId);
            dayCustomerViewModel.Customer = customer;
            dayCustomerViewModel.Employee = employee;

            DateTime currentTime = DateTime.Now;
            customer.Owed += 5;
            customer.Charged = true;
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult FilterDay(DayCustomerViewModel dayCustomerViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.SingleOrDefault(x => x.IdentityUserId == userId);
            var customerDay = _context.Customers.Where(x => x.RoutinePickUp == dayCustomerViewModel.filterDay);
            return View("Index", customerDay);
        }
     
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            var employees = _context.Employees.Include(x => x.IdentityUser).ToList();
            return View("Index");
        }
    }
}