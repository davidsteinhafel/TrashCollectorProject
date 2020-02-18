using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name = "Pick Up Complete")]
        public bool PickUpComplete { get; set; }

        [Display(Name = "Pick Up Charge")]
        public int Charge { get; set; }

        [ForeignKey("IdentityUser")]
        [Display(Name = "User Id")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }

}
