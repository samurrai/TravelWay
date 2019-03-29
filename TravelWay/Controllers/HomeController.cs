using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelWay.Controllers;

namespace TravelWay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Routes(Searcher searcher)
        {
            ViewBag.isFound = false;
            var date = DateTime.Now;
            
            if (searcher.From is null || searcher.To is null || searcher.DepartureDate.Date < date.Date)
            {
                return View("/Views/Home/Index.cshtml");
            }
            else
            {
                ViewBag.Searcher = searcher;
                return View();
            }
        }
    }
}