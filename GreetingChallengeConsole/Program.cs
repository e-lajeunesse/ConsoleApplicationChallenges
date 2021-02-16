using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingChallengeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GreetingUI ui = new GreetingUI();
            ui.Seed();
            ui.RunUI();
        }
    }
}
