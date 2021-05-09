//using Microsoft.Extensions.Configuration;
using UPB.PricingBooks.Services.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UPB.PricingBooks.Services
{
    public class CampaignService : ICampaignService
    {
        //public readonly HttpClient _campaignHttp;
        //private readonly IConfiguration _configuration;

        /*public CampaignService(HttpClient campaign, IConfiguration configuration)
        {
            _configuration = configuration;
            campaign.BaseAddress = new Uri(_configuration["Microservices:CampaignUrl"]);
            _campaignHttp = campaign;
        }*/

        public CampaignService(/*HttpClient campaign*/)
        {
            //This Uri got to be from the other service (Campaign), not our service.
            //campaign.BaseAddress = new Uri("http://localhost:5001");
            //_campaignHttp = campaign;
        }

        public async Task<Campaign> GetCampaign()
        {
            //var response = await _campaignHttp.GetAsync("/campaign");
            //string responseBody = await response.Content.ReadAsStringAsync();
            string responseMock = "{\"name\":\"Black Friday Campaign 2021\",\"code\":\"BFRIDAY\",\"description\":\"All products have a discount\"}";
            Campaign campaign = Newtonsoft.Json.JsonConvert.DeserializeObject<Campaign>(responseMock);
            return campaign;
        }

        public async Task<List<Campaign>> GetAllCampaign()
        {
            //var response = await _campaignHttp.GetAsync("/campaign");
            //string responseBody = await response.Content.ReadAsStringAsync();
            string responseMock = "[{\"name\":\"Black Friday Campaign 2021\",\"code\":\"BFRIDAY\",\"description\":\"All products have a discount\"}]";
            List<Campaign> campaigns = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Campaign>>(responseMock);
            return campaigns;
        }
    }
}
