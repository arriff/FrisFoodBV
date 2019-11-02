using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrisFoodBV.Repositories;

namespace FrisFoodBV.Controllers
{
    public class HomeController : Controller
    {
        ProductRepository repo = new ProductRepository();
        StockRepository repoX = new StockRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Products()
        {
            var producten = repo.GetAllProducts();

            return View(producten);
        }

        public ActionResult Stock(int productID)
        {
            var stock = repoX.GetStock(productID);
            ViewBag.ProductNaam = repo.GetProductNameById(productID);
            ViewBag.ProductMerk = repo.GetProductBrandById(productID);
            return View(stock);
        }

    }
}