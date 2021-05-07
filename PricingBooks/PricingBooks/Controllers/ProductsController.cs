using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UPB.PricingBooks.Logic.Managers;
using UPB.PricingBooks.Logic.Models;

namespace UPB.PricingBooks.Presentation.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsManager _productsManager;
        public ProductsController(IProductsManager productsManager)
        {
            _productsManager = productsManager;
        }

        //CRUD
        [HttpGet]
        public List<Product> GetProducts()
        {
            return _productsManager.GetProducts();
        }

        [HttpPost]
        public Product CreateProduct([FromBody] Product product)
        {
            return _productsManager.CreateProduct(product);
        }

        [HttpPut]
        public Product UpdateProduct([FromBody] Product product)
        {
            return _productsManager.UpdateProduct(product);
        }

        [HttpDelete]
        public Product DeleteProduct([FromBody] Product product)
        {
            return _productsManager.DeleteProduct(product);
        }
    }
}
