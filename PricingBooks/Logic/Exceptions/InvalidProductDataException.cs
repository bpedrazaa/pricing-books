using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Logic.Exceptions
{
    class InvalidProductDataException : Exception 
    {
        public InvalidProductDataException(string mesagge) : base("Logic Layer: " + mesagge) { }
    }
}
