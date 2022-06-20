using highcharts_line2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace highcharts_line2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            NORTHWNDEntities context = new NORTHWNDEntities();
            var query = context.Order_Details.Include("Products")
                   .GroupBy(p => p.Products.ProductName)
                   .Select(g => new { name = g.Key, count = g.Sum(w => w.Quantity) }).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);
        }

    }
}