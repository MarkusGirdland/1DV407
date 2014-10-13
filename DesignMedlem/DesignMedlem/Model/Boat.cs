using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMedlem.Model
{
    public class Boat
    {
        private int _type;
        private int _length;
        private int _ownedBy;

        public int Type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }

        public int OwnedBy
        {
            get { return _ownedBy; }
            set
            {
                _ownedBy = value;
            }
        }

        public int Length
        {
            get { return _length; }
            set
            {
                _length = value;
            }
        }

        public string BoatToString()
        {
            string returnString;
            string type = "";

                if(this._type == 1)
                {
                    type = "Segelbåt";
                }

                if(this._type == 2)
                {
                    type = "Motorseglare";
                }

                if(this._type == 3)
                {
                    type = "Motorbåt";
                }

                if(this._type == 4)
                {
                    type = "Kajak/Kanot";
                }

                if(this._type == 5)
                {
                    type = "Övrigt";
                }

            returnString = String.Format("\nBåttyp:\t\t{0}\nLängd:\t\t{1}", type, _length);

            return returnString;
        }

        public string BoatToStringFull()
        {
            string returnString;
            string type = "";

            if (this._type == 1)
            {
                type = "Segelbåt";
            }

            if (this._type == 2)
            {
                type = "Motorseglare";
            }

            if (this._type == 3)
            {
                type = "Motorbåt";
            }

            if (this._type == 4)
            {
                type = "Kajak/Kanot";
            }

            if (this._type == 5)
            {
                type = "Övrigt";
            }

            returnString = String.Format("\nBåttyp:\t\t{0}\nLängd:\t\t{1}\nÄgare:\t\t{2}", type, _length, _ownedBy);

            return returnString;
        }

        public Boat()
        {
            this._length = 0;
            this._type = 0;
            this._ownedBy = 0;
        }
    }

   
}
