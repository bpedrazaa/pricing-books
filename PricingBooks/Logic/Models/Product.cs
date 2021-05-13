
namespace UPB.PricingBooks.Logic.Models
{
    public class Product
    {
        public int? PricingBookId { get; set; }
        public string ProductId { get; set; }
        public double? FixedPrice { get; set; }
        public double? PromotionPrice { get; set; }
    }
}
