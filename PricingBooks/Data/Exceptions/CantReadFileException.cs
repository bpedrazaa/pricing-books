using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Data.Exceptions
{
    public class CantReadFileException : Exception
    {
        public CantReadFileException(string ss) : base(ss)
        {

        }
    }
}
