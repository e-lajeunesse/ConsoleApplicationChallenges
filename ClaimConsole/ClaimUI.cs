using Claim_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimConsole
{
    public class ClaimUI
    {
        private ClaimRepository _repo = new ClaimRepository();
        public void RunUI()
        {
            bool keepRunning = true;
            while(keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Choose a menu item: \n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "0. Exit");

                string selection = Console.ReadLine();
                switch (selection)
                {
                    case "1":
                        Console.Clear();
                        _repo.DisplayClaims();
                        Console.ReadKey();
                        break;
                    case "2":
                        NextClaim();
                        break;
                    case "3":
                        NewClaim();
                        break;
                    case "0":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Entry");
                        break;                      
                }
            }
        }

        public void NextClaim()
        {
            Claim nextClaim = _repo.GetClaims()[0];
            Console.Clear();
            Console.WriteLine($"ClaimID: {nextClaim.ClaimID}\n" +
                $"Type: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Amount: ${nextClaim.ClaimAmount}\n" +
                $"Date of Incident: {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                $"Date of Claim: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                $"IsValid: {nextClaim.IsValid}\n");
            
            bool validSelection = false;
            while(!validSelection)
            {
                Console.Write("Do you want to deal with this claim now(y/n)? ");
                string selection = Console.ReadLine().ToUpper();
                if (selection =="Y")
                {
                    _repo.DeleteClaim(nextClaim);
                    validSelection = true;
                }
                else if (selection == "N")
                {
                    validSelection = true;
                }
                else
                {
                    Console.WriteLine("Invalid Entry");
                }
            }
        }

        public void NewClaim()
        {
            Console.Clear();
            Claim claim = new Claim();
            bool validIncidentDate = false;
            bool validClaimDate = false;

            Console.Write("Enter Claim ID: ");
            claim.ClaimID = int.Parse(Console.ReadLine());

            Console.Write($"\nSelect Claim Type: Enter 1 for {ClaimType.Car}, 2 for {ClaimType.Home}, " +
                $"3 for {ClaimType.Theft}: " );
            int claimTypeSelection = int.Parse(Console.ReadLine());
            claim.ClaimType = (ClaimType)claimTypeSelection;

            Console.Write("\nEnter description: ");
            claim.Description = Console.ReadLine();

            Console.Write("\nEnter claim amount: ");
            claim.ClaimAmount = decimal.Parse(Console.ReadLine());
            
            while(!validIncidentDate)
            {
                Console.Write("\nEnter date of incident(yyyy-mm-dd): ");
                string dateString = Console.ReadLine();
                DateTime dateOfIncident;
                if (DateTime.TryParse(dateString,out dateOfIncident))
                {
                    claim.DateOfIncident = dateOfIncident;
                    validIncidentDate = true;
                }
                else
                {
                    Console.WriteLine("Invalid format for date");
                }
            }

            while(!validClaimDate)
            {
                Console.Write("\nEnter date of claim(yyyy-mm-dd): ");
                string dateString = Console.ReadLine();
                DateTime dateOfClaim;
                if (DateTime.TryParse(dateString, out dateOfClaim))
                {
                    claim.DateOfIncident = dateOfClaim;
                    validClaimDate = true;
                }
                else
                {
                    Console.WriteLine("Invalid format for date");
                }
            }

            Console.WriteLine($"\nBased on the entered dates this claim is: " +
                $"{(claim.IsValid? "Valid" : "Not Valid")}");
            Console.WriteLine($"\n{(_repo.AddClaim(claim)? "Claim successfully added" : "Unable to add claim")}");            
            Console.ReadKey();
        }
        public void Seed()
        {            
            Claim claim1 = new Claim(1, ClaimType.Car, "car accident on HWY Y", 1400m,
                new DateTime(2020, 12, 20), new DateTime(2020, 12, 27));
            _repo.AddClaim(claim1);

            Claim claim2 = new Claim(2, ClaimType.Home, "fire in kitchen", 800m,
                new DateTime(2020, 10, 29), new DateTime(2020, 12, 22));
            _repo.AddClaim(claim2);
        }
    }
}
