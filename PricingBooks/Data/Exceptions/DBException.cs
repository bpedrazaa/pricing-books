﻿using System;

namespace UPB.PricingBooks.Data.Exceptions
{
    public class DBException : Exception
    {
        public DBException(string ss) : base(ss)
        {

        }
    }
}
