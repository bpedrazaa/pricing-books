using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Logic.Models
{
    public class Product
    {
        public int PricingBookId { get; set; }
        public string ProductId { get; set; }
        public double FixedPrice { get; set; }
        public double PromotionPrice { get; set; }
    }
}
