using FrisFoodBV.Models;
using FrisFoodBV.Repositories;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrisFoodBV.Controllers
{
    public class ProductsController : Controller
    {
        ProductRepository productRepo = new ProductRepository();
        StockRepository stockRepo = new StockRepository();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products()
        {
            dynamic dy = new ExpandoObject();
            dy.products = productRepo.GetProducts();
            dy.stock = stockRepo.GetStock();
            return View(dy);
        }
        public ActionResult Stock(int productID)
        {
            var stock = stockRepo.GetStock(productID);
            ViewBag.ProductNaam = productRepo.GetProductNameById(productID);
            ViewBag.ProductMerk = productRepo.GetProductBrandById(productID);
            stockRepo.GetProductStockById(productID);
            return View(stock);
        }

        public ActionResult Add()
        {
            return View(new ProductModel());
        }

        [HttpPost]
        public ActionResult Add(ProductModel model)
        {
            productRepo.AddNewProduct(model);
            return RedirectToAction("Products");
        }

        public ActionResult Update(int productId)
        {
            var productM = productRepo.GetProductById(productId);
            return View(productM);
        }

        [HttpPost]
        public ActionResult Update(ProductModel productM)
        {
            productRepo.UpdateProduct(productM);
            return RedirectToAction("Products");
        }

        public ActionResult Remove(int productId)
        {
            var productM = productRepo.GetProductById(productId);
            return View(productM);
        }

        [HttpPost]
        public ActionResult Remove(ProductModel productM)
        {
            productRepo.RemoveProduct(productM);
            return RedirectToAction("Products");
        }


    }
}