using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelWay
{
    public class Way
    {
        public List<ITicket> FullWay { get; set; }

        public int GetFullTimeInWay()
        {
            int fullTime = 0;
            foreach(ITicket trip in FullWay)
            {
                fullTime += trip.HoursInTrip;
            }
            return fullTime;
        }

        public int GetFullCost()
        {
            int fullCost = 0;
            foreach (ITicket trip in FullWay)
            {
                fullCost += trip.Cost;
            }
            return fullCost;
        }
    }
}
