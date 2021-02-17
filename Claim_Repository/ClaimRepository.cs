using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim_Repository
{
    public class ClaimRepository
    {
        private readonly List<Claim> _directory = new List<Claim>();

        public ClaimRepository() { }

        public bool AddClaim(Claim claim)
        {
            int startingCount = _directory.Count;
            _directory.Add(claim);
            return _directory.Count == startingCount + 1;
        }

        public List<Claim> GetClaims()
        {
            return _directory;
        }

        public void DisplayClaims()
        {
            Console.WriteLine("Claim ID      Type            Description                        Amount" +
                "       DateOfIncident" +
                "    DateOfClaim    IsValid");
            foreach(Claim claim in _directory)
            {
                Console.WriteLine($"{claim.ClaimID,-13} {claim.ClaimType,-15} {claim.Description,-35}" +
                    $"${claim.ClaimAmount,-11} {claim.DateOfIncident.ToShortDateString(),-18}" +
                    $"{claim.DateOfClaim.ToShortDateString(),-14} {claim.IsValid}");
            }
        }

        public bool DeleteClaim(Claim claim)
        {
            return _directory.Remove(claim);
        }

        public Claim GetClaimByID(int id)
        {
            foreach(Claim claim in _directory)
            {
                if (claim.ClaimID == id)
                {
                    return claim;
                }
            }
            Console.WriteLine("Unable to locate claim with that ID");
            return null;
        }
    }
}
