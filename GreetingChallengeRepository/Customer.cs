using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingChallengeRepository
{
    public enum CustomerType { Current=1, Past, Potential};
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }
        public int ID { get; set; }
        public string Email
        {
            get
            {
                if (Type == CustomerType.Current)
                {
                    return "Thank you for your work with us. We appreciate your loyalty. " +
                        "Here's a coupon.";
                }
                else if (Type == CustomerType.Past)
                {
                    return "It's been a long time since we've heard from you, we want you back.";
                }
                else if (Type == CustomerType.Potential)
                {
                    return "We currently have the lowest rates on Helicopter Insurance!";
                }
                else
                {
                    return null;
                }
            }
        }
        public Customer() { }
        public Customer(string firstName,string lastName, int id, CustomerType type)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = id;
            Type = type;
        }

    }
}
