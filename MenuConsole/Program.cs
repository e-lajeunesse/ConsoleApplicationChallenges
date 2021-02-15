using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuUI ui = new MenuUI();
            ui.Seed();
            ui.RunUI();
        }
    }
}
