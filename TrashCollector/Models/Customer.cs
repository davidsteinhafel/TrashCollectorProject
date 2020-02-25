
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
        [Required]
        [Display(Name = "Pick Up Day")]
        public string RoutinePickUp { get; set; }
        
        [Display(Name = "One Time Pick Up")]
        public DateTime OnePickUp { get; set; }

        [Display(Name = "Money Owed")]
        public int Owed { get; set; }

        [Display(Name = "Start Date")]
        public DateTime Start { get; set; }

        [Display(Name = "End Date")]
        public DateTime End { get; set; }
        [Display(Name = "Charged")]
        public bool Charged { get; set; }

        [ForeignKey("Address")]
        [Display(Name = "AddressId")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("IdentityUser")]
        [Display(Name = "User Id")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
