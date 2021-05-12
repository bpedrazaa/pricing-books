using System.Collections.Generic;

using UPB.PricingBooks.Data.Models;

namespace UPB.PricingBooks.Data
{
    public interface IDbContext
    {
        Product AddProduct(Product group);
        Product UpdateProduct(Product groupToUpdate);
        Product DeleteProduct(Product group);
        List<Product> GetAllProduct();
        ListP AddList(ListP list);
        ListP UpdateList(ListP listUpdate);
        ListP DeleteList(ListP list);
        List<ListP> GetAllList();
    }
}
