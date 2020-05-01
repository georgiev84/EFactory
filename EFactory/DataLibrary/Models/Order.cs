using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductQuantity { get; set; }
        public float TotalPrice { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
