using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyOutings_Repository;

namespace CompanyOutingConsole
{
    public class OutingUI
    {
        private readonly CompanyOutingsRepository _repo = new CompanyOutingsRepository();
        private readonly string goBackToMenu = "Press any key to go back to main menu.";

        public void RunUI()
        {
            bool keepRunning = true;
            while(keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Company Outings Application. Enter" +
                    " a selection from the list below.\n" +
                    "1. Display all outings.\n" +
                    "2. Add new outing.\n" +
                    "3. Display total cost of all outings\n" +
                    "0. Exit");

                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        Console.Clear();
                        _repo.DisplayOutings();
                        Console.WriteLine(goBackToMenu);
                        Console.ReadKey();
                        break;
                    case "2":
                        AddNewOuting();
                        break;
                    case "3":
                        //method to display costs
                        DisplayCosts();
                        break;
                    case "0":
                        keepRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"Invalid Selection {goBackToMenu}");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void AddNewOuting()
        {
            Outing outingToAdd = new Outing();

            List<int> validEventTypeEntries = new List<int> { 1, 2, 3, 4 };
            int eventType = -1;
            while(!validEventTypeEntries.Contains(eventType))
            {
                Console.Clear();
                Console.WriteLine("Enter event type: \n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusement Park\n" +
                    "4. Concert\n");
                if (int.TryParse(Console.ReadLine(),out eventType))
                {
                    outingToAdd.Event = (EventType)eventType;
                }                
            }

            int numberOfPeople = -1;
            while(!(numberOfPeople >= 0))
            {
                Console.Write("\nEnter number of people that attended: ");
                if (!int.TryParse(Console.ReadLine(),out numberOfPeople))
                {
                    numberOfPeople = -1;
                }
                else
                {
                    outingToAdd.NumberOfPeople = numberOfPeople;
                }
            }

            decimal totalCost = -1m;
            while(!(totalCost>= 0))
            {
                Console.Write("\nEnter total cost of event: ");
                if (!decimal.TryParse(Console.ReadLine(),out totalCost))
                {
                    totalCost = -1m;
                }
                else
                {
                    outingToAdd.TotalCost = totalCost;
                }
            }

            bool validEventDate = false;
            while (!validEventDate)
            {
                Console.Write("\nEnter date of Event(mm-dd-yyyy): ");
                string dateString = Console.ReadLine();
                DateTime dateOfEvent;
                if (DateTime.TryParse(dateString, out dateOfEvent))
                {
                    outingToAdd.DateOfEvent = dateOfEvent;
                    validEventDate = true;
                }
                else
                {
                    Console.WriteLine("Invalid format for date");
                }
            }
            _repo.AddOuting(outingToAdd);
            Console.WriteLine($"\nOuting successfully added. {goBackToMenu}");
            Console.ReadKey();
        }

        public void DisplayCosts()
        {
            Console.Clear();
            Console.WriteLine($"                          Total Cost\n\n" +
                $"          Golf Outings:   ${_repo.GetCombinedCostByEventType(EventType.Golf)}\n" +
                $"       Bowling Outings:   ${_repo.GetCombinedCostByEventType(EventType.Bowling)}\n" +
                $"       Concert Outings:   ${_repo.GetCombinedCostByEventType(EventType.Concert)}\n" +
                $"Amusement Park Outings:   ${_repo.GetCombinedCostByEventType(EventType.AmusementPark)}\n" +
                $"-----------------------------------------------------------\n" +
                $"  All Outings Combined:   ${_repo.CostOfAllOutings,-12}\n");
            Console.WriteLine(goBackToMenu);
            Console.ReadKey();
        }

        public void Seed()
        {
            Outing outing1 = new Outing(20, 1000.00m, EventType.AmusementPark, new DateTime(2020, 1, 1));
            Outing outing2 = new Outing(10, 500.00m, EventType.Bowling, new DateTime(2021, 2, 1));
            Outing outing3 = new Outing(15, 1500.00m, EventType.Golf, new DateTime(2020, 6, 4));
            Outing outing4 = new Outing(10, 1000.00m, EventType.Golf, new DateTime(2020, 7, 1));
            _repo.AddOuting(outing1);
            _repo.AddOuting(outing2);
            _repo.AddOuting(outing3);
            _repo.AddOuting(outing4);
        }
    }
}
