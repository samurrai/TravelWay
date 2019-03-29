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
        public ActionResult Routes(Searcher searcherOriginal)
        {
            Searcher searcher = searcherOriginal;
            ViewBag.isFound = false;
            var date = DateTime.Now;
            
            if (searcherOriginal.From is null || searcherOriginal.To is null || searcherOriginal.DepartureDate.Date < date.Date)
            {

                return View("/Views/Home/Index.cshtml");
            }
            else
            {
                searcher.From.ToLower();
                switch (searcher.From)
                {

                    case "астана":
                        searcher.From = "TSE";
                        break;
                }
                TicketsParser ticketsParser = new TicketsParser(URL);
                ViewBag.Tickets = ticketsParser.GetTickets();
                ViewBag.SearcherOriginal = searcherOriginal;
                ViewBag.Searcher = searcher;
                return View();
            }
        }
    }
}