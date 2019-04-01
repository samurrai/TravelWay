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
                ViewBag.isFound = ViewBag.Tickets.Count == 0 ? false : true;
                ViewBag.Date = $"{searcherOriginal.DepartureDate.Day}.{searcherOriginal.DepartureDate.Month}.{searcherOriginal.DepartureDate.Year}";
                return View();
            }
        }

        public string GetAiroportCode(string city)
        {
            city = city.ToLower();
            string result = city.ToUpper();
            switch (city)
            {
                case "астана":
                    result = "TSE";
                    break;
                case "нур-султан":
                    result = "TSE";
                    break;
                case "алматы":
                    result = "ALA";
                    break;
                case "алмата":
                    result = "ALA";
                    break;
                case "санкт-петербург":
                    result = "LED";
                    break;
                case "краснодар":
                    result = "KRR";
                    break;
                case "актау":
                    result = "SCO";
                    break;
                case "актюбинск":
                    result = "AKX";
                    break;
                case "павлодар":
                    result = "PWQ";
                    break;
                case "москва":
                    result = "MOW";
                    break;
                case "челябинск":
                    result = "CEK";
                    break;
                case "париж":
                    result = "PAR";
                    break;
                case "караганда":
                    result = "KGF";
                    break;
                case "усть-каменогорск":
                    result = "UKK";
                    break;
                case "токио":
                    result = "TYO";
                    break;
                case "нью-йорк":
                    result = "NYC";
                    break;
                case "лондон":
                    result = "LON";
                    break;
                case "костанай":
                    result = "KSN";
                    break;
                case "петропавловск":
                    result = "PPK";
                    break;
                case "воронеж":
                    result = "VOZ";
                    break;
                case "экибастуз":
                    result = "EKB";
                    break;
                case "екатеринбург":
                    result = "SVX";
                    break;
                case "лос-анджелес":
                    result = "LAX";
                    break;
                case "кокшетау":
                    result = "KOV";
                    break;
                case "шымкент":
                    result = "CIT";
                    break;
                case "семипалатинск":
                    result = "PLX";
                    break;
                case "сочи":
                    result = "AER";
                    break;
                case "нижний новгород":
                    result = "GOJ";
                    break;
                case "калининград":
                    result = "KGD";
                    break;
                case "красноярск":
                    result = "KJA";
                    break;
                case "самара":
                    result = "KUF";
                    break;
                case "киев":
                    result = "IEV";
                    break;
                case "пекин":
                    result = "BJS";
                    break;
                case "шанхай":
                    result = "SHA";
                    break;
                case "рио-де-жанейро":
                    result = "RIO";
                    break;
                case "анталья":
                    result = "AYT";
                    break;
                case "анталия":
                    result = "AYT";
                    break;
                case "дубай":
                    result = "DXB";
                    break;
                case "дубаи":
                    result = "DXB";
                    break;
            }
            return result;
        }
    }
}
