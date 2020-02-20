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
            var employees = _context.Employees.Include(x => x.IdentityUser).ToList();
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            var employee = _context.Employees.Include(x => x.IdentityUser).SingleOrDefault(x => x.Id == id);
            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (employee.Id == 0)
            {
                _context.Employees.Add(employee);
            }
            else
            {
                var employeeInDb = _context.Employees.Single(x => x.Id == employee.Id);
                employeeInDb.FirstName = employee.FirstName;
                employeeInDb.LastName = employee.LastName;
                employeeInDb.ZipCode = employee.ZipCode;
                employeeInDb.PickUpComplete = employee.PickUpComplete;
                employeeInDb.Charge = employee.Charge;
                var userId = employeeInDb.IdentityUserId;
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);
            return View(employee);
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