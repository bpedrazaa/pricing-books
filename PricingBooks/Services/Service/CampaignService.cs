using System.Net.Http;

using UPB.PricingBooks.Services.Models;

namespace UPB.PricingBooks.Services.Service
{
    public class CampaignService : ICampaignService
    {
        public readonly HttpClient _campaignHttp;
        private readonly IConfiguration _configuration;

        public CampaignService(HttpClient campaign, IConfiguration configuration)
        {
            _configuration = configuration;
            _campaignHttp = campaign;
        }

    }
}