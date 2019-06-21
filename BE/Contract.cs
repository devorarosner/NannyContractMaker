using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public static int NumberStatic = 1000;
        private int numberOfContract;
        private int nannyId;
        private int motherId;
        private int childId;
        private bool haveTheyMet;
        private bool haveTheysignedContract;
        private double paymentPerHour;
        private double paymentPermonth;
        private bool isPymentPerHour;
        private int distance;
        private double[] timeNannyWorkingWeek = new double[6];
        private string startOfemploymentDate;
        private string endOfemploymentDate;
        //get and set of every one:
        public int getNumber()
        {
            return NumberOfContract;
        }
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
        public int ChildId
        {
            get
            {
                return childId;
            }

            set
            {
                childId = value;
            }
        }
        public bool HaveTheyMet
        {
            get
            {
                return haveTheyMet;
            }

            set
            {
                haveTheyMet = value;
            }
        }
        public bool HaveTheysignedContract
        {
            get
            {
                return haveTheysignedContract;
            }

            set
            {
                haveTheysignedContract = value;
            }
        }
        public double PaymentPerHour
        {
            get
            {
                return paymentPerHour;
            }

            set
            {
                paymentPerHour = value;
            }
        }
        public double PaymentPermonth
        {
            get
            {
                return paymentPermonth;
            }

            set
            {
                paymentPermonth = value;
            }
        }
        public string StartOfemploymentDate
        {
            get
            {
                return startOfemploymentDate;
            }

            set
            {
                startOfemploymentDate = value;
            }
        }
        public string EndOfemploymentDate
        {
            get
            {
                return endOfemploymentDate;
            }

            set
            {
                endOfemploymentDate = value;
            }
        }

        public bool IsPymentPerHour
        {
            get { return isPymentPerHour; }
            set { isPymentPerHour = value; }
        }
        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }
        public int NumberOfContract
        {
            get { return numberOfContract; }
            set { numberOfContract = value; }
        }

        public double[] TimeNannyWorkingWeek
        {
            get
            {
                return timeNannyWorkingWeek;
            }
            set
            {
                for (int i = 0; i < 6; i++)
                {
                    timeNannyWorkingWeek[i] = value[i];

                }
            }
        }

        public Contract()
        {
            NumberOfContract = NumberStatic;
            NumberStatic++;
        }
        public override string ToString()
        {
            return NumberOfContract.ToString();
        }
    }
}

