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
            ViewBag.DateNow = DateTime.Now;
            return View();
        }

        [HttpPost]
        public ActionResult Routes(Searcher searcher)
        {
            ViewBag.Searcher = searcher;
            
            return View();
        }
    }
}