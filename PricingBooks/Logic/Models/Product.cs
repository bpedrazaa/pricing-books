using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Logic.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public double FixedPrice { get; set; }
        public double PromotionPrice { get; set; }
    }
}
