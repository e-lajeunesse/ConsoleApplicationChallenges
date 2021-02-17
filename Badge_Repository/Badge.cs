using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> Doors { get; } = new List<string>();
        public Badge() { }
        public Badge(int id,List<string> doors)
        {
            BadgeID = id;
            Doors = doors;
        }
    }
}
