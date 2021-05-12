using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Logic.Exceptions
{
    public class InvalidPricingBookDataException : Exception
    {
        public InvalidPricingBookDataException(string mesagge) : base("Logic Layer: " + mesagge) { }
    }
}
