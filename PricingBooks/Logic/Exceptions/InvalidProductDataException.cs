using System;

namespace UPB.PricingBooks.Logic.Exceptions
{
    public class InvalidProductDataException : Exception 
    {
        public InvalidProductDataException(string mesagge) : base("Logic Layer: " + mesagge) { }
    }
}
