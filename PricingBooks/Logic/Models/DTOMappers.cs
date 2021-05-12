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

        public static List<Data.Models.Product> MapProductsLD(List<Product> products)
        {
            if (products == null)
            {
                Log.Error("Object is empty");
                throw new InvalidProductDataException("Can't work with null objects");
            }

            List<Data.Models.Product> mappedProducts = new List<Data.Models.Product>();
            foreach (Product product in products)
            {
                mappedProducts.Add(new Data.Models.Product()
                {
                    PricingBookId = product.PricingBookId,
                    IdProducto = product.ProductId,
                    precio= product.FixedPrice ,
                    precioF = product.PromotionPrice
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

        //Mapers for pricing books

        public static List<PricingBook> MapPricingBooksDL(List<Data.Models.ListP> pricingBooks)
        {
            if (pricingBooks == null)
            {
                Log.Error("Object is empty");
                throw new InvalidProductDataException("Can't work with null objects");
            }

            List<PricingBook> mappedPricingBooks = new List<PricingBook>();
            foreach (Data.Models.ListP PB in pricingBooks)
            {
                mappedPricingBooks.Add(new PricingBook()
                {
                    Id= PB.Id,
                    Name= PB.Name,
                    Description= PB.Description,
                    Content = DTOMappers.MapProductsDL(PB.Content)
                });
            }
            return mappedPricingBooks;
        }

        public static Data.Models.ListP MapPricingBookLD(PricingBook PB)
        {
            if (PB == null)
            {
                Log.Error("Object is empty");
                throw new InvalidProductDataException("Can't work with null objects");
            }

            Data.Models.ListP mappedPricingBook = new Data.Models.ListP();
            mappedPricingBook.Id= PB.Id;
            mappedPricingBook.Name = PB.Name;
            mappedPricingBook.Description = PB.Description;
            mappedPricingBook.Content = DTOMappers.MapProductsLD(PB.Content);

            return mappedPricingBook;
        }

        public static PricingBook MapPricingBookDL(Data.Models.ListP PB)
        {
            if (PB == null)
            {
                Log.Error("Object is empty");
                throw new InvalidProductDataException("Can't work with null objects");
            }

            PricingBook mappedPricingBook = new PricingBook();
            mappedPricingBook.Id = PB.Id;
            mappedPricingBook.Name= PB.Name;
            mappedPricingBook.Description = PB.Description;
            mappedPricingBook.Content = DTOMappers.MapProductsDL(PB.Content);

            return mappedPricingBook;
        }

    }
}
