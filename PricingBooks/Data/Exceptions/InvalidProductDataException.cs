using System;

namespace UPB.PricingBooks.Data.Exceptions
{
    public class InvalidProductDataException:Exception
    {
        public InvalidProductDataException(string ss) : base(ss) { }
    }
}
