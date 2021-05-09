using System;
using System.Collections.Generic;
using System.Text;
using UPB.PricingBooks.Data;
using UPB.PricingBooks.Logic.Models;
using UPB.PricingBooks.Services;

namespace UPB.PricingBooks.Logic.Managers
{
    public class ProductsManager : IProductsManager
    {
        private readonly IDbContext _dbContext;
        private readonly ICampaignService _campaignService;

        public ProductsManager(IDbContext dbContext, ICampaignService campaignService)
        {
            _dbContext = dbContext;
            _campaignService = campaignService;
        }

        public List<Product> GetProducts()
        {
            return DTOMappers.MapProductsDL(_dbContext.GetAllProduct());
        }

        public Product CreateProduct(Product product)
        {
            // Control for promotion price based on Campaign microservice
            string codeCampaign = _campaignService.GetCampaign().Result.Code;

            if (codeCampaign == "XMAS" || codeCampaign == "xmas") {
                product.PromotionPrice = product.FixedPrice * 0.05;
            }else if(codeCampaign == "SUMMER" || codeCampaign == "summer")
            {
                product.PromotionPrice = product.FixedPrice * 0.2;
            }
            else if(codeCampaign == "BFRIDAY" || codeCampaign == "bfriday")
            {
                product.PromotionPrice = product.FixedPrice * 0.25;
            }

            _dbContext.AddProduct(DTOMappers.MapProductLD(product));
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            Data.Models.Product productUpdated = _dbContext.UpdateProduct(DTOMappers.MapProductLD(product));
            return DTOMappers.MapProductDL(productUpdated);
        }

        public Product DeleteProduct(Product product)
        {
            _dbContext.DeleteProduct(DTOMappers.MapProductLD(product));
            return product;
        }
    }
}
