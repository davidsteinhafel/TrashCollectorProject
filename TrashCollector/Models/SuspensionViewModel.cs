using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class SuspensionViewModel
    {
        
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDay { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDay { get; set; }
    }
}
