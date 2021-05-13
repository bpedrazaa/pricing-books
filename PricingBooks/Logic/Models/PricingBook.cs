using System.Collections.Generic;

namespace UPB.PricingBooks.Logic.Models
{
    public class PricingBook
    {

        public int? Id { get; set; }

        public string Description { get; set; }

        public string Name{ get; set; }  
        
        public List<Product> Content { get; set; }
    }
}
