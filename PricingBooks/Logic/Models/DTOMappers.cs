using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using UPB.PricingBooks.Logic.Exceptions;

namespace UPB.PricingBooks.Logic.Models
{
    public static class DTOMappers
    {
        // Map a list of products from Data to Logic layer format (DL) 
        public static List<Product> MapProductsDL(List<Data.Models.Product> products)
        {
            if(products == null)
            {
                Log.Error("Object is empty");
                throw new InvalidProductDataException("Can't work with null objects");
            }

            List<Product> mappedProducts = new List<Product>();
            foreach (Data.Models.Product product in products)
            {
                mappedProducts.Add(new Product()
                {
                    PricingBookId = product.PricingBookId,
                    ProductId = product.IdProducto,
                    FixedPrice = product.precio,
                    PromotionPrice = product.precioF
                });
            }
            return mappedProducts;
        }

        // Map a object product from Logic to Data layer format (LD) 
        public static Data.Models.Product MapProductLD(Product product)
        {
            if (product == null)
            {
                Log.Error("Object is empty");
                throw new InvalidProductDataException("Can't work with null objects");
            }

            Data.Models.Product mappedProduct = new Data.Models.Product();
            mappedProduct.PricingBookId = product.PricingBookId;
            mappedProduct.IdProducto = product.ProductId;
            mappedProduct.precio = product.FixedPrice;
            mappedProduct.precioF = product.PromotionPrice;

            return mappedProduct;
        }

        // Map a object product from Data to Logic layer format (DL) 
        public static Product MapProductDL(Data.Models.Product product)
        {
            if (product == null)
            {
                Log.Error("Object is empty");
                throw new InvalidProductDataException("Can't work with null objects");
            }

            Product mappedProduct = new Product();
            mappedProduct.PricingBookId = product.PricingBookId;
            mappedProduct.ProductId = product.IdProducto;
            mappedProduct.FixedPrice = product.precio;
            mappedProduct.PromotionPrice = product.precioF;

            return mappedProduct;
        }
    }
}
