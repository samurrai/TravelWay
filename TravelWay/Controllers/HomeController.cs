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

        [HttpGet]
        public ActionResult Routes(string from, string to, DateTime depatureDate)
        {
            Searcher searcher = new Searcher();

            searcher.From = from;

            searcher.To = to;

            searcher.DepartureDate = depatureDate;

            ViewBag.Searcher = searcher;
            
            return View();
        }
    }
}