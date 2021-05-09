using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using UPB.PricingBooks.Data;
using UPB.PricingBooks.Logic.Exceptions;
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
            if(product.ProductId.Trim() == "")
            {
                Log.Error("Invalid Data, Can't create product:");
                throw new InvalidProductDataException("The Product data is not a valid type of data");
            }

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
            else
            {
                Log.Error("Campaign code not finded");
                throw new InvalidCampaignDataException("The type of campaign is unvalid to work with");
            }

            _dbContext.AddProduct(DTOMappers.MapProductLD(product));
            return product;
        }

        public Product UpdateProduct(Product product)
        {
            if (product.ProductId.Trim() == "")
            {
                Log.Error("Invalid Data, Can't update product");
                throw new InvalidProductDataException("The Product data is not a valid type of data");
            }

            Data.Models.Product productUpdated = _dbContext.UpdateProduct(DTOMappers.MapProductLD(product));
            return DTOMappers.MapProductDL(productUpdated);
        }

        public Product DeleteProduct(Product product)
        {
            if (product.ProductId.Trim() == "")
            {
                Log.Error("Invalid Data, Can't delete product");
                throw new InvalidProductDataException("The Product data is not a valid type of data");
            }

            _dbContext.DeleteProduct(DTOMappers.MapProductLD(product));
            return product;
        }
    }
}
