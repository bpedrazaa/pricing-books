using System.Collections.Generic;
using System.Threading.Tasks;

using UPB.PricingBooks.Services.Models;


namespace UPB.PricingBooks.Services
{
    public interface ICampaignService
    {
        Task<Campaign> GetCampaign();
        Task<List<Campaign>> GetAllCampaign();
    }
}
