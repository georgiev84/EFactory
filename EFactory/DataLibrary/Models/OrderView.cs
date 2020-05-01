using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class OrderView
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }

        public int ProductQuantity { get; set; }
        public float TotalPrice { get; set; }


    }
}
