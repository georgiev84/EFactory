using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string CompanyNumber { get; set; }

        public string ContactPerson { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
