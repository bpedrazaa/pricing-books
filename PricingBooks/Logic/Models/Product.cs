using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Logic.Models
{
    public class Product
    {
        public string ProductId { get; set; }
        public int FixedPrice { get; set; }
        public int PromotionPrice { get; set; }
    }
}
