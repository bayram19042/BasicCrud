using BasicCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace BasicCrud.Controllers
{
   

    public class HomeController : Controller
    {
        public IActionResult Index()
        {



            return View();
        }
        [HttpPost]
  
        public IActionResult Add(Product gelenurun)
        {
           

                ETradeContext context = new ETradeContext();

                context.Product.Add(gelenurun);

                context.SaveChanges();
                List<Product> urunler = context.Product.ToList();

                return View(urunler);
            
        }

        public IActionResult Add()
        {
            ETradeContext con = new ETradeContext();

          

            List<Product> urunler = con.Product.ToList();

            return View(urunler);
        }
        public IActionResult Delete(int id)
        {

            ETradeContext ctx = new ETradeContext();
            var silinecekveri = ctx.Product.Where(s => s.ProductId == id).FirstOrDefault();
            ctx.Product.Remove(silinecekveri);
            ctx.SaveChanges();
            //var liste = ctx.Product.ToList();
            //int sayi = liste.Count;
            //ViewBag.sayi = sayi;

            return RedirectToAction("add","home");
        }

        public IActionResult guncelle(int id)
        {

            ETradeContext ctx = new ETradeContext();
            var guncellenecekveri = ctx.Product.Where(s => s.ProductId == id).FirstOrDefault();

            return View(guncellenecekveri);
        }

        [HttpPost]
        public IActionResult guncelle(Product product)
        {

            ETradeContext ctl = new ETradeContext();
            var urunid = product.ProductId;
            var guncellenecekveri = ctl.Product.Where(s => s.ProductId == urunid).FirstOrDefault();
            guncellenecekveri.Name = product.Name;
            guncellenecekveri.ProductCount = product.ProductCount;
            guncellenecekveri.Category = product.Category;
            ctl.SaveChanges();
            return RedirectToAction("add");
        }

    }
}
