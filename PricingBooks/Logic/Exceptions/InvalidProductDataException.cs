using System;

namespace UPB.PricingBooks.Logic.Exceptions
{
    class InvalidProductDataException : Exception 
    {
        public InvalidProductDataException(string mesagge) : base("Logic Layer: " + mesagge) { }
    }
}
