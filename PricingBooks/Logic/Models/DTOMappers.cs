using System;
using System.Collections.Generic;
using System.Text;

namespace UPB.PricingBooks.Logic.Models
{
    public static class DTOMappers
    {
        // Map a list of products from Data to Logic layer format (DL) 
        public static List<Product> MapProductsDL(List<Data.Models.Product> products)
        {
            List<Product> mappedProducts = new List<Product>();
            foreach (Data.Models.Product product in products)
            {
                mappedProducts.Add(new Product()
                {
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
            Data.Models.Product mappedProduct = new Data.Models.Product();
            mappedProduct.IdProducto = product.ProductId;
            mappedProduct.precio = product.FixedPrice;
            mappedProduct.precioF = product.PromotionPrice;

            return mappedProduct;
        }

        // Map a object product from Data to Logic layer format (DL) 
        public static Product MapProductDL(Data.Models.Product group)
        {
            Product mappedGroup = new Product();
            mappedGroup.ProductId = group.IdProducto;
            mappedGroup.FixedPrice = group.precio;
            mappedGroup.PromotionPrice = group.precioF;

            return mappedGroup;
        }
    }
}
}
