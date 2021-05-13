using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Serilog;

using UPB.PricingBooks.Services.Models;
using UPB.PricingBooks.Services.Exceptions;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace UPB.PricingBooks.Services
{
    public class CampaignService : ICampaignService
    {
        // Comment for use mock, uncomment for wire-up
        private readonly HttpClient _campaignHttp;
        private readonly IConfiguration _configuration;

        public CampaignService(IConfiguration configuration)
        {
            _configuration = configuration;
            _campaignHttp = new HttpClient();
            _campaignHttp.BaseAddress = new Uri(_configuration["Microservices:CampaignUrl"]);
        }



        public async Task<Campaign> GetCampaign()
        {
            try
            {
                var response = await _campaignHttp.GetAsync("/api/campaigns");
                string responseBody = await response.Content.ReadAsStringAsync();
                //string responseMock = "{\"name\":\"Black Friday Campaign 2021\",\"type\":\"BFRIDAY\",\"description\":\"All products have a discount\",\"enable\":\"true\"}";
                Campaign campaign = Newtonsoft.Json.JsonConvert.DeserializeObject<Campaign>(responseBody);
                return campaign;
            }
            catch (Exception ex)
            {
                Log.Error("This was the error: " + ex.StackTrace + ex.Message);
                throw new ServiceException("Can not connect to to the service");
            }
        }

        public async Task<List<Campaign>> GetAllCampaign()
        {
            try
            {
                var response = await _campaignHttp.GetAsync("/api/campaigns");
                string responseBody = await response.Content.ReadAsStringAsync();
                //string responseMock = "[{\"name\":\"Black Friday Campaign 2021\",\"type\":\"BFRIDAY\",\"description\":\"All products have a discount\",\"enable\":\"true\"}]";
                List<Campaign> campaigns = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Campaign>>(responseBody);
                return campaigns;

            }
            catch (Exception ex)
            {
                Log.Error("This was the error: " + ex.StackTrace + ex.Message);
                throw new ServiceException("Can not connect to to the service");
            }
        }
    }
}
