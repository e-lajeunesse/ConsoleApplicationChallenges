using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Repository
{
    public class BadgeRepository
    {
        private readonly Dictionary<int, List<string>> _directory = new Dictionary<int, List<string>>();

        public Dictionary<int,List<string>> GetBadges
        {
            get
            {
                return _directory;
            }
        }

        public bool AddNewBadge(Badge badge)
        {
            _directory[badge.BadgeID] = badge.Doors;
            return _directory.ContainsKey(badge.BadgeID);
        }

        public bool AddDoor(int badgeID, string door)
        {
            int startingCount = _directory[badgeID].Count;
            _directory[badgeID].Add(door);
            return _directory[badgeID].Count == startingCount + 1;
        }

        public bool RemoveDoor(int badgeID, string door)
        {
            return _directory[badgeID].Remove(door);
        }

        public bool RemoveAllDoors(int badgeID)
        {
            if(_directory.ContainsKey(badgeID))
            {
                _directory[badgeID].Clear();
                return _directory[badgeID].Count == 0;
            }
            else
            {
                return false;
            }
        }

        public void DisplayBadges()
        {
            
            foreach(int key in _directory.Keys)
            {
                Console.Write("Badge ID: ");
                Console.WriteLine(key);
                Console.Write("Door access: ");                
                Console.WriteLine(ListOfDoorsString(key)+ "\n");
            }
            
        }

        //method to get list of all doors for a badge as a single string
        public string ListOfDoorsString(int badgeID)
        {
            return _directory[badgeID].Count == 0? "none" : string.Join(", ", _directory[badgeID]);
        }
    }
}
