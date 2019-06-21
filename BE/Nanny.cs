using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        private int nannyId;
        private string nannyLastName;
        private string nannyFirstName;
        private DateTime nannyDateOfBirth;
        private int nannyPhoneNumber;
        private string nannyAddress;
        private bool nannyHaveElevator;
        private int nannyFloor;
        private int nannyNumberOfExperience;
        private int nannyMaxNumberOfKids;
        private int nannyMinAgeOfKid_InMonth;
        private int nannyMaxAgeOfKid_InMonth;
        private bool nannyAllowsPaymentByHour;
        private double nannyPaymentPerHour;
        private double nannyPaymentPermonth;
        private bool[] nannyIsWorkingOnDay = new bool[6];
        private double[,] nannyTimeIsWorkingOnDay = new double[6, 2];
        private bool nannyVactionByMEducation;
        private List<string> nannyRecommendations = new List<string>();
        //get and set of every one:
        public int NannyId
        {
            get
            {
                return nannyId;
            }

            set
            {
                nannyId = value;
            }
        }
        public string NannyLastName
        {
            get
            {
                return nannyLastName;
            }

            set
            {
                nannyLastName = value;
            }
        }
        public string NannyFirstName
        {
            get
            {
                return nannyFirstName;
            }

            set
            {
                nannyFirstName = value;
            }
        }
        public DateTime NannyDateOfBirth
        {
            get
            {
                return nannyDateOfBirth;
            }

            set
            {
                nannyDateOfBirth = value;
            }
        }
        public int NannyPhoneNumber
        {
            get
            {
                return nannyPhoneNumber;
            }

            set
            {
                nannyPhoneNumber = value;
            }
        }
        public string NannyAddress
        {
            get
            {
                return nannyAddress;
            }

            set
            {
                nannyAddress = value;
            }
        }
        public bool NannyHaveElevator
        {
            get
            {
                return nannyHaveElevator;
            }

            set
            {
                nannyHaveElevator = value;
            }
        }
        public int NannyFloor
        {
            get
            {
                return nannyFloor;
            }

            set
            {
                nannyFloor = value;
            }
        }
        public int NannyNumberOfExperience
        {
            get
            {
                return nannyNumberOfExperience;
            }

            set
            {
                nannyNumberOfExperience = value;
            }
        }
        public int NannyMaxNumberOfKids
        {
            get
            {
                return nannyMaxNumberOfKids;
            }

            set
            {
                nannyMaxNumberOfKids = value;
            }
        }
        public int NannyMinAgeOfKid_InMonth
        {
            get
            {
                return nannyMinAgeOfKid_InMonth;
            }

            set
            {
                nannyMinAgeOfKid_InMonth = value;
            }
        }
        public int NannyMaxAgeOfKid_InMonth
        {
            get
            {
                return nannyMaxAgeOfKid_InMonth;
            }

            set
            {
                nannyMaxAgeOfKid_InMonth = value;
            }
        }
        public bool NannyAllowsPaymentByHour
        {
            get
            {
                return nannyAllowsPaymentByHour;
            }

            set
            {
                nannyAllowsPaymentByHour = value;
            }
        }
        public double NannyPaymentPerHour
        {
            get
            {
                return nannyPaymentPerHour;
            }

            set
            {
                nannyPaymentPerHour = value;
            }
        }
        public double NannyPaymentPermonth
        {
            get
            {
                return nannyPaymentPermonth;
            }

            set
            {
                nannyPaymentPermonth = value;
            }
        }
        public bool NannyVactionByMEducation
        {
            get
            {
                return nannyVactionByMEducation;
            }

            set
            {
                nannyVactionByMEducation = value;
            }
        }

        public bool[] NannyIsWorkingOnDay
        {
            get
            {
                bool[] b = new bool[6];
                for (int i = 0; i < 6; i++)
                {

                    b[i] = nannyIsWorkingOnDay[i];
                }
                return b;
            }
            set
            {
                for (int i = 0; i < 6; i++)
                {
                    nannyIsWorkingOnDay[i] = value[i];

                }
            }
        }

        public double[,] NannyTimeIsWorkingOnDay
        {
            get
            {
                double[,] b = new double[6,2];
                for (int i = 0; i < 6; i++)
                {

                    b[i,0] = nannyTimeIsWorkingOnDay[i, 0];
                    b[i, 1] = nannyTimeIsWorkingOnDay[i, 1];
                }
                return b;
            }
            set
            {
                for (int i = 0; i < 6; i++)
                {

                    nannyTimeIsWorkingOnDay[i, 0] = value[i, 0];
                    nannyTimeIsWorkingOnDay[i, 1] = value[i, 1];
                }
            }
        }

        public List<string> NannyRecommendations { get { return nannyRecommendations; } set { nannyRecommendations = value; } }

        public override string ToString()
        {//returns nanny first and last names
            return NannyFirstName + NannyLastName;
        }
    }
}
