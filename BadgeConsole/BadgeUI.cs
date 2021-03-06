﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Badge_Repository;

namespace BadgeConsole
{
    public class BadgeUI
    {
        private readonly BadgeRepository _repo = new BadgeRepository();
        public void RunUI()
        {
            bool keepRunning = true;
            while(keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Hello Security Admin, What would you like to do?\n\n" +
                    "1.Add a badge\n" +
                    "2.Update a badge\n" +
                    "3.List all badges\n" +
                    "0.Exit\n");
                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":                        
                        AddBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        //Method to edit badge
                        break;
                    case "3":
                        Console.Clear();
                        _repo.DisplayBadges();
                        Console.WriteLine("\nPress any key to go back to main menu");
                        Console.ReadKey();
                        break;
                    case "0":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }     
            }
        }

        public void AddBadge()
        {
            Console.Clear();
            Badge badgeToAdd = new Badge();
            bool validID = false;
            int id;
            while (!validID)
            {
                Console.Write("Enter Badge ID: ");
                if (int.TryParse(Console.ReadLine(),out id))
                {
                    badgeToAdd.BadgeID = id;
                    validID = true;
                }
                else
                {
                    Console.WriteLine("Invalid entry, ID should be a number.");
                }
            }
            bool keepAddingDoors = true;
            while(keepAddingDoors)
            {
                Console.Write("\nEnter a door the badge requires access to: ");
                badgeToAdd.Doors.Add(Console.ReadLine());
                string doorEntry = "";
                while(doorEntry != "Y" && doorEntry != "N")
                {
                    Console.Write("\nDo you want to add another door (y/n)? ");
                    doorEntry = Console.ReadLine().ToUpper();
                    if (doorEntry == "N")
                    {
                        keepAddingDoors = false;
                    }
                }                 
            }
            _repo.AddNewBadge(badgeToAdd);
            Console.WriteLine("\nBadge successfully added. Press any key to return to main menu.");
            Console.ReadKey();
        }

        public void UpdateBadge()
        {
            Console.Clear();
            int id = -1;
            bool validBadgeID = false;
            while(!validBadgeID)
            {
                bool validBadgeIDEntry = false;
                while (!validBadgeIDEntry)
                {
                    Console.Write("Enter Badge ID number to update, or type 'esc' to go back to main menu: ");
                    string idEntry = Console.ReadLine().ToUpper();
                    if (idEntry == "ESC")
                    {
                        return;
                    }
                    if (int.TryParse(idEntry,out id))
                    {
                        validBadgeIDEntry = true;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid entry, the badge ID should be a number.\n");
                    }
                }                
                if (_repo.GetBadges.ContainsKey(id))
                {
                    validBadgeID = true;
                }
                else
                {
                    Console.WriteLine("\nUnable to find badge with that ID number.\n");
                }
            }
            bool validSelection = false;
            while(!validSelection)
            {
                Console.Clear();
                Console.WriteLine($"Badge {id} has access to doors {_repo.ListOfDoorsString(id)}\n");
                Console.WriteLine("What would you like to do?\n" +
                    "   1. Add access to a door\n" +
                    "   2. Remove access to a door\n" +
                    "   3. Remove access to all doors\n");
                string updateSelection = Console.ReadLine();
                switch (updateSelection)
                {
                    case "1":
                        Console.Write("\nEnter door you want to grant access to: ");
                        string doorToGrantAccess = Console.ReadLine();
                        _repo.AddDoor(id, doorToGrantAccess);
                        Console.WriteLine($"\nAccess to door {doorToGrantAccess} granted" +
                            $" press any key to go back to main menu.");
                        Console.ReadKey();
                        validSelection = true;
                        break;
                    case "2":
                        bool validDoor = false;                    
                        while(!validDoor)
                        {
                            Console.Write("\nEnter door you want to remove: ");
                            string doorToRemove = Console.ReadLine();
                            if (_repo.GetBadges[id].Contains(doorToRemove))
                            {
                                _repo.RemoveDoor(id, doorToRemove);
                                Console.WriteLine($"\nAccess to door {doorToRemove} removed. " +
                                    $"Press any key to go back to main menu.");
                                validDoor = true;
                            }
                            else
                            {
                                Console.WriteLine($"\nBadge {id} doesn't have access to door {doorToRemove}, or the door " +
                                    $"doesn't exist.\n" +
                                    $"Type 'esc' to go back to main menu, or press the enter key to select a different door.");
                                string userChoice = Console.ReadLine().ToUpper();
                                if (userChoice == "ESC")
                                {
                                    validDoor = true;
                                }
                            }
                        }
                        Console.ReadKey();
                        validSelection = true;
                        break;
                    case "3":
                        _repo.RemoveAllDoors(id);
                        Console.WriteLine("\nRemoved access to all doors. Press any key to go" +
                            " back to main menu.");
                        Console.ReadKey();
                        validSelection = true;
                        break;
                    default:
                        Console.WriteLine("Invalid entry");
                        break;
                }                
            }
        }

        public void Seed()
        {
            Badge badge1 = new Badge(123, new List<string> { "A1", "A2" });
            Badge badge2 = new Badge(456, new List<string> { "B1", "B2" });            
            _repo.AddNewBadge(badge1);
            _repo.AddNewBadge(badge2);
        }
    }
}
