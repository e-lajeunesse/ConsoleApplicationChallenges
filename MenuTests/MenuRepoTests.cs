using Menu_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MenuTests
{
    [TestClass]
    public class MenuRepoTests
    {

        private MenuRepository _repo;
        private MenuItem pizza;
        private MenuItem blt;

        [TestInitialize]
        public void Seed()
        {
            _repo = new MenuRepository();

            pizza = new MenuItem("Pizza", "New York style thin crust pizza with pepperoni",
                new List<string> { "cheese", "tomato sauce", "pepperoni" }, 7.99m, 1);

            blt = new MenuItem("BLT", "Sandwich with bacon lettuce and tomato",
                new List<string> { "bacon", "lettuce", "tomato" }, 5.99m, 2);

            _repo.AddMenuItem(pizza);
            _repo.AddMenuItem(blt);
        }


        [TestMethod]
        public void AddMenuItemTest()
        {
            int currentMenuItems = _repo.GetMenuItems().Count;
            MenuItem burger = new MenuItem();
            _repo.AddMenuItem(burger);
            Assert.IsTrue(_repo.GetMenuItems().Count > currentMenuItems);
        }

        [TestMethod]
        public void DeleteMenuItemTest()
        {
            bool wasDeleted = _repo.DeleteMenuItem(pizza);
            Assert.IsTrue(wasDeleted);
        }


        [TestMethod]
        public void DisplayMenuTest_ShouldSeeMenuInConsole()
        {
            _repo.DisplayMenu();
        }

        [TestMethod]
        public void GetMenuItemByNameTest_ShouldGetCorrectItem()
        {
            MenuItem menuItemToGet = _repo.GetItemByName("pIzZa");
            Assert.AreEqual(pizza, menuItemToGet);
        }
    }
}

