using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Logic.Exceptions
{
    class InvalidCampaignDataException : Exception
    {
        public InvalidCampaignDataException(string mesagge) : base(mesagge) { }
    }
}
