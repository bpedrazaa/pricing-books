using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using UPB.PricingBooks.Data.Models;
using Newtonsoft.Json;
using UPB.PricingBooks.Data.Exceptions;
using Serilog;

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
                using (StreamReader sr = new StreamReader("D:/Stuff/UPB/Certificacion I/Tercer_Parcial/Final_Project/PricingBooks/Data/Models/DataBase.json"))
                {
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((jsonM = sr.ReadLine()) != null)
                    {
                        json += jsonM;
                    }
                    //List<producto> items = JsonConvert.DeserializeObject<List<producto>>(json);
                    ProductTable = JsonConvert.DeserializeObject<List<Product>>(json);

                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                Log.Error("This was the Error" + e.StackTrace + e.Message);
                throw new DBException(" Can't Read the json file");
                
            }
        }

        public Product AddProduct(Product product)
        {
            if (product.IdProducto == "")
            {
                Log.Error("Invalid Data, Can't add this product");
                throw new InvalidProductDataException("the product don't have all data");
                

            }
            ProductTable.Add(product);
            return product;
        }

        public Product UpdateProduct(Product productToUpdate)
        {
            if (productToUpdate.IdProducto == "")
            {
                Log.Error("Invalid Data, the product don't have all data");
                throw new InvalidProductDataException("the product don't have all data");

            }
            Product productL = new Product();
            try
            {
                productL = ProductTable.Find(product => product.IdProducto == productToUpdate.IdProducto);
                productL = productToUpdate;
            }
            catch
            {
                Log.Error("did't find the product to update");
                throw new InvalidProductDataException(" did't find the product to update");
            }
            return productL;
        }
        public Product DeleteProduct(Product product)
        {
            if (product.IdProducto == "")
            {
                Log.Error("Invalid Data, the product don't have all data");
                throw new InvalidProductDataException("the product don't have all data");
            }

            try
            {
                ProductTable.Remove(product);
            }
            catch
            {
                Log.Error("did't  find the product to remove ");
                throw new InvalidProductDataException(" did't  find the product to remove ");   
            }
            return product;
        }
        public List<Product> GetAllProduct()
        {
            if(ProductTable.Count == 0)
            {
                throw new ListEmptyException("The list is empty");
            }
            return ProductTable;
        }
    }
}
