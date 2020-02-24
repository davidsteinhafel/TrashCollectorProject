using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.SingleOrDefault(x => x.IdentityUserId == userId);
            var customerZip = _context.Customers.Include(x => x.Address).Where(y => y.Address.ZipCode == employee.ZipCode);
            if (employee == null)
            {
                return RedirectToAction("Create");
            }
            return View(customerZip);
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
            var employees = _context.Employees.Include(x => x.IdentityUser).ToList();
            var employeeInDb = _context.Employees.Single(x => x.IdentityUserId == userId);
            employeeInDb.FirstName = employee.FirstName;
            employeeInDb.LastName = employee.LastName;
            employeeInDb.ZipCode = employee.ZipCode;
            userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _context.SaveChanges();
            return RedirectToAction("Index");
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