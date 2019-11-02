using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FrisFoodBV.Models;

namespace FrisFoodBV.Repositories
{
    public class VoorraadRepository
    {
        FrisFoodEntities context = new FrisFoodEntities();

        public List<VoorraadModel> GetAllStock()
        {
            return context.voorraads.Select(v => new VoorraadModel
            {
                VestigingId = v.vestiging_id,
                ProductId = v.product_id,
                VoorraadAantal = v.aantal.Value
            }).ToList();
        }
        public List<VoorraadModel> GetStock(int productID)
        {
           var totaleVoorraad = GetAllStock();

            return totaleVoorraad.Where(a => a.ProductId == productID).ToList();
        }

}
}