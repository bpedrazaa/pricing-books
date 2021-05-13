using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using UPB.PricingBooks.Logic.Managers;
using UPB.PricingBooks.Logic.Models;

namespace UPB.PricingBooks.Presentation.Controllers
{
    [ApiController]
    [Route("api/pricing-books")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsManager _productsManager;
        public ProductsController(IProductsManager productsManager)
        {
            _productsManager = productsManager;
        }

        //CRUD
        //GET
        [HttpGet]
        [Route("{pricingBookId}/products")]
        public List<Product> GetProducts([FromRoute] int pricingBookId)
        {
            return _productsManager.GetProducts(pricingBookId);
        }

        //PUT
        [HttpPost]
        [Route("{pricingBookId}/products")]
        public Product CreateProduct([FromBody] Product product, [FromRoute] int pricingBookId)
        {
            return _productsManager.CreateProduct(product, pricingBookId);
        }

        //UPDATE
        [HttpPut]
        [Route("{pricingBookId}/products/{productId}")]
        public Product UpdateProduct([FromBody] Product product, [FromRoute] int pricingBookId)
        {
            return _productsManager.UpdateProduct(product, pricingBookId);
        }

        //DELETE
        [HttpDelete]
        [Route("{pricingBookId}/products/{productId}")]
        public Product DeleteProduct([FromBody] Product product, [FromRoute] int pricingBookId)
        {
            return _productsManager.DeleteProduct(product, pricingBookId);
        }
    }
}
