using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Data.Exceptions
{
    public class NotFindedProductException:Exception
    {
        public NotFindedProductException(string ss) : base(ss) { }
    }
}
