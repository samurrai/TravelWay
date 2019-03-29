using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using System.IO;


namespace TravelWay
{
    public class TicketsParser
    {
        private WebClient webClient;
        public string Path { get; set; }
        public string Html { get; set; }
        public TicketsParser(string path)
        {
            webClient = new WebClient();
            Path = path;
            Html = webClient.DownloadString(path);
        }

        public List<AirTicket> GetTickets()
        {
            try
            {
                HtmlParser parser = new HtmlParser();

                var document = parser.ParseDocument(Html);

                var prices = document.GetElementsByClassName("price");
                var airCompanies = document.GetElementsByClassName("airlineColor_KC air_KC_");
                var URL = Path;
                var time = document.QuerySelectorAll("div.dt-left > div.time");

                List<AirTicket> tickets = new List<AirTicket>();
                for (int i = 0; i < prices.Count(); i++)
                {
                    tickets.Add(new AirTicket
                    {
                        Cost = prices[i].TextContent.Trim().Substring(0, prices[i].TextContent.Trim().Length - 8),
                        AirCompany = airCompanies[i].TextContent.Trim(),
                        SourceSiteURL = URL.Trim(),
                        Time = time[i].TextContent.Trim(),
                    });
                }
                return tickets;
            }
            catch (Exception)
            {
                return new List<AirTicket>();
            }
  
        }

     
    }
}

