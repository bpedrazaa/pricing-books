using System.Threading.Tasks;

using UPB.PricingBooks.Services.Models;

namespace UPB.PricingBooks.Services.Service
{
    public interface ICampaignService
    {
        Task<Campaign> GetCampaign();
    }
}