using System;
using System.Web.Mvc;

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
            var date = DateTime.Now;
            if (searcherOriginal.From is null || searcherOriginal.To is null || searcherOriginal.DepartureDate.Date < date.Date)
            {
                return View("/Views/Home/Index.cshtml");
            }
            else
            {
                ViewBag.SearcherOriginal = searcherOriginal;
                Searcher searcher = new Searcher
                {
                    From = searcherOriginal.From,
                    To = searcherOriginal.To,
                    DepartureDate = searcherOriginal.DepartureDate
                };
                ViewBag.isFound = false;
          
                searcher.From = GetAiroportCode(searcher.From);
                searcher.To = GetAiroportCode(searcher.To);

                string URL = "https://amid.kz/fly/search/?start=";
                URL += searcher.DepartureDate.Day.ToString() + "/" + searcher.DepartureDate.Month.ToString() + "/" + searcher.DepartureDate.Year.ToString() + "&";
                URL += $"from={searcher.From}&to={searcher.To}&passenger_adt=1&passeger_chd=0";

                TicketsParser ticketsParser = new TicketsParser(URL);
                ViewBag.Tickets = ticketsParser.GetTickets();

                ViewBag.Searcher = searcher;
                ViewBag.isFound = ViewBag.Tickets is null ? true : false; 
                return View();
            }
        }

        public string GetAiroportCode(string city)
        {
            city = city.ToLower();
            string resualt = city.ToUpper();
            switch (city)
            {
                case "астана":
                    resualt = "TSE";
                    break;
                case "нур-султан":
                    resualt = "TSE";
                    break;
                case "алматы":
                    resualt = "ALA";
                    break;
                case "санкт-петербург":
                    resualt = "LED";
                    break;
                case "краснодар":
                    resualt = "KRR";
                    break;
                case "актау":
                    resualt = "SCO";
                    break;
                case "актюбинск":
                    resualt = "AKX";
                    break;
                case "павлодар":
                    resualt = "PWQ";
                    break;
                case "москва":
                    resualt = "MOW";
                    break;
                case "челябинск":
                    resualt = "CEK";
                    break;
                case "париж":
                    resualt = "PAR";
                    break;
                case "караганда":
                    resualt = "KGF";
                    break;
                case "усть-каменогорск":
                    resualt = "UKK";
                    break;
                case "токио":
                    resualt = "TYO";
                    break;
                case "нью-йорк":
                    resualt = "NYC";
                    break;
                case "лондон":
                    resualt = "LON";
                    break;
                case "костанай":
                    resualt = "KSN";
                    break;
                case "петропавловск":
                    resualt = "PPK";
                    break;
                case "воронеж":
                    resualt = "VOZ";
                    break;
                case "экибастуз":
                    resualt = "EKB";
                    break;
                case "екатеринбург":
                    resualt = "SVX";
                    break;
                case "лос-анджелес":
                    resualt = "LAX";
                    break;
                case "кокшетау":
                    resualt = "KOV";
                    break;
                case "шымкент":
                    resualt = "CIT";
                    break;
                case "семипалатинск":
                    resualt = "PLX";
                    break;
                case "сочи":
                    resualt = "AER";
                    break;
                case "нижний новгород":
                    resualt = "GOJ";
                    break;
                case "калининград":
                    resualt = "KGD";
                    break;
                case "красноярск":
                    resualt = "KJA";
                    break;
                case "самара":
                    resualt = "KUF";
                    break;
                case "киев":
                    resualt = "IEV";
                    break;
                case "пекин":
                    resualt = "BJS";
                    break;
                case "шанхай":
                    resualt = "SHA";
                    break;
                case "рио-де-жанейро":
                    resualt = "RIO";
                    break;
                case "анталья":
                    resualt = "AYT";
                    break;
                case "анталия":
                    resualt = "AYT";
                    break;
                case "дубай":
                    resualt = "DXB";
                    break;
                case "дубаи":
                    resualt = "DXB";
                    break;
            }
            return resualt;
        }
    }
}
