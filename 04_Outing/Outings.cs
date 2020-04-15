using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outing
{
    public enum EventTypes
    {
        Golf = 1,
        Bowling,
        AmusementPark,
        Concert
    }
    class Outings
    {
        public EventTypes Event { get; set; }
        public int Attendance { get; set; }
        public DateTime Date { get; set; }
        public double CostPerPerson
        {
            get
            {
                return TotalCost / Attendance;
            }
        }
        public double TotalCost { get; set; }


        public Outings() { }

        public Outings(EventTypes events, int attendance, DateTime date, double totalCost)
        {
            Event = events;
            Attendance = attendance;
            Date = date;
            TotalCost = totalCost;
        }
    }
}
