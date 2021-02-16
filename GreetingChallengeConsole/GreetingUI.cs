using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreetingChallengeRepository;

namespace GreetingChallengeConsole
{
    public class GreetingUI
    {
        private readonly CustomerRepository _repo = new CustomerRepository();
        public void RunUI()
        {
            bool keepRunning = true;
            while(keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Customer Repository. Enter a selection from the list below.\n" +
                    "1. Display all customers\n" +
                    "2. Add new customer\n" +
                    "3. Remove customer\n" +
                    "4. Update existing customer\n" +
                    "0. Exit");
                string userSelection = Console.ReadLine();
                switch(userSelection)
                {
                    case "1":
                        Console.Clear();
                        _repo.DisplaySortedCustomerList();
                        GoBackToMain();
                        break;
                    case "2":
                        //add new customer method
                        break;
                    case "3":                        
                        RemoveCustomer();
                        break;
                    case "4":
                        //update customer method
                        break;
                    case "0":
                        keepRunning = false;
                        break;

                        
                }
            }
        }

        public void RemoveCustomer()
        {
            Console.Clear();
            Customer customerToRemove = null;
            bool correctCustomer = false;
            while(!correctCustomer)
            {
                int id;
                Console.Write("Enter ID of customer to remove: ");                
                if (int.TryParse(Console.ReadLine(),out id))
                {
                    customerToRemove = _repo.GetGustomerByID(id);
                }
                if (customerToRemove != null)
                {
                    _repo.RemoveCustomer(customerToRemove);
                    correctCustomer = true;
                    Console.WriteLine("\nCustomer successfully removed");
                    GoBackToMain();
                }
                else
                {
                    Console.WriteLine("No customer with that ID found");
                }
            }
        }

        private void GoBackToMain()
        {
            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
        }

        public void Seed()
        {
            Customer customer1 = new Customer("John", "Smith", 1, CustomerType.Current);
            Customer customer2 = new Customer("Jane", "Smith", 2, CustomerType.Past);
            Customer customer3 = new Customer("Dave", "Alvarez", 3, CustomerType.Potential);
            Customer customer4 = new Customer("Bob", "Wilson", 4, CustomerType.Current);
            
            _repo.AddCustomer(customer1);
            _repo.AddCustomer(customer2);
            _repo.AddCustomer(customer3);
            _repo.AddCustomer(customer4);
        }
    }
}
