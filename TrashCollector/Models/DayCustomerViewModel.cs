using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class DayCustomerViewModel
    {
        public Customer Customer { get; set; }
        public SelectList Day { get; set; }
        public Address Address { get; set; }
    }
}
