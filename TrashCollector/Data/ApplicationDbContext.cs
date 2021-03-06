﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollector.Models;

namespace TrashCollector.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Address> Addresses { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData
            (
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
             );
            builder.Entity<Day>()
                .HasData(
                new Day
                {
                    Id = 1,
                    Name = "Sunday"
                },
                new Day
                {
                    Id = 2,
                    Name = "Monday"
                },
                new Day
                {
                    Id = 3,
                    Name = "Tuesday"
                },
                new Day
                {
                    Id = 4,
                    Name = "Wednesday"
                },
                new Day
                {
                    Id = 5,
                    Name = "Thursday"
                },
                new Day
                {
                    Id = 6,
                    Name = "Friday"
                },
                new Day
                {
                    Id = 7,
                    Name = "Saturday"
                });


        }
    }
}
