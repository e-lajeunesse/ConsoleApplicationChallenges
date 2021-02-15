using Claim_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimTests
{
    [TestClass]
    public class ClaimRepoTests
    {
        private ClaimRepository _repo;
        private Claim claim1;
        private Claim claim2;

        [TestInitialize]
        public void Seed()
        {
            _repo = new ClaimRepository();
            claim1 = new Claim(1, ClaimType.Car, "car accident on HWY Y", 1400.00m,
                new DateTime(2020, 12, 20), new DateTime(2020, 12, 27));
            _repo.AddClaim(claim1);

            claim2 = new Claim(2, ClaimType.Home, "fire in kitchen", 800.00m,
                new DateTime(2020, 10, 29), new DateTime(2020, 12, 22));
            _repo.AddClaim(claim2);
        }
        
        [TestMethod]
        // note that text alignment is correct when run in console, but not in unit test
        public void DisplayClaimsTest()
        {
            _repo.DisplayClaims();
        }

        [TestMethod]
        public void AddClaimsTest()
        {
            Claim claim3 = new Claim();
            _repo.AddClaim(claim3);
            Assert.IsTrue(_repo.GetClaims().Contains(claim3));
        }

        [TestMethod]
        public void DeleteClaimTest()
        {
            _repo.DeleteClaim(claim2);
            Assert.IsFalse(_repo.GetClaims().Contains(claim2));
        }

        [TestMethod]
        public void GetClaimByIDTestShouldGetCorrectClaim()
        {
            Claim claimToGet = _repo.GetClaimByID(2);
            Claim actual = claim2;
            Assert.AreEqual(claimToGet, claim2);            
        }

        [DataTestMethod]
        public void IsValidTests()
        {
            DateTime time1 = new DateTime(2020, 01, 01);
            DateTime time2 = new DateTime(2020, 01, 31);
            DateTime time3 = new DateTime(2020, 02, 01);

            Claim testClaim1 = new Claim();
            Claim testClaim2 = new Claim();
            testClaim1.DateOfIncident = time1;
            testClaim1.DateOfClaim = time2;
            testClaim2.DateOfIncident = time1;
            testClaim2.DateOfClaim = time3;
            Assert.IsTrue(testClaim1.IsValid);
            Assert.IsFalse(testClaim2.IsValid);
        }
    }
}

