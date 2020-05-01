using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

 
        public float Weight { get; set; }


        public float Price { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
