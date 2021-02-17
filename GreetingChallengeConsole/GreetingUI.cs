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
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Customer Repository. Enter a selection from the list below.\n" +
                    "1. Display all customers\n" +
                    "2. Add new customer\n" +
                    "3. Remove customer\n" +
                    "4. Update existing customer\n" +
                    "0. Exit");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "1":
                        Console.Clear();
                        _repo.DisplaySortedCustomerList();
                        GoBackToMain();
                        break;
                    case "2":                        
                        AddNewCustomer();
                        break;
                    case "3":
                        RemoveCustomer();
                        break;
                    case "4":                        
                        UpdateCustomer();
                        break;
                    case "0":
                        keepRunning = false;
                        break;
                }
            }
        }

        public void AddNewCustomer()
        {
            Customer customerToAdd = new Customer();
            Console.Clear();
            Console.Write("Enter customer first name: ");
            customerToAdd.FirstName = Console.ReadLine();
            Console.Write("\nEnter customer last name: ");
            customerToAdd.LastName = Console.ReadLine();
            bool validID = false;
            while (!validID)
            {
                int id;
                Console.Write("\nEnter customer ID: ");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    customerToAdd.ID = id;
                    validID = true;
                }
            }
            List<int> validTypeEntries = new List<int> { 1, 2, 3 };
            int typeEntry = -1;
            while (!validTypeEntries.Contains(typeEntry))
            {
                Console.WriteLine("\nEnter customer type: \n" +
                    "1. Current\n" +
                    "2. Past\n" +
                    "3. Potential");
                typeEntry = int.Parse(Console.ReadLine());
            }
            customerToAdd.Type = (CustomerType)typeEntry;

            _repo.AddCustomer(customerToAdd);
            Console.WriteLine("\nCustomer successfully added.");
            GoBackToMain();
        }
        public void RemoveCustomer()
        {
            Console.Clear();
            Customer customerToRemove = GetCustomer();
            if (customerToRemove == null)
            {
                return;
            }
            _repo.RemoveCustomer(customerToRemove);
            Console.WriteLine("\nCustomer successfully removed");
            GoBackToMain();
        }
        public void UpdateCustomer()
        {
            Console.Clear();
            Customer customerToUpdate = GetCustomer();
            if (customerToUpdate == null)
            {
                return;
            }

            bool keepUpdating = true;
            while (keepUpdating)
            {
                Console.Clear();
                Console.WriteLine("What would you like to update?\n" +
                    "1. First name\n" +
                    "2. Last name\n" +
                    "3. ID\n" +
                    "4. Customer type\n");

                string updateSelection = Console.ReadLine();
                switch (updateSelection)
                {
                    case "1":                        
                        Console.Write("\nEnter first name: ");
                        customerToUpdate.FirstName = Console.ReadLine();
                        Console.WriteLine("First name updated, do you want to continue updating this customer?");
                        string keepGoing = null;
                        while(keepGoing == null)
                        {
                            keepGoing = yesOrNo();
                        }
                        keepUpdating = (keepGoing == "yes" ? true : false);
                        break;
                    case "2":                        
                        Console.Write("\nEnter last name: ");
                        customerToUpdate.LastName = Console.ReadLine();
                        Console.WriteLine("Last name updated. Do you want to continue updating this customer?");
                        keepGoing = null;
                        while (keepGoing == null)
                        {
                            keepGoing = yesOrNo();
                        }
                        keepUpdating = (keepGoing == "yes" ? true : false);
                        break;
                    case "3":                        
                        bool validID = false;
                        while (!validID)
                        {
                            int id;
                            Console.Write("\nEnter customer ID: ");
                            if (int.TryParse(Console.ReadLine(), out id))
                            {
                                customerToUpdate.ID = id;
                                validID = true;
                            }
                        }
                        Console.WriteLine("Id updated. Do you want to continue updating this customer?");
                        keepGoing = null;
                        while (keepGoing == null)
                        {
                            keepGoing = yesOrNo();
                        }
                        keepUpdating = (keepGoing == "yes" ? true : false);
                        break;
                    case "4":                        
                        List<int> validTypeEntries = new List<int> { 1, 2, 3 };
                        int typeEntry = -1;
                        while (!validTypeEntries.Contains(typeEntry))
                        {
                            Console.WriteLine("\nEnter customer type: \n" +
                                "1. Current\n" +
                                "2. Past\n" +
                                "3. Potential");
                            typeEntry = int.Parse(Console.ReadLine());
                        }
                        customerToUpdate.Type = (CustomerType)typeEntry;
                        Console.WriteLine("Customer type updated. Do you want to continue updating this customer?");
                        keepGoing = null;
                        while (keepGoing == null)
                        {
                            keepGoing = yesOrNo();
                        }
                        keepUpdating = (keepGoing == "yes" ? true : false);
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }
            }
        }

        public Customer GetCustomer()
        {
            
            Customer customerToGet = null;
            int id;
            bool validIDEntry = false;
            while (!validIDEntry)
            {
                Console.Clear();
                Console.Write("\nEnter ID of customer: ");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    customerToGet = _repo.GetGustomerByID(id);
                }
                if (customerToGet != null)
                {
                    validIDEntry = true;
                }
                else
                {
                    Console.Write("\nNo customer with that ID found, do you want to try another ID? ");
                    string keepGoing = null;
                    while(keepGoing == null)
                    {
                        keepGoing = yesOrNo();
                    }
                    validIDEntry = keepGoing == "yes"? false : true;                    
                }
            }
            return customerToGet;
        }

        public string yesOrNo()
        {
            Console.Write("Enter (y/n): ");
            string entry = Console.ReadLine().ToUpper();
            if (entry == "Y")
            {
                return "yes";
            }
            else if (entry == "N")
            {
                return "no";
            }
            else
            {
                Console.WriteLine("Invalid entry");
                return null;
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
