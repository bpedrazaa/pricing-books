using UPB.PricingBooks.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UPB.PricingBooks.Services
{
    public interface ICampaignService
    {
        Task<Campaign> GetCampaign();
        Task<List<Campaign>> GetAllCampaign();
    }
}
