using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace DAL
{
    class Dal_XML_imp : Idol
    {
        private double[,] switchStringToDouble(string starttimes, string endtimes)//A function that converts matrix from string to double
        {
            double[,] help = new double[6, 2];
            int j = 0;
            string a = "";
            for (int i = 0; i < starttimes.Count(); i++)
            {
                if (starttimes[i] != ',')
                {
                    a = a + starttimes[i];
                }
                if (starttimes[i] == ',')
                {
                    help[j, 0] = double.Parse(a);
                    a = "";
                    j++;
                }
            }
            j = 0;
            a = "";
            for (int i = 0; i < endtimes.Count(); i++)
            {
                if (endtimes[i] != ',')
                {
                    a = a + endtimes[i];
                }
                if (endtimes[i] == ',')
                {
                    help[j, 1] =double.Parse(a);
                    a = "";
                    j++;
                }
            }
            return help;
        }
        private double[] switchStringToDouble(string starttimes)//A function that converts array from string to double
        {
            double[] help = new double[6];
            int j = 0;
            string a = "";
            for (int i = 0; i < starttimes.Count() && j < 6; i++)
            {
                if (starttimes[i] != ',')
                {
                    a = a + starttimes[i];
                }
                if (starttimes[i] == ',')
                {
                    help[j] = double.Parse(a);
                    a = "";
                    j++;
                }
            }
            return help;
        }
        private bool[] switchStringToBool(string days)//A function that converts array from string ("0"/"1") to bool
        {
            bool[] help = new bool[6];
            for (int i = 0; i < days.Count(); i = i + 2)
            {
                if (days[i] == '0')
                    help[i / 2] = false;
                else
                    help[i / 2] = true;
            }
            return help;
        }

        public void AddNanny(BE.Nanny N)
        {//adds nanny to list after checking that he does not exist already
            XElement root = BasicXML.LoadData();
            if (checkNanny(N) == true)
                throw new Exception("nanny already exists");
            root.Add(ExtensionBE.ToXML(N));
            BasicXML.Save(root);
        }
        public void RemoveNanny(BE.Nanny N)
        {//removes nanny from program
            XElement root = BasicXML.LoadData();
            XElement help = null;

            help = (from item in root.Elements()
                    where item.Name == "Nanny"
                    where int.Parse(item.Element("id").Value) == N.NannyId
                    select item).FirstOrDefault();
            help.Remove();
            BasicXML.Save(root);
            foreach (BE.Contract item in GetListOfContracts())//deletes all contracts that nanny is in
            {
                if (N.NannyId == item.NannyId)
                    RemoveContract(item);
            }

        }
        public void ChangeInfoNanny(BE.Nanny N)
        //A function that gets nanny after its details have been updated
        //The function finds the nanny in the database in the xml file before the update,
        //deletes it from the list and adds the nanny after the update
        {
            XElement root = BasicXML.LoadData();
            XElement help;
            help = (from item in root.Elements()
					where item.Name == "Nanny"
					where int.Parse(item.Element("id").Value) == N.NannyId
                    select item).FirstOrDefault();
            help.Remove();
			root.Add(ExtensionBE.ToXML(N));
			BasicXML.Save(root);
        }

        public void AddMother(BE.Mother M)
        {//adds mother to list after checking that he does not exist already
            XElement root = BasicXML.LoadData();
            if (checkMother(M) == true)
                throw new Exception("mother already exists");
			root.Add(ExtensionBE.ToXML(M));
            BasicXML.Save(root);
        }
        public void RemoveMother(BE.Mother M)
        {//removes mother from program
			
				XElement root = BasicXML.LoadData();
				XElement help=null;
			
				help = (from item in root.Elements()
						where item.Name == "Mother"
						where int.Parse(item.Element("id").Value) == M.MotherId
						select item).FirstOrDefault();
			    help.Remove();


			BasicXML.Save(root);
			foreach (BE.Contract item in GetListOfContracts())//deletes all contracts that mother is in
				{
					if (M.MotherId == item.MotherId)
						RemoveContract(item);
				}
				foreach (BE.Child item in GetListOfChildS())//deletes all childs that M is there mother
				{
					if (M.MotherId == item.ChildMotherId)
						RemoveChild(item);
				}
			

		}
        public void ChangeInfoMother(BE.Mother M)
        //A function that gets Mother after its details have been updated
        //The function finds the Mother in the database in the xml file before the update,
        //deletes it from the list and adds the Mother after the update
        {
            XElement root = BasicXML.LoadData();
            XElement help;
            help = (from item in root.Elements()
					where item.Name == "Mother"
					where int.Parse(item.Element("id").Value) == M.MotherId
                    select item).FirstOrDefault();
			help.Remove();
			root.Add(ExtensionBE.ToXML(M));
			BasicXML.Save(root);
        }

        public void AddChild(BE.Child C)
        {//adds child to list after checking that he does not exist already
            XElement root = BasicXML.LoadData();
            if (checkChild(C) == true)
                throw new Exception("Child already exists");
            root.Add(ExtensionBE.ToXML(C));
            BasicXML.Save(root);
        }
		public void RemoveChild(BE.Child C)
        {//remove child from program
            XElement root = BasicXML.LoadData();
            XElement help;
            help = (from item in root.Elements()
					where item.Name == "Child"
					where int.Parse(item.Element("id").Value) == C.ChildId
                    select item).FirstOrDefault();
			if (help == null)
				throw new Exception("child does not exist");
            help.Remove();
			BasicXML.Save(root);
			foreach (BE.Contract item in GetListOfContracts())//removes contracts that child is in
            {
                if (C.ChildId == item.ChildId)
                    RemoveContract(item);
            }
            
        }
        public void ChangeInfoChild(BE.Child C)
        //A function that gets Child after its details have been updated
        //The function finds the Child in the database in the xml file before the update,
        //deletes it from the list and adds the Child after the update
        {
            XElement root = BasicXML.LoadData();
            XElement help;
            help = (from item in root.Elements()
					where item.Name == "Child"
					where int.Parse(item.Element("id").Value) == C.ChildId
                    select item).FirstOrDefault();
			help.Remove();
			root.Add(ExtensionBE.ToXML(C));
			BasicXML.Save(root);

        }

        public void AddContract(BE.Contract C)
        {//checks that contract does not exist already and the nanny and child do
            XElement root = BasicXML.LoadData();
            if (checkContract(C) == true)
                throw new Exception("Contract already exists");
            bool flage = false;
            foreach (BE.Nanny item in GetListOfNannys())
            {
                if (C.NannyId == item.NannyId)
                    flage = true;
            }
            if (flage == false)
                throw new Exception("Nanny does not exist");
            foreach (BE.Child item in GetListOfChildS())
            {
                if (C.ChildId == item.ChildId)
                    flage = false;
            }
            if (flage == true)
                throw new Exception("Child does not exist");
            foreach (BE.Mother item in GetListOfMotherS())
            {
                if (C.MotherId == item.MotherId)
                    flage = true;
            }
            if (flage == false)
                throw new Exception("Mother does not exist");
            foreach (BE.Contract item in GetListOfContracts())
            {
                if (C.ChildId == item.ChildId)
                    if(item.NannyId==C.NannyId)
                       flage = false;
            }
            if (flage == false)
                throw new Exception("Contract already exist");
            root.Add(ExtensionBE.ToXML(C));
            BasicXML.Save(root);
        }
        public void RemoveContract(BE.Contract C)
        {//removes contract from list
            XElement root = BasicXML.LoadData();
            XElement help;
            help = (from item in root.Elements()
					where item.Name == "Contract"
					where int.Parse(item.Element("NumberOfContract").Value) == C.NumberOfContract
                    select item).FirstOrDefault();
            help.Remove();
            BasicXML.Save(root);
        }
        public void ChangeInfoContract(BE.Contract c)
        //A function that gets Contract after its details have been updated
        //The function finds the Contract in the database in the xml file before the update,
        //deletes it from the list and adds the Contract after the update
        {
            
            XElement root = BasicXML.LoadData();
            XElement help;
            help = (from item in root.Elements()
					where item.Name == "Contract"
					where int.Parse(item.Element("NumberOfContract").Value) == c.NumberOfContract
                    select item).FirstOrDefault();
            
            help.Remove();
			root.Add(ExtensionBE.ToXML(c));
			BasicXML.Save(root);
        }

        public List<BE.Nanny> GetListOfNannys()
        {
            //A function that returns the list of nannies.
            //The function defines a list and then passes the xml file and for each nanny copies the information to a new nanny 
            //and adds it to the list.
                        XElement root = BasicXML.LoadData();
            List<BE.Nanny> l=null;
            try
            {
                l = (from item in root.Elements()
					 where item.Name == "Nanny"
					 select new BE.Nanny()
                     {


                         NannyId = int.Parse(item.Element("id").Value),
                         NannyLastName = item.Element("LastName").Value,
                         NannyFirstName = item.Element("FirstName").Value,
                         NannyDateOfBirth = DateTime.Parse(item.Element("DateOfBirth").Value),
                         NannyPhoneNumber = int.Parse(item.Element("PhoneNumber").Value),
                         NannyAddress = item.Element("Address").Value,
                         NannyHaveElevator = bool.Parse(item.Element("Elevator").Value),
                         NannyFloor = int.Parse(item.Element("Floor").Value),
                         NannyNumberOfExperience = int.Parse(item.Element("Experience").Value),
                         NannyMaxNumberOfKids = int.Parse(item.Element("MaxNumberOfKids").Value),
                         NannyMinAgeOfKid_InMonth = int.Parse(item.Element("MinAgeOfKid").Value),
                         NannyMaxAgeOfKid_InMonth = int.Parse(item.Element("MaxAgeOfKid").Value),
                         NannyAllowsPaymentByHour = bool.Parse(item.Element("AllowsPaymentByHour").Value),
                         NannyPaymentPerHour = int.Parse(item.Element("PaymentPerHour").Value),
                         NannyPaymentPermonth = int.Parse(item.Element("PaymentPermonth").Value),
                         NannyIsWorkingOnDay = switchStringToBool(item.Element("Days").Value),
                         NannyTimeIsWorkingOnDay = switchStringToDouble(item.Element("StartTime").Value, item.Element("EndTime").Value),
                         NannyVactionByMEducation = bool.Parse(item.Element("Vaction").Value),
                         NannyRecommendations = (from item2 in item.Element("Recommendations").Elements()
                                                 select item2.Value).ToList()
                     }).ToList();
            }
            catch
            {
                l = null;
            }
            BasicXML.Save(root);
            return l;
        }
        public List<BE.Mother> GetListOfMotherS()
        //A function that returns the list of Mothers.
        //The function defines a list and then passes the xml file and for each Mother copies the information to a new Mother 
        //and adds it to the list.
        {
            XElement root = BasicXML.LoadData();
            List<BE.Mother> l=null;
			
			try
			{
				l = (from item in root.Elements()
					 where item.Name == "Mother"
					 select new BE.Mother()
					 {
				
					     MotherId = int.Parse(item.Element("id").Value),
						 MotherLastName = item.Element("FirstName").Value,
						 MotherFirstName = item.Element("LastName").Value,
						 MotherPhoneNumber = item.Element("PhoneNumber").Value,
						 MotherAddress = item.Element("Address").Value,
						 MotherNannyInArea = double.Parse(item.Element("Area").Value),
						 MotherNotes = item.Element("Notes").Value,
						 MotherTimeNeedsNanny = switchStringToDouble(item.Element("StartTime").Value, item.Element("EndTime").Value),
						 MotherNeedsNanny = switchStringToBool(item.Element("Days").Value),
					
					 }).ToList();
            }
            catch
            {
                l = null;
				
            }
			
            BasicXML.Save(root);
            return l;
        }
        public List<BE.Child> GetListOfChildS()
        //A function that returns the list of Childs.
        //The function defines a list and then passes the xml file and for each Child copies the information to a new Child 
        //and adds it to the list.
        {
            XElement root = BasicXML.LoadData();
            List<BE.Child> child=null;
            try
            {
                child = (from item in root.Elements()
						 where item.Name == "Child"
						 select new BE.Child()
                         {

                             ChildId = int.Parse(item.Element("id").Value),
							 ChildMotherId=int.Parse(item.Element("MotherID").Value),
							 ChildFirstName = item.Element("ChildName").Value,
                             ChildDateOfBirth = DateTime.Parse(item.Element("ChildDateOfBirth").Value),
                             ChildWithSpecialNeeds = bool.Parse(item.Element("ChildSpecialNeeds").Value),
                             ChildsSpecialNeedsList = (from item2 in item.Element("SpecialNeeds").Elements()
                                                       select item2.Value).ToList()
                         }).ToList();
            }
            catch
            {
                child = null;
            }
            BasicXML.Save(root);
            return child;
        }
        public List<BE.Contract> GetListOfContracts()
        //A function that returns the list of Contracts.
        //The function defines a list and then passes the xml file and for each Contract copies the information to a new Contract 
        //and adds it to the list.
        {
            XElement root = BasicXML.LoadData();
            List<BE.Contract> l;
            try
            {
                l = (from item in root.Elements()
					 where item.Name == "Contract"
					 select new BE.Contract()
                     {
                         NumberOfContract = int.Parse(item.Element("NumberOfContract").Value),
                         NannyId = int.Parse(item.Element("Nannyid").Value),
                         MotherId = int.Parse(item.Element("Motherid").Value),
                         ChildId = int.Parse(item.Element("Childid").Value),
                         HaveTheyMet = bool.Parse(item.Element("HaveTheyMet").Value),
                         HaveTheysignedContract = bool.Parse(item.Element("signed").Value),
                         PaymentPerHour = int.Parse(item.Element("PaymentPerHour").Value),
                         PaymentPermonth = int.Parse(item.Element("PaymentPermonth").Value),
                         IsPymentPerHour = bool.Parse(item.Element("IsPymentPerHour").Value),
                         Distance = int.Parse(item.Element("Distance").Value),
                         TimeNannyWorkingWeek = switchStringToDouble(item.Element("WorkTime").Value),
                         StartOfemploymentDate = item.Element("StartOfemployment").Value,
                         EndOfemploymentDate = item.Element("EndOfemployment").Value,
                     }).ToList();
            }
            catch
            {
                l = null;
            }
            BasicXML.Save(root);
            return l;
        }

        public bool checkNanny(BE.Nanny N2)
        {//checks if nanny is already in list
            XElement root = BasicXML.LoadData();
            foreach (BE.Nanny item in GetListOfNannys())
            {
                if (N2.NannyId == item.NannyId)
                    return true;
            }
            return false;
        }
        public bool checkMother(BE.Mother N2)
        {//checks if mother is already in list
            List<BE.Mother> l = GetListOfMotherS();
            if (l.Count == 0)
                return false;

            foreach (BE.Mother item in l)
            {
               
                if (N2.MotherId == item.MotherId)
                    return true;
            }
           
            return false;
        }
        public bool checkChild(BE.Child N2)
        {//checks if child is already in list
            foreach (BE.Child item in GetListOfChildS())
            {
                if (N2.ChildId == item.ChildId)
                    return true;
            }
            return false;
        }
        public bool checkContract(BE.Contract N2)
        {//checks if Contract is already in list
            foreach (BE.Contract item in GetListOfContracts())
            {
                if (N2.getNumber() == item.getNumber())
                    return true;
            }
            return false;
        }
        public BE.Child findChild(int childid)
        {//returns child that her id is childid
            foreach (BE.Child item in GetListOfChildS())
            {
                if (childid == item.ChildId)
                    return item;
            }
            throw new Exception("child does not exits");
        }
        public BE.Nanny findNanny(int nannyid)
        {//returns nanny that her id is nannyid
            foreach (BE.Nanny item in GetListOfNannys())
            {
                if (nannyid == item.NannyId)
                    return item;
            }
            throw new Exception("nanny does not exits");
        }
        public BE.Mother findMother(int motherid)
        {//returns mother that her id is motherid
            foreach (BE.Mother item in GetListOfMotherS())
            {
                if (motherid == item.MotherId)
                    return item;
            }
            throw new Exception("Mother does not exits");
        }
        public BE.Contract findContract(int Contractid)
        {//returns mother that her id is motherid
            foreach (BE.Contract item in GetListOfContracts())
            {
                if (Contractid == item.getNumber())
                    return item;
            }
            throw new Exception("Contract does not exits");
        }
    }
}

