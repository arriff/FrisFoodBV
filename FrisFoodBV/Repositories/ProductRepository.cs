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

        public List<ProductModel> GetProducts()
        {
            return context.productens.Select(p => new ProductModel 
            {   Naam = p.product_naam, 
                Id = p.product_id, 
                Merk = p.product_merk
            }).ToList(); 
        }

        public ProductModel GetProductById(int productID)
        {
            var productE = context.productens.Single(p => p.product_id == productID);
            var productM = new ProductModel
            {
                Id = productE.product_id,
                Naam = productE.product_naam,
                Merk = productE.product_merk
            };
            return productM;
        }

        public string GetProductNameById(int productID)
        {
            var producten = GetProducts();
            return producten.First(p => p.Id == productID).Naam;
        }

        public string GetProductBrandById(int productID)
        {
            var producten = GetProducts();
            return producten.First(p => p.Id == productID).Merk;
        }

        public void AddNewProduct(ProductModel productModel)
        {
            context.productens.Add(new producten
            {
                product_naam = productModel.Naam,
                product_merk = productModel.Merk,
                //gewicht
                //afmeting
            });
            context.SaveChanges();
        }
        public void UpdateProduct(ProductModel productM)
        {
            var productE = context.productens.Single(p => p.product_id == productM.Id);

            productE.product_naam = productM.Naam;
            productE.product_merk = productM.Merk;

            context.SaveChanges();
        }

        public void RemoveProduct(ProductModel productM)
        {
            var productE = context.productens.Single(p => p.product_id == productM.Id);
            context.productens.Remove(productE);
            context.SaveChanges();
        }

    }
}