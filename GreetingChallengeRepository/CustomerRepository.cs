using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingChallengeRepository
{
    public class CustomerRepository
    {
        private readonly List<Customer> _directory = new List<Customer>();
        
        // Sort Customer list alphabetically by last name followed by first name
        public List<Customer> CustomersInOrder
        {
            get
            {
                List<Customer> sortedList = _directory.OrderBy(customer => customer.LastName)
                    .ThenBy(customer => customer.FirstName).ToList();
                return sortedList;
            }
        }

        public bool AddCustomer(Customer customer)
        {
            int startingCount = _directory.Count;
            _directory.Add(customer);
            return _directory.Count == startingCount + 1;
        }

        public bool RemoveCustomer(Customer customer)
        {
            return _directory.Remove(customer);
        }

        public Customer GetGustomerByID(int id)
        {
            foreach(Customer customer in _directory)
            {
                if (customer.ID == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public void DisplaySortedCustomerList()
        {
            Console.WriteLine("Last Name     First Name     ID      Type           Email");
            Console.WriteLine("----------------------------------------------------------");
            foreach(Customer customer in CustomersInOrder)
            {
                Console.WriteLine($"{customer.LastName,-15}{customer.FirstName,-15}{customer.ID,-7}{customer.Type,-15}{customer.Email}");
            }
        }
    }
}
