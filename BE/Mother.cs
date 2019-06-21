using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        private int motherId;
        private string motherLastName;
        private string motherFirstName;
        private string motherPhoneNumber;
        private string motherAddress;
        private double motherNannyInArea;
        private bool[] motherNeedsNanny = new bool[6];
        private double[,] motherTimeNeedsNanny = new double[6, 2];
        private string motherNotes;
        //get and set of every one:
        public int MotherId
        {
            get
            {
                return motherId;
            }

            set
            {
                motherId = value;
            }
        }
        public string MotherLastName
        {
            get
            {
                return motherLastName;
            }

            set
            {
                motherLastName= value;
            }
        }

        public string MotherFirstName
        {
            get
            {
                return motherFirstName;
            }

            set
            {
                motherFirstName = value;
            }
        }
        public string MotherPhoneNumber
        {
            get
            {
                return motherPhoneNumber;
            }

            set
            {
                motherPhoneNumber = value;
            }
        }
        public string MotherAddress
        {
            get
            {
                return motherAddress;
            }

            set
            {
                motherAddress = value;
            }
        }
        public double MotherNannyInArea
        {
            get
            {
                return motherNannyInArea;
            }

            set
            {
                motherNannyInArea = value;
            }
        }
        public string MotherNotes
        {
            get
            {
                return motherNotes;
            }

            set
            {
                motherNotes = value;
            }
        }

        public bool[] MotherNeedsNanny
        {
            get
            {
                return motherNeedsNanny;
            }
            set
            {
                for (int i = 0; i < 6; i++)
                {
                    motherNeedsNanny[i] = value[i];

                }
            }
        }
        public double[,] MotherTimeNeedsNanny
        {
            get
            { return motherTimeNeedsNanny; }
            set
            {
                for (int i = 0; i < 6; i++)
                {

                    motherTimeNeedsNanny[i, 0] = value[i, 0];
                    motherTimeNeedsNanny[i, 1] = value[i, 1];
                }
            }
        }

       /* public Mother()
        {

        }*/
        
        public override string ToString()
        {//returns mothers first and last name
            return MotherFirstName + MotherLastName;
        }
    }
}
