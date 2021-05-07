using System;
using System.Collections.Generic;
using System.Text;
using UPB.PricingBooks.Logic.Models;

namespace UPB.PricingBooks.Logic.Managers
{
    public interface IProductsManager
    {
        public List<Product> GetProducts();

        public Product CreateProduct(Product product);

        public Product UpdateProduct(Product product);

        public Product DeleteProduct(Product product);
    }
}
