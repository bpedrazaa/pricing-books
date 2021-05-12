using System.Collections.Generic;

using UPB.PricingBooks.Logic.Models;

namespace UPB.PricingBooks.Logic.Managers
{
    public interface IProductsManager
    {
        public List<Product> GetProducts(int pricingBookId);

        public Product CreateProduct(Product product, int pricingBookId);

        public Product UpdateProduct(Product product, int pricingBookId);

        public Product DeleteProduct(Product product, int pricingBookId);
    }
}
