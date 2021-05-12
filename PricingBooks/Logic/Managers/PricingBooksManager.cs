using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using UPB.PricingBooks.Data;
using UPB.PricingBooks.Logic.Exceptions;
using UPB.PricingBooks.Logic.Models;
using UPB.PricingBooks.Services;

namespace UPB.PricingBooks.Logic.Managers
{
    class PricingBooksManager : IPricingBooksManager
    {
        private readonly IDbContext _dbContext;
        private readonly IProductsManager _productsManager;


        public PricingBooksManager(IDbContext dbContext, IProductsManager productsManager)
        {
            _dbContext = dbContext;
            _productsManager = productsManager;
        }
        public List<PricingBook> GetPricingBooks()
        {
            return null;
        }

        public PricingBook CreatePricingBook(PricingBook book)
        {

            return null;//Lo dejamos con el throw por que: todavia falta lo del Fabri
        }

        public PricingBook UpdatePricingBook(PricingBook book)
        {
            return null;
        }

        public PricingBook DeletePricingBook(PricingBook book)
        {
            return null;
        }
    }
}
