using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Data.Models
{
    public class Product
    {
        public int PricingBookId { get; set; }
        public string IdProducto { get; set; }
        public double precio { get; set; }
        public double precioF { get; set; }
    }
}
