using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyOutingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            OutingUI ui = new OutingUI();
            ui.Seed();
            ui.RunUI();
        }
    }
}
