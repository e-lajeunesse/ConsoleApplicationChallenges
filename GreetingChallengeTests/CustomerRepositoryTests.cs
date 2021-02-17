using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GreetingChallengeRepository;


namespace GreetingChallengeTests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private CustomerRepository _repo;
        private Customer customer1;
        private Customer customer2;
        private Customer customer3;
        private Customer customer4;

        [TestInitialize]
        public void Seed()
        {
            customer1 = new Customer("John", "Smith",1, CustomerType.Current);
            customer2 = new Customer("Jane", "Smith", 2,CustomerType.Past);
            customer3 = new Customer("Dave", "Alvarez",3, CustomerType.Potential);
            customer4 = new Customer("Bob", "Wilson",4, CustomerType.Current);
            _repo = new CustomerRepository();
            _repo.AddCustomer(customer1);
            _repo.AddCustomer(customer2);
            _repo.AddCustomer(customer3);
            _repo.AddCustomer(customer4);
        }

        [TestMethod]
        public void DisplaySortedCustomerListTest()
        {
            //order should be customer3,customer2,customer1,customer4
            _repo.DisplaySortedCustomerList();
        }

        [TestMethod]
        public void AddCustomerTest()
        {
            Customer customer5 = new Customer();
            bool wasAdded = _repo.AddCustomer(customer5);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void RemoveCustomerTest()
        {
            Customer customer6 = new Customer();
            bool wasRemoved = _repo.RemoveCustomer(customer4);
            bool notRemoved = _repo.RemoveCustomer(customer6);
            Assert.IsTrue(wasRemoved && !notRemoved);
        }

        [TestMethod]
        public void GetCustomerByIDTest()
        {
            Customer expectedCustomer = customer1;
            Customer actualCustomer = _repo.GetGustomerByID(1);
            Assert.AreEqual(expectedCustomer, actualCustomer);
        }
    }
}
