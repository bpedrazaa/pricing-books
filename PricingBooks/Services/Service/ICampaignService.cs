using System.Threading.Tasks;
using System.Collections.Generic;

using UPB.PricingBooks.Services.Models;

namespace UPB.PricingBooks.Services.Service
{
    public interface ICampaignService
    {
        Task<Campaign> GetCampaign();
        Task<List<Campaign>> GetAllCampaign();
    }
}