using System;
using System.Collections.Generic;
using System.Text;
using UPB.PricingBooks.Logic.Models;

namespace UPB.PricingBooks.Logic.Managers
{
    public interface IPricingBooksManager
    {
        public List<PricingBook> GetPricingBooks();

        public PricingBook CreatePricingBook(PricingBook book);

        public PricingBook UpdatePricingBook(PricingBook book);

        public PricingBook DeletePricingBook(PricingBook book);
    }
}
