﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UPB.PricingBooks.Data.Models;
using Newtonsoft.Json;
using UPB.PricingBooks.Data.Exceptions;

namespace UPB.PricingBooks.Data
{
    public class DbContext: IDbContext
    {
        public List<Product> ProductTable { get; set; }

        public DbContext()
        {
            _initDb();
        }

        private void  _initDb()
        {
            string json = "";
            try
            {
                string jsonM; 
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                //----- i am not sure that is the correct path
                using (StreamReader sr = new StreamReader("C:/Universidad/5 semestre/Certificacion/ProjectPB/PricingBooks/Data/Models/Example1.json"))
                {
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((jsonM = sr.ReadLine()) != null) {
                        json += jsonM;
                    }
                    //List<producto> items = JsonConvert.DeserializeObject<List<producto>>(json);
                    ProductTable = JsonConvert.DeserializeObject<List<Product>>(json);

                    Console.WriteLine("Tamano");;
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                throw new CantReadFileException(" Can't Read the json file");
            }
        }

        public Product AddProduct(Product product)
        {

            ProductTable.Add(product);
            return product;
        }

        public Product UpdateProduct(Product productToUpdate)
        {
            Product productL = new Product();
            try
            {
                productL = ProductTable.Find(product => product.IdProducto == productToUpdate.IdProducto);
                productL = productToUpdate;
            }
            catch
            {
                throw new NotFindedProductException(" did't not find the product ");
            }
            return productL;
        }
        public Product DeleteProduct(Product product)
        {
            try
            {
                ProductTable.Remove(product);

            }
            catch
            {
                throw new NotFindedProductException(" did't not find the product ");

            }
            return product;
        }
        public List<Product> GetAllProduct()
        {
            if(ProductTable.Count > 1)
            {
                throw new ListEmptyException("The list is empty");
            }
            return ProductTable;
        }
    }
}
