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
                SetSearcherValue(searcher);
                string URL = "https://amid.kz/fly/search/?start=";
                URL += searcher.DepartureDate.Day + "/" + searcher.DepartureDate.Month + "/" + searcher.DepartureDate.Year + "&";
                URL += $"from={searcher.From}&to={searcher.To}&passenger_adt=1&passeger_chd=0";
                TicketsParser ticketsParser = new TicketsParser(URL);
                ViewBag.Tickets = ticketsParser.GetTickets();
                ViewBag.Searcher = searcher;
                return View();
            }


        }

        public void SetSearcherValue(Searcher searcher)
        {
            searcher.From.ToLower();
            switch (searcher.From)
            {
                case "астана":
                    searcher.From = "TSE";
                    break;
                case "нур-султан":
                    searcher.From = "TSE";
                    break;
                case "алмата":
                    searcher.From = "ALA";
                    break;
                case "санкт-петербург":
                    searcher.From = "LED";
                    break;
                case "краснодар":
                    searcher.From = "KRR";
                    break;
                case "актау":
                    searcher.From = "SCO";
                    break;
                case "актюбинск":
                    searcher.From = "AKX";
                    break;
                case "павлодар":
                    searcher.From = "PWQ";
                    break;
                case "москва":
                    searcher.From = "MOW";
                    break;
                case "челябинск":
                    searcher.From = "CEK";
                    break;
                case "париж":
                    searcher.From = "PAR";
                    break;
                case "караганда":
                    searcher.From = "KGF";
                    break;
                case "усть-каменогорск":
                    searcher.From = "UKK";
                    break;
                case "токио":
                    searcher.From = "TYO";
                    break;
                case "нью-йорк":
                    searcher.From = "NYC";
                    break;
                case "лондон":
                    searcher.From = "LON";
                    break;
                case "костанай":
                    searcher.From = "KSN";
                    break;
                case "петропавловск":
                    searcher.From = "PPK";
                    break;
                case "воронеж":
                    searcher.From = "VOZ";
                    break;
                case "экибастуз":
                    searcher.From = "EKB";
                    break;
                case "екатеринбург":
                    searcher.From = "SVX";
                    break;
                case "лос-анджелес":
                    searcher.From = "LAX";
                    break;
                case "кокшетау":
                    searcher.From = "KOV";
                    break;
                case "шымкент":
                    searcher.From = "CIT";
                    break;
                case "семипалатинск":
                    searcher.From = "PLX";
                    break;
                case "сочи":
                    searcher.From = "AER";
                    break;
                case "нижний новгород":
                    searcher.From = "GOJ";
                    break;
                case "калининград":
                    searcher.From = "KGD";
                    break;
                case "красноярск":
                    searcher.From = "KJA";
                    break;
                case "самара":
                    searcher.From = "KUF";
                    break;
                case "киев":
                    searcher.From = "IEV";
                    break;
                case "пекин":
                    searcher.From = "BJS";
                    break;
                case "шанхай":
                    searcher.From = "SHA";
                    break;
                case "рио-де-жанейро":
                    searcher.From = "RIO";
                    break;
                case "анталья":
                    searcher.From = "AYT";
                    break;
                case "анталия":
                    searcher.From = "AYT";
                    break;
                case "дубай":
                    searcher.From = "DXB";
                    break;
                case "дубаи":
                    searcher.From = "DXB";
                    break;
            }
            searcher.To.ToLower();
            switch (searcher.To)
            {
                case "астана":
                    searcher.To = "TSE";
                    break;
                case "нур-султан":
                    searcher.To = "TSE";
                    break;
                case "алмата":
                    searcher.To = "ALA";
                    break;
                case "санкт-петербург":
                    searcher.To = "LED";
                    break;
                case "краснодар":
                    searcher.To = "KRR";
                    break;
                case "актау":
                    searcher.To = "SCO";
                    break;
                case "актюбинск":
                    searcher.To = "AKX";
                    break;
                case "павлодар":
                    searcher.To = "PWQ";
                    break;
                case "москва":
                    searcher.To = "MOW";
                    break;
                case "челябинск":
                    searcher.To = "CEK";
                    break;
                case "париж":
                    searcher.To = "PAR";
                    break;
                case "караганда":
                    searcher.To = "KGF";
                    break;
                case "усть-каменогорск":
                    searcher.To = "UKK";
                    break;
                case "токио":
                    searcher.To = "TYO";
                    break;
                case "нью-йорк":
                    searcher.To = "NYC";
                    break;
                case "лондон":
                    searcher.To = "LON";
                    break;
                case "костанай":
                    searcher.To = "KSN";
                    break;
                case "петропавловск":
                    searcher.To = "PPK";
                    break;
                case "воронеж":
                    searcher.To = "VOZ";
                    break;
                case "экибастуз":
                    searcher.To = "EKB";
                    break;
                case "екатеринбург":
                    searcher.To = "SVX";
                    break;
                case "лос-анджелес":
                    searcher.To = "LAX";
                    break;
                case "кокшетау":
                    searcher.To = "KOV";
                    break;
                case "шымкент":
                    searcher.To = "CIT";
                    break;
                case "семипалатинск":
                    searcher.To = "PLX";
                    break;
                case "сочи":
                    searcher.To = "AER";
                    break;
                case "нижний новгород":
                    searcher.To = "GOJ";
                    break;
                case "калининград":
                    searcher.To = "KGD";
                    break;
                case "красноярск":
                    searcher.To = "KJA";
                    break;
                case "самара":
                    searcher.To = "KUF";
                    break;
                case "киев":
                    searcher.To = "IEV";
                    break;
                case "пекин":
                    searcher.To = "BJS";
                    break;
                case "шанхай":
                    searcher.To = "SHA";
                    break;
                case "рио-де-жанейро":
                    searcher.To = "RIO";
                    break;
                case "анталья":
                    searcher.To = "AYT";
                    break;
                case "анталия":
                    searcher.To = "AYT";
                    break;
                case "дубай":
                    searcher.To = "DXB";
                    break;
                case "дубаи":
                    searcher.To = "DXB";
                    break;
            }
        }
    }
}
