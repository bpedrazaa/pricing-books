using System;
using System.Collections.Generic;
using System.Text;
using UPB.PricingBooks.Data.Models;

namespace UPB.PricingBooks.Data
{
    public interface IDbContext
    {
        Producto AddGroup(Producto group);
        Producto UpdateGroup(Producto groupToUpdate);
        Producto DeleteGroup(Producto group);
        List<Producto> GetAllGroup();
    }
}
