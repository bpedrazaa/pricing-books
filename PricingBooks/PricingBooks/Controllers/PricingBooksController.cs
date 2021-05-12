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
    [Route("api/pricing-books")]
    public class PricingBooksController : ControllerBase
    {
        private readonly IPricingBooksManager _pricingBookManager;
        public PricingBooksController(IPricingBooksManager pricingBooksManager)
        {
            _pricingBookManager = pricingBooksManager;
        }

        //CRUD
        [HttpGet]
        //[Route("{pricingBookId}")]
        public List<PricingBook> GetPricingBooks()
        {
            return _pricingBookManager.GetPricingBooks();
        }

        [HttpPost]
        [Route("{pricingBookId}")]
        public PricingBook CreatePricingBook([FromBody] PricingBook PricingBook)
        {
            return _pricingBookManager.CreatePricingBook(PricingBook);
        }

        [HttpPut]
        [Route("{pricingBookId}")]
        public PricingBook UpdatePricingBook([FromBody] PricingBook PricingBook)
        {
            return _pricingBookManager.UpdatePricingBook(PricingBook);
        }

        [HttpDelete]
        [Route("{pricingBookId}")]
        public PricingBook DeletePricingBook([FromBody] PricingBook PricingBook)
        {
            return _pricingBookManager.DeletePricingBook(PricingBook);
        }
    }
}