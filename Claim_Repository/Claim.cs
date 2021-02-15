using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Repository
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                return (DateOfClaim - DateOfIncident).TotalDays <= 30;
            }
        }

        public Claim() { }
        public Claim(int id, ClaimType type, string description,
            decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = id;
            ClaimType = type;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
