﻿using Menu_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsole
{
    public class MenuUI
    {
        private MenuRepository _repo = new MenuRepository();
        public MenuUI() {}
        public void RunUI()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine($"\nWelcome to the Komodo Cafe Menu Application. " +
                    $"Please enter a selection from the list below: \n\n" +
                    $"1. Display Menu\n" +
                    $"2. Add item to Menu\n" +
                    $"3. Remove item from Menu\n" +
                    $"4. Edit item on Menu\n" +
                    $"0. Exit\n"
                    );
                Console.Write("Selection: ");
                switch (Console.ReadLine())
                {
                    case "1":                        
                        Console.Clear();
                        _repo.DisplayMenu();
                        GoBackToMain();
                        break;
                    case "2":                        
                        AddItem();
                        break;
                    case "3":                        
                        DeleteItem();
                        break;
                    case "4":                        
                        EditItem();
                        break;
                    case "0":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection.");
                        break;
                }
            }
        }
        public void AddItem()
        {
            Console.Clear();
            Console.Write("Enter menu item name: ");
            string itemName = Console.ReadLine();
            Console.Write("\nEnter menu item description: ");
            string description = Console.ReadLine();
            List<string> ingredients = GetIngredientList();            
            bool validPrice = false;
            decimal price = -1;
            while(!validPrice)
            {
                Console.Write("\nEnter item price: ");
                if (decimal.TryParse(Console.ReadLine(),out price))
                {
                    validPrice = true;
                }
            }            
            bool validMenuNumber = false;
            int itemNumber = -1;
            while(!validMenuNumber)
            {
                Console.Write("\nEnter menu item number: ");
                if (int.TryParse(Console.ReadLine(),out itemNumber))
                {
                    validMenuNumber = true;
                }
            }
            MenuItem itemToAdd = new MenuItem(itemName, description, ingredients, price, itemNumber);
            _repo.AddMenuItem(itemToAdd);
        }

        public void DeleteItem()
        {
            Console.Clear();
            Console.Write("Enter name of item you wish to remove: ");
            string name = Console.ReadLine();
            MenuItem itemToRemove = _repo.GetItemByName(name);
            if (itemToRemove == null)
            {
                Console.WriteLine("No menu item with that name found.");
                GoBackToMain();
            }
            else
            {
                _repo.DeleteMenuItem(itemToRemove);
            }
        }

        public void EditItem()
        {
            Console.Clear();
            int counter = 1;
            int selectedNumber = -1;
            while (selectedNumber < 1 || selectedNumber > _repo.GetMenuItems().Count)
            {                
                foreach (MenuItem item in _repo.GetMenuItems())
                {
                    Console.WriteLine($"{counter}. {item.Name}");
                    counter++;
                }
                bool validSelection = false;
                int selection = -1;
                while(!validSelection)
                {
                    Console.Write($"\nEnter number to edit indicated item: ");
                    if (int.TryParse(Console.ReadLine(),out selection))
                    {
                        validSelection = true;
                    }
                }    
                if (selection >= 1 && selection <= _repo.GetMenuItems().Count)
                {
                    selectedNumber = selection;
                }
                else
                {
                    counter = 1;
                    Console.Clear();
                }
            }
            MenuItem itemToEdit = _repo.GetMenuItems()[selectedNumber - 1];
            Console.Clear();
            Console.WriteLine($"What do you wish to edit: \n" +
                $"1. Name\n" +
                $"2. Description\n" +
                $"3. Ingredients\n" +
                $"4. Price\n" +
                $"5. Menu item number"
                );
            string propertyToEdit = Console.ReadLine();
            switch (propertyToEdit)
            {
                case "1":
                    Console.WriteLine("Enter new name: ");
                    string newName = Console.ReadLine();
                    itemToEdit.Name = newName;
                    break;
                case "2":
                    Console.WriteLine("Enter new description: ");
                    string newDescription = Console.ReadLine();
                    itemToEdit.Description = newDescription;
                    break;
                case "3":
                    List<string> newIngredients = GetIngredientList();
                    itemToEdit.Ingredients = newIngredients;
                    break;
                case "4":
                    bool validPrice = false;
                    decimal price;
                    while (!validPrice)
                    {
                        Console.Write("\nEnter new item price: ");
                        if (decimal.TryParse(Console.ReadLine(), out price))
                        {
                            validPrice = true;
                            itemToEdit.Price = price;
                        }
                    }
                    break;
                case "5":
                    bool validMenuNumber = false;
                    int itemNumber;
                    while (!validMenuNumber)
                    {
                        Console.Write("\nEnter menu item number: ");
                        if (int.TryParse(Console.ReadLine(), out itemNumber))
                        {
                            validMenuNumber = true;
                            itemToEdit.MealNumber = itemNumber; 
                        }
                    }
                    Console.WriteLine("Enter new menu item number: ");
                    break;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }

        private List<string> GetIngredientList()
        {
            bool moreIngredients = true;
            List<string> ingredients = new List<string>();
            int counter = 1;
            while (moreIngredients)
            {                
                Console.WriteLine($"\nEnter ingredient {counter} and press 'enter'. " +
                    $"If you are finished adding ingredients type 'esc' to leave.");
                string entry = Console.ReadLine();
                if (entry != "esc")
                {
                    ingredients.Add(entry);
                    counter++;
                }
                else
                {
                    moreIngredients = false;
                }
            }
            return ingredients;
        }

        public void GoBackToMain()
        {
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
        }

        public void Seed()
        {
            MenuItem pizza = new MenuItem("Pizza", "New York style thin crust pizza with pepperoni",
                new List<string> { "cheese", "tomato sauce", "pepperoni" }, 7.99m, 1);

            MenuItem blt = new MenuItem("BLT", "Sandwich with bacon lettuce and tomato",
                new List<string> { "bacon", "lettuce", "tomato" }, 5.99m, 2);

            MenuItem cheeseburger = new MenuItem("Cheeseburger", "Hamburger with cheese",
                new List<string> { "ground beef", "cheese", "lettuce", "onion", "tomato" }, 6.99m, 3);

            _repo.AddMenuItem(pizza);
            _repo.AddMenuItem(blt);
            _repo.AddMenuItem(cheeseburger);
        }
    }
}
