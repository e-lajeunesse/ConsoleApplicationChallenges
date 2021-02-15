using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Repository
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menuList = new List<MenuItem>();
        public MenuRepository() { }

        //Method to add new menu item to menu
        public bool AddMenuItem(MenuItem item)
        {
            int startingCount = _menuList.Count;
            _menuList.Add(item);
            return _menuList.Count == startingCount + 1;
        }

        //Method to delete a menu item
        public bool DeleteMenuItem(MenuItem item)
        {
            return _menuList.Remove(item);
        }

        //Method to return list of all menu items
        public List<MenuItem> GetMenuItems()
        {
            return _menuList;
        }

        //Method to see all items in menu
        public void DisplayMenu()
        {
            foreach (MenuItem item in _menuList)
            {
                Console.WriteLine($"#{item.MealNumber}: {item.Name}- {item.Description}");
                Console.WriteLine($"Ingredients: {item.IngredientsString()}");
                Console.WriteLine($"Price: ${item.Price}");
                Console.WriteLine("\n");
            }
        }

        // Get menu item by name
        public MenuItem GetItemByName(string name)
        {
            foreach (MenuItem item in _menuList)
            {
                if (item.Name.ToUpper() == name.ToUpper())
                {
                    return item;
                }
                Console.WriteLine("Unable to find menu item with that name.");
            }
            return null;
        }
    }
}
