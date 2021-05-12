using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        Context context = new Context();
        // GET: Statistic
        public ActionResult Index()

        {

            var result1 = context.Categories.Count();
            ViewBag.CategoryCount = result1;

            var result2 = context.Headings.Count(x => x.Category.CategoryName == "Yazılım");
            ViewBag.Heading = result2;

            var result3 = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.Writer = result3;

            var result4 = context.Headings.Max(x => x.Category.CategoryID);
            var heading = context.Categories.Find(result4).CategoryName;
            ViewBag.HeadingMax = heading;

            var difference = context.Categories.Count(m => m.CategoryStatus == true) - context.Categories.Count(m => m.CategoryStatus == false);
            ViewBag.StatusFark = difference;

            return View();
        }
    }
}