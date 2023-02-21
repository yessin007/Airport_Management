using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public int PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public int TelNumber { get; set; }
        public ICollection<Flight> FlightsPassenger { get; set; }
        public override string ToString()
        {
            return this.FirstName+"  "+this.LastName;
        }

        public bool CheckProfile(string FN, string LN)
        {
            if (this.FirstName.Equals(FN) && this.LastName.Equals(LN))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckProfile1(string FN, string LN, string email)
        {
            if (this.FirstName.Equals(FN) && this.LastName.Equals(LN) && this.EmailAddress.Equals(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckProfile2(int num)
        {
            if (this.TelNumber == num)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }



    }
}
