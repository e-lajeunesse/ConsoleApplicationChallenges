using Badge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BadgeTests
{
    [TestClass]
    public class BadgeRepoTests
    {
        private Badge badge1;
        private Badge badge2;
        private BadgeRepository _repo;
        
        [TestInitialize]
        public void Seed()
        {
            badge1 = new Badge(123, new List<string>{ "A1", "A2" });
            badge2 = new Badge(456, new List<string> { "B1", "B2" });
            _repo = new BadgeRepository();
            _repo.AddNewBadge(badge1);
            _repo.AddNewBadge(badge2);
        }
        
        [TestMethod]
        public void DisplayBadgesTest()
        {
            _repo.DisplayBadges();
        }

        [TestMethod]
        public void AddNewBadgeTestShouldBeTrue()
        {
            Badge badge3 = new Badge(124, new List<string> { "A1", "B2" });
            Assert.IsTrue(_repo.AddNewBadge(badge3));
        }

        [TestMethod]
        public void AddDoorTestShouldBeTrue()
        {
            bool doorAdded = _repo.AddDoor(123, "C1");
            Assert.IsTrue(doorAdded);
        }

        [TestMethod]
        public void RemoveSingeDoorTestShouldBeTrue()
        {
            bool doorRemoved = _repo.RemoveDoor(123, "A1");
            Assert.IsTrue(doorRemoved);
        }

        [TestMethod]
        public void RemoveSingeDoorTestShouldBeFalse()
        {
            bool doorRemoved = _repo.RemoveDoor(123, "A5");
            Assert.IsFalse(doorRemoved);
        }

        [TestMethod]
        public void RemoveAllDoorsTestShouldBeTrue()
        {
            bool doorsRemoved = _repo.RemoveAllDoors(456);
            Assert.IsTrue(doorsRemoved);
        }

        [TestMethod]
        public void RemoveAllDoorsTestShouldBeFalse()
        {
            bool doorsRemoved = _repo.RemoveAllDoors(789);
            Assert.IsFalse(doorsRemoved);
        }
    }
}
