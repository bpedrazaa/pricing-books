using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Data.Exceptions
{
    public class InvalidProductDataException:Exception
    {
        public InvalidProductDataException(string ss) : base(ss) { }
    }
}
