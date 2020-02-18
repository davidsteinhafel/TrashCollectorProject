
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Pick Up Day")]
        public DateTime RoutinePickUp { get; set; }

        [Display(Name = "One time Pick Up")]
        public DateTime OnePickUp { get; set; }

        [Display(Name = "Money Owed")]
        public int Owed { get; set; }

        [Display(Name = "Start Date")]
        public DateTime Start { get; set; }

        [Display(Name = "End Date")]
        public DateTime End { get; set; }

        [ForeignKey("IdentityUser")]
        [Display(Name = "User Id")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
