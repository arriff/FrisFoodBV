using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel;
using FrisFoodBV.Models;

namespace FrisFoodBV.Repositories
{
    public class ProductRepository
    {
        FrisFoodEntities context = new FrisFoodEntities();

        public List<ProductModel> GetAllProducts()
        {
            return context.productens.Select(p => new ProductModel 
            {   Naam = p.product_naam, 
                Id=p.product_id, 
                Merk=p.product_merk
            }).ToList(); 
        }


    }
}