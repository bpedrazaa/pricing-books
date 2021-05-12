using System;
using System.Collections.Generic;
using System.Text;
using UPB.PricingBooks.Data.Models;

namespace UPB.PricingBooks.Data.Models
{
    public class ListP
    {

        public int Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public List<Product> Content { get; set; }
    }
}
