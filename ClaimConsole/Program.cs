using Claim_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaimUI ui = new ClaimUI();
            ui.Seed();
            ui.RunUI();
        }
    }
}
