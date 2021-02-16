using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BadgeUI ui = new BadgeUI();
            ui.Seed();
            ui.RunUI();
        }
    }
}
