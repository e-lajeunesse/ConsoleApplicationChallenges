using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutings_Repository
{
    public class CompanyOutingsRepository
    {
        private List<Outing> _directory = new List<Outing>();

        public decimal CostOfAllOutings
        {
            get
            {
                decimal costOfOutings = (from outing in _directory select outing.TotalCost).Sum();
                return costOfOutings;
            }
        }

        public bool AddOuting(Outing outing)
        {
            int startingCount = _directory.Count;
            _directory.Add(outing);
            return _directory.Count == startingCount + 1;
        }

        public void DisplayOutings()
        {
            foreach(Outing outing in _directory)
            {
                Console.WriteLine($"Event Type: {outing.Event}\n" +
                    $"Number of people: {outing.NumberOfPeople}\n" +
                    $"Date of Event: {outing.DateOfEvent.ToShortDateString()}\n" +
                    $"Cost per person: ${outing.CostPerPerson}\n" +
                    $"Total Cost: ${outing.TotalCost}\n");
            }
        }

        public void DisplayOutingsAndCostByType(EventType type)
        {
            Console.WriteLine("Event Type    Date of event    Cost Per Person    Total Cost\n");
            foreach (Outing outing in _directory)
            {
                if (outing.Event == type)
                {
                    Console.WriteLine($"{outing.Event,-14}{outing.DateOfEvent.ToShortDateString(),-17}" +
                        $"${outing.CostPerPerson,-18}${ outing.TotalCost}");
                }
            }
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"                     Total for all {type} outings: ${GetCombinedCostByEventType(type)}\n\n");
        }

        public decimal GetCombinedCostByEventType(EventType type)
        {
            decimal combinedCost = (from outing in _directory where outing.Event == type select outing.TotalCost).Sum();
            return combinedCost;
        }        
    }
}
