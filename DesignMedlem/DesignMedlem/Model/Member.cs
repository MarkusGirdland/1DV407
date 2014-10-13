using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMedlem.Model
{
    public class Member
    {
        private string _firstName;
        private string _lastName;
        private int _socialSecurityNumber;
        private int _memberNumber;
        private int _numberOfBoats;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
            }
        }

        public int NumberOfBoats
        {
            get { return _numberOfBoats; }
            set
            {
                _numberOfBoats = value;
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
            }
        }

        public int SocialSecurityNumber
        {
            get { return _socialSecurityNumber; }
            set
            {
                _socialSecurityNumber = value;
            }
        }

        public int MemberNumber
        {
            get { return _memberNumber; }
            set
            {

                if (value < 0)
                {
                    throw new ArgumentException("Inte ett tillåtet nummer");
                }


                _memberNumber = value;
            }
        }

        public void CreateMemberNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000, 99999);

            this._memberNumber = randomNumber;
        }


        public string PrintCompact()
        {
            string returnString;

            returnString = String.Format("\nNamn:\t\t{0}\nEfternamn:\t{1}\nMedlemsnummer\t{2}\nAntal båtar:\t{3}", _firstName, _lastName, _memberNumber, _numberOfBoats);

            return returnString;
        }

        public string PrintFull()
        {
            string returnString;

            returnString = String.Format("\nNamn:\t\t{0}\nEfternamn:\t{1}\nPersonnummer:\t{2}\nMedlemsnummer:\t{3}", _firstName, _lastName, _socialSecurityNumber, _memberNumber);

            return returnString;
        }

        public Member()
        {
            this._firstName = "John";
            this._lastName = "Doe";
            this._memberNumber = 00000;
            this._socialSecurityNumber = 000000;
            this._numberOfBoats = 0;
        }
    }
}
