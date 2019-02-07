using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelWay
{
    public class RailWayTicket : ITicket
    {
        public string SourceSiteURL { get; set; } // URL источника рейса, или же сайт источника. 
        public int Cost { get; set; } // Цена билета поезда.
        public DateTime ArrivalDate { get; set; } // Дата прибытия.
        public DateTime DepartureDate { get; set; } // Дата отбытия.
        public int HoursInTrip { get; set; } // Время в пути.
        public RailwayTicketClasses TicketClass { get; set; } // Тип билета поезда.(Купе, пацкарт)
    }
}
