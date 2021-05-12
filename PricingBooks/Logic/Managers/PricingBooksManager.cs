﻿using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using UPB.PricingBooks.Data;
using UPB.PricingBooks.Logic.Exceptions;
using UPB.PricingBooks.Logic.Models;
using UPB.PricingBooks.Services;

namespace UPB.PricingBooks.Logic.Managers
{
    public class PricingBooksManager : IPricingBooksManager
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
            return DTOMappers.MapPricingBooksDL(_dbContext.GetAlLList());
        }

        public PricingBook CreatePricingBook(PricingBook book)
        {
            _dbContext.AddList(DTOMappers.MapPricingBookLD(book));
            return book;
        }

        public PricingBook UpdatePricingBook(PricingBook book)
        {
            Data.Models.ListP bookUpdated = new Data.Models.ListP();
            bookUpdated = _dbContext.UpdateList(DTOMappers.MapPricingBookLD(book));
            return DTOMappers.MapPricingBookDL(bookUpdated);
            
        }

        public PricingBook DeletePricingBook(PricingBook book)
        {
            _dbContext.DeleteList(DTOMappers.MapPricingBookLD(book));
            return book;
        }
    }
}
