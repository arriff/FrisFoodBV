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

        public List<StockModel> GetAllStock()
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
           var totaleVoorraad = GetAllStock();

            return totaleVoorraad.Where(a => a.ProductId == productID).ToList();
        }

}
}