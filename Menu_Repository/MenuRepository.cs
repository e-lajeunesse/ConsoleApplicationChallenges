using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Repository
{
    public class MenuRepository
    {
        public List<MenuItem> MenuList { get; } = new List<MenuItem>();
        public MenuRepository() { }

        //Method to add new menu item to menu
        public void AddMenuItem(MenuItem item)
        {
            MenuList.Add(item);
        }

        //Method to delete a menu item
        public bool DeleteMenuItem(MenuItem item)
        {
            return MenuList.Remove(item);
        }

        //Method to return list of all menu items
        public List<MenuItem> GetMenuItems()
        {
            return MenuList;
        }

        //Method to see all items in menu
        public void DisplayMenu()
        {
            foreach (MenuItem item in MenuList)
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
            foreach (MenuItem item in MenuList)
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
