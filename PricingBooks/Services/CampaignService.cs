using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Serilog;

using UPB.PricingBooks.Services.Models;
using UPB.PricingBooks.Services.Exceptions;


namespace UPB.PricingBooks.Services
{
    public class CampaignService : ICampaignService
    {
        // Uncomment for wire-up
        //public readonly HttpClient _campaignHttp;
        //private readonly IConfiguration _configuration;

        /*public CampaignService(HttpClient campaign,IConfiguration configuration)
        {
            _configuration = configuration;
            campaign.BaseAddress = new Uri(_configuration["Microservices:CampaignUrl"]);
            _campaignHttp = campaign;
        }*/



        public async Task<Campaign> GetCampaign()
        {
            try
            {
               //var response = await _campaignHttp.GetAsync("/campaign");
                //string responseBody = await response.Content.ReadAsStringAsync();
                string responseMock = "{\"name\":\"Black Friday Campaign 2021\",\"code\":\"BFRIDAY\",\"description\":\"All products have a discount\"}";
                Campaign campaign = Newtonsoft.Json.JsonConvert.DeserializeObject<Campaign>(responseMock);
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
                //var response = await _campaignHttp.GetAsync("/campaign");
                //string responseBody = await response.Content.ReadAsStringAsync();
                string responseMock = "[{\"name\":\"Black Friday Campaign 2021\",\"code\":\"BFRIDAY\",\"description\":\"All products have a discount\"}]";
                List<Campaign> campaigns = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Campaign>>(responseMock);
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
