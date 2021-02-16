using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings_Repository
{
    public enum EventType { Golf = 1,Bowling,AmusementPark,Concert}
    public class Outing
    {
        public int NumberOfPeople { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CostPerPerson => Decimal.Round(TotalCost / NumberOfPeople,2);
        public EventType Event { get; set; }
        public Outing() { }
        public Outing(int numPeople,decimal totalCost, EventType type, DateTime date)
        {
            NumberOfPeople = numPeople;
            TotalCost = totalCost;
            Event = type;
            DateOfEvent = date;
        }


    }
}
