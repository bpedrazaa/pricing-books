using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Data.Exceptions
{
    public class DBException : Exception
    {
        public DBException(string ss) : base(ss)
        {

        }
    }
}
