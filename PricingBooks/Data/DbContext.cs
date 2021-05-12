using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using UPB.PricingBooks.Data.Models;
using Newtonsoft.Json;
using UPB.PricingBooks.Data.Exceptions;
using Serilog;
using UPB.PricingBooks.Logic.Models;

namespace UPB.PricingBooks.Data
{
    public class DbContext: IDbContext
    {
        public List<Product> ProductTable { get; set; }
        public List<ListP> ListProduct { get; set; }

        public DbContext()
        {
            _initDbProduct();
            _initDbList();
        }

        // initialize database and extract the products 
        private void  _initDbProduct()
        {
            string json = "";
            try
            {
                string jsonM;
                // Create an instance of StreamReader to read from a file.

                using (StreamReader sr = new StreamReader("../Data/Models/DataBaseProduct.json"))

                {
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((jsonM = sr.ReadLine()) != null)
                    {
                        json += jsonM;
                    }
                    // Get the list of products
                    ProductTable = JsonConvert.DeserializeObject<List<Product>>(json);

                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                Log.Error("This was the Error" + e.StackTrace + e.Message);
                throw new DBException("Can't Read the json file");
                
            }
        }

        // initialize database and extract the List 
        private void _initDbList()
        {
            string json = "";
            try
            {
                string jsonM;
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                //----- i am not sure that is the correct path()
                using (StreamReader sr = new StreamReader("../Data/Models/DataBaseList.json"))
                {
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((jsonM = sr.ReadLine()) != null)
                    {
                        json += jsonM;
                    }
                    //List<producto> items = JsonConvert.DeserializeObject<List<producto>>(json);
                    ListProduct = JsonConvert.DeserializeObject<List<ListP>>(json);

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
        // 
        public Product AddProduct(Product product)
        {
            // Verification if the id from the product to add is empty
            if (product.IdProducto == "")
            {
                Log.Error("Invalid Data, Can't add this product");
                throw new InvalidProductDataException("The product don't have all data");
            }
            // Verification if the product already exists in the database
            // Notice that a product with the same productId can exists with another PricingBookId
            if (ProductTable.Find(p => p.IdProducto == product.IdProducto) != null || ProductTable.Find(p => p.PricingBookId == product.PricingBookId) != null) {
                Log.Error("The product is already in the database, Can't add this product");
                throw new DBException("The product is in the database already");
            }
            ProductTable.Add(product);
            return product;
        }
        public Product UpdateProduct(Product productToUpdate)
        {
            // Verification if the id from the product to update is empty
            if (productToUpdate.IdProducto == "")
            {
                Log.Error("Invalid Data, the product don't have all data");
                throw new InvalidProductDataException("The product don't have all data");
            }
            Product productL = new Product();
            try
            {
                // Find if the product to update exists in the database
                productL = ProductTable.Find(product => product.IdProducto == productToUpdate.IdProducto);
                productL = productToUpdate;
            }
            catch
            {
                Log.Error("Did't find the product to update");
                throw new InvalidProductDataException("Did't find the product to update");
            }
            return productL;
        }
        public Product DeleteProduct(Product product)
        {
            if (product.IdProducto == "")
            {
                Log.Error("Invalid Data, the product don't have all data");
                throw new InvalidProductDataException("The product don't have all data");
            }

            try
            {
                ProductTable.Remove(product);
            }
            catch
            {
                Log.Error("Did't  find the product to remove ");
                throw new InvalidProductDataException("Did't  find the product to remove ");   
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

        public ListP AddList(ListP list)
        {
            if (list.Id == 0)
            {
                Log.Error("Invalid Data, Can't add this product");
                throw new InvalidProductDataException("the product don't have all data");


            }
            ListProduct.Add(list);
            return list;
        }
        public ListP UpdateList(ListP listUpdate)
        {
            if (listUpdate.Id == 0)
            {
                Log.Error("Invalid Data, the product don't have all data");
                throw new InvalidProductDataException("the product don't have all data");

            }
            ListP listL= new ListP();
            try
            {
                listL = ListProduct.Find(list => list.Id == listUpdate.Id);
                listL = listUpdate;
            }
            catch
            {
                Log.Error("did't find the product to update");
                throw new InvalidProductDataException(" did't find the product to update");
            }
            return listL;
        }
        public ListP DeleteList(ListP list)
        {
            if (list.Id == 0)
            {
                Log.Error("Invalid Data, the product don't have all data");
                throw new InvalidProductDataException("the product don't have all data");
            }

            try
            {
                ListProduct.Remove(list);
            }
            catch
            {
                Log.Error("did't  find the product to remove ");
                throw new InvalidProductDataException(" did't  find the product to remove ");
            }
            return list;
        }
        public List<ListP> GetAlLList()
        {
            if (ListProduct.Count == 0)
            {
                throw new ListEmptyException("The list is empty");
            }
            return ListProduct;
        }
    }
}
