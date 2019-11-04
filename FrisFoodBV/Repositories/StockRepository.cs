using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrisFoodBV.Models;

namespace FrisFoodBV.Repositories
{
    public class StockRepository
    {
        FrisFoodEntities context = new FrisFoodEntities();

        public List<StockModel> GetStock()
        {
            return context.voorraads.Select(v => new StockModel
            {
                VestigingId = v.vestiging_id,
                ProductId = v.product_id,
                VoorraadAantal = v.aantal.Value
            }).ToList();
        }
        public List<StockModel> GetStock(int productID)
        {
           var totaleVoorraad = GetStock();

            return totaleVoorraad.Where(a => a.ProductId == productID).ToList();
        }

        public int GetProductStockById(int productID)
        {
            var totaleVoorraad = GetStock();
            var productSelect = totaleVoorraad.Where(s => s.ProductId == productID);
            var productStock = 0;
            foreach (var product in productSelect)
            {
                productStock = +product.VoorraadAantal;
            }
            return productStock;
        }

    }
}
