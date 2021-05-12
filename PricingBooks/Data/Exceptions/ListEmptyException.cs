using System;

namespace UPB.PricingBooks.Data.Exceptions
{
    public class ListEmptyException : Exception
    {
        public ListEmptyException(string ss) : base(ss) { }
    }
}
