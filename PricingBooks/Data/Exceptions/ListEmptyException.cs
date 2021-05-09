using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Data.Exceptions
{
    public class ListEmptyException : Exception
    {
        public ListEmptyException(string ss) : base(ss) { }
    }
}
