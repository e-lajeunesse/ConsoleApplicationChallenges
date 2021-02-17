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
        
        public bool AddMenuItem(MenuItem item)
        {
            int startingCount = _menuList.Count;
            _menuList.Add(item);
            return _menuList.Count == startingCount + 1;
        }

        public bool DeleteMenuItem(MenuItem item)
        {
            return _menuList.Remove(item);
        }

        public List<MenuItem> GetMenuItems()
        {
            return _menuList;
        }

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

        public MenuItem GetItemByName(string name)
        {
            foreach (MenuItem item in _menuList)
            {
                if (item.Name.ToUpper() == name.ToUpper())
                {
                    return item;
                }                
            }
            return null;
        }
    }
}
