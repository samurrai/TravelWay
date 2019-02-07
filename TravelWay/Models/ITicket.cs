using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelWay
{
    public interface ITicket
    {
         string SourceSiteURL{ get; set; } // URL источника.
        int Cost { get; set; } // Цена билета.
        DateTime ArrivalDate { get; set; } // Дата прибытия.
        DateTime DepartureDate { get; set; } // Дата отбытия.
        int HoursInTrip { get; set; } // Время в пути.
    }
}
