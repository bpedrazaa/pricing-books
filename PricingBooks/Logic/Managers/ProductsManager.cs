using System;
using System.Collections.Generic;
using System.Text;
using UPB.PricingBooks.Data;
using UPB.PricingBooks.Logic.Models;

namespace UPB.PricingBooks.Logic.Managers
{
    public class ProductsManager
    {
        private readonly IDbContext _dbContext;

        public ProductsManager(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetProducts()
        {
            return DTOMappers.MapProductsDL(_dbContext.GetAllProduct());
        }

        public Product CreateProduct(Product product)
        {
            _dbContext.AddProduct(DTOMappers.MapProductLD(product));
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            Data.Models.Product productUpdated = _dbContext.UpdateProduct(DTOMappers.MapProductLD(product));
            return DTOMappers.MapProductDL(productUpdated);
        }

        public Product DeleteProduct(Product product)
        {
            _dbContext.DeleteProduct(DTOMappers.MapProductLD(product));
            return product;
        }
    }
}
