using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Repository
{
    public class MenuItem
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Ingredients { get; set; }

        public decimal Price { get; set; }

        public int MealNumber { get; set; }

        public MenuItem() { }

        public MenuItem(string name, string description, List<string> ingredients, decimal price, int mealNumber)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
            MealNumber = mealNumber;
        }

        //Method to convert list of ingredients into a string
        public string IngredientsString()
        {
            return string.Join(", ", Ingredients);
        }
    }
}
