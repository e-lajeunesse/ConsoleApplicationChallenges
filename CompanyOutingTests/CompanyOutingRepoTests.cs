using CompanyOutings_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CompanyOutingTests
{
    [TestClass]
    public class CompanyOutingRepoTests
    {
        private CompanyOutingsRepository _repo = new CompanyOutingsRepository();
        public Outing outing1;
        public Outing outing2;
        public Outing outing3;
        public Outing outing4;

        [TestInitialize]
        public void Seed()
        {
            outing1 = new Outing(20, 1000.00m, EventType.AmusementPark, new DateTime(2020, 1, 1));
            outing2 = new Outing(10, 500.00m, EventType.Bowling, new DateTime(2021, 2, 1));
            outing3 = new Outing(15, 1500.00m, EventType.Golf, new DateTime(2020, 6, 4));
            outing4 = new Outing(10, 1000.00m, EventType.Golf, new DateTime(2020, 7, 1));
            _repo.AddOuting(outing1);
            _repo.AddOuting(outing2);
            _repo.AddOuting(outing3);
            _repo.AddOuting(outing4);
        }
        
        [TestMethod]
        public void AddOutingTestShouldAdd()
        {
            Outing outing5 = new Outing();
            bool wasAdded = _repo.AddOuting(outing5);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void DisplayOutingsTest()
        {
            _repo.DisplayOutings();
        }
        
        [TestMethod]
        public void CostOfAllOutingsTestShouldGetCorrectTotal()
        {
            decimal expected = 4000.00m;
            Assert.AreEqual(expected,_repo.CostOfAllOutings);
        }

        [TestMethod]
        public void CombinedCostByEventTestShouldGetCorrectTotal()
        {
            decimal actual = _repo.GetCombinedCostByEventType(EventType.Golf);
            Console.WriteLine(actual);
            decimal expected = 2500.00m;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MyTestMethod()
        {
            string f = "f";
            decimal x = -1m;
            Console.WriteLine(decimal.TryParse(f,out x));
            Console.WriteLine(x);
        }
    }
}
