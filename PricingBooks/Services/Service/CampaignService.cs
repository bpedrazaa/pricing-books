using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

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
            campaign.BaseAddress = new Uri(_configuration["Microservices:CampaignUrl"]);
            _campaignHttp = campaign;
        }

        public async Task<Campaign> GetCampaign()
        {
            var response = await _campaignHttp.GetAsync("/campaign");
            string responseBody = await response.Content.ReadAsStringAsync();
            //string responseMock = "{\"name\":\"Black Friday Campaign 2021\",\"code\":\"BFRIDAY\",\"description\":\"All products have a discount\"}";
            Campaign campaign = Newtonsoft.Json.JsonConvert.DeserializeObject<Campaign>(responseBody);
            return campaign;
        }

    }
}