using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
namespace DAL
{
   public class switchTo
    {
        public string whichDoubleTimeToString(bool[] DAYS1, double[,] HOURS1, int place)
        {//puts doublexdouble array into string
            string help1 = "";
            for (int i = 0; i < 6; i++)
            {
                if (DAYS1[i] == true)
                {
                    help1 = help1 + HOURS1[i, place] + ",";

                }
                else
                {
                    help1 = help1 + -1 + ",";
                }
            }
            return help1;
        }
        public string whichDoubleTimeToString(double[] HOURS1)
        {//puts double array into string
            string help1 = "";
            for (int i = 0; i < 6; i++)
            {
                help1 = help1 + HOURS1[i] + ",";
            }
            return help1;
        }
        public string whichBoolTimeToString(bool[] DAYS1)
        {//puts bool array into string
            string help1 = "";
            for (int i = 0; i < 6; i++)
            {
                if (DAYS1[i] == true)
                {
                    help1 = help1 + "1" + ",";

                }
                else
                {
                    help1 = help1 + "0" + ",";
                }
            }
            return help1;
        }
    }
    public static class ExtensionBE
    {
        public static XElement ToXML(this Child C)
        {//converts child to xelement
			switchTo B = new switchTo();
			XElement res = new XElement("Child",
										new XElement("id", C.ChildId),
										new XElement("MotherID", C.ChildMotherId),
										new XElement("ChildName", C.ChildFirstName),
										new XElement("ChildDateOfBirth", C.ChildDateOfBirth),
										new XElement("ChildSpecialNeeds", C.ChildWithSpecialNeeds),
										new XElement("SpecialNeeds", (from need in C.ChildsSpecialNeedsList
																	  select new XElement("need", need))));
            return res;
        }
        public static XElement ToXML(this Mother M)
        {//converts mother to xelement
            switchTo B = new switchTo();
            XElement res = new XElement("Mother",
                                        new XElement("id", M.MotherId),
                                        new XElement("FirstName", M.MotherFirstName),
                                        new XElement("LastName", M.MotherLastName),
                                        new XElement("PhoneNumber", M.MotherPhoneNumber),
                                        new XElement("Address", M.MotherAddress),
                                        new XElement("Area", M.MotherNannyInArea),
                                        new XElement("Notes", M.MotherNotes),
                                        new XElement("StartTime", B.whichDoubleTimeToString(M.MotherNeedsNanny, M.MotherTimeNeedsNanny, 0)),
                                        new XElement("EndTime", B.whichDoubleTimeToString(M.MotherNeedsNanny, M.MotherTimeNeedsNanny, 1)),
                                        new XElement("Days", B.whichBoolTimeToString(M.MotherNeedsNanny)));

            return res;
        }
        public static XElement ToXML(this Nanny N)
        {//converts nanny to xelement
            switchTo B = new switchTo();
            XElement res = new XElement("Nanny",
                                        new XElement("id", N.NannyId),
                                        new XElement("FirstName", N.NannyFirstName),
                                        new XElement("LastName", N.NannyLastName),
                                        new XElement("PhoneNumber", N.NannyPhoneNumber),
                                        new XElement("Address", N.NannyAddress),
                                        new XElement("DateOfBirth", N.NannyDateOfBirth),
                                        new XElement("Floor", N.NannyFloor),
                                        new XElement("Elevator", N.NannyHaveElevator),
                                        new XElement("MaxAgeOfKid", N.NannyMaxAgeOfKid_InMonth),
                                        new XElement("MaxNumberOfKids", N.NannyMaxNumberOfKids),
                                        new XElement("MinAgeOfKid", N.NannyMinAgeOfKid_InMonth),
                                        new XElement("Experience", N.NannyNumberOfExperience),
                                        new XElement("PaymentPerHour", N.NannyPaymentPerHour),
                                        new XElement("AllowsPaymentByHour", N.NannyAllowsPaymentByHour),
                                        new XElement("PaymentPermonth", N.NannyPaymentPermonth),
                                        new XElement("Vaction", N.NannyVactionByMEducation),
                                        new XElement("StartTime", B.whichDoubleTimeToString(N.NannyIsWorkingOnDay, N.NannyTimeIsWorkingOnDay, 0)),
                                        new XElement("EndTime", B.whichDoubleTimeToString(N.NannyIsWorkingOnDay, N.NannyTimeIsWorkingOnDay, 1)),
                                        new XElement("Days", B.whichBoolTimeToString(N.NannyIsWorkingOnDay)),
                                        new XElement("Recommendations", (from item in N.NannyRecommendations
                                                                         select new XElement("Recommendations", item))));



            return res;
        }
        public static XElement ToXML(this Contract C)
        {//converts contract to xelement
            switchTo B = new switchTo();
            XElement res = new XElement("Contract",
                                        new XElement("Motherid", C.MotherId),
                                        new XElement("Nannyid", C.NannyId),
                                        new XElement("Childid", C.ChildId),
                                        new XElement("NumberOfContract", C.NumberOfContract),
                                        new XElement("Distance", C.Distance),
                                        new XElement("HaveTheyMet", C.HaveTheyMet),
                                        new XElement("IsPymentPerHour", C.IsPymentPerHour),
                                        new XElement("PaymentPerHour", C.PaymentPerHour),
                                        new XElement("PaymentPermonth", C.PaymentPermonth),
                                        new XElement("StartOfemployment", C.StartOfemploymentDate),
                                        new XElement("EndOfemployment", C.EndOfemploymentDate),
                                        new XElement("signed", C.HaveTheysignedContract),
                                        new XElement("WorkTime", B.whichDoubleTimeToString(C.TimeNannyWorkingWeek)));
            return res;
        }
    }
}
