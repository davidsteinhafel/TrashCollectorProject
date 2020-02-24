using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "ZipCode")]
        public int ZipCode { get; set; }
        [Display(Name = "Street")]
        public string StreetName { get; set; }
    }
}
