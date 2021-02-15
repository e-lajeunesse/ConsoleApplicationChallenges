using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Repository
{
    public enum ClaimType { Car, Home, Theft}
    public class Claim
    {
        public int ClaimID {get;set;}
        public ClaimType ClaimType { get; set; }
        public string description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                return Convert.ToInt32(DateOfClaim - DateOfIncident) <= 30;
            }
        }
    }
}
