using AjaxUrunArama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxUrunArama.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductContext _context = new ProductContext();

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
        [HttpGet]
        public JsonResult Search(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }

            var products = _context.Products
                             .Where(p => p.Name.Contains(term))
                             .Select(p => new
                             {
                                 p.Id,
                                 p.Name,
                                 p.Price,
                                 p.Stock
                             })
                             .ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}