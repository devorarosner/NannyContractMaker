using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;
using GoogleMapsApi.Entities.Elevation.Request;
using GoogleMapsApi.Entities.Geocoding.Request;
using GoogleMapsApi.Entities.Geocoding.Response;
using GoogleMapsApi.StaticMaps;
using GoogleMapsApi.StaticMaps.Entities;


namespace BL
{
    public class BL1 : IBL
    {
        DAL.Idol dal;

        public int CalcDistance2(string source, string dest)
        {
            Leg leg = null;
            try
            {
                var drivingDirectionRequest = new DirectionsRequest
                {
                    TravelMode = TravelMode.Walking,
                    Origin = source,
                    Destination = dest,

                };

                DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
                Route route = drivingDirections.Routes.First();
                leg = route.Legs.First();
                return leg.Distance.Value;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public BL1()
        {
            dal = DAL.FactoryDAL.GetDal2();
        }
        public void AddNanny(BE.Nanny N)
        {//adds a nanny to list->checks that she is older then 18
            CalculateNannyAge(N.NannyDateOfBirth);//checks that nanny is older then 18
            dal.AddNanny(N);
        }
        public void RemoveNanny(BE.Nanny N)
        {//removes nanny from program
            dal.RemoveNanny(N);
        }
        public BE.Nanny findNanny(int Nid)
        {//finds nanny from program
            return dal.findNanny(Nid);
        }
        public void ChangeInfoNanny(BE.Nanny N,string Recommendations)
        {//updates nannys recommondations
            N.NannyRecommendations.Add(Recommendations);
            dal.ChangeInfoNanny(N);
        }
        public void AddMother(BE.Mother M)
        {//adds mother to list of mothers in program
				dal.AddMother(M);
			
        }
        public void RemoveMother(BE.Mother M)
        {//removes mother from program
            dal.RemoveMother(M);
        }
        public BE.Mother findMother(int Mid)
        {//finds Mother from program
            return dal.findMother(Mid);
        }
        public void ChangeInfoMother(BE.Mother M,string moreNotes)
        {//adds note to mothers notes
            M.MotherNotes = M.MotherNotes+" "+moreNotes;
            dal.ChangeInfoMother(M);
        }
        public void AddChild(BE.Child C)
        {//adds child to list of childs->checks that child is older then 3 monthes
            CalculateChildAge(C.ChildDateOfBirth); //checks that child is older then 3 monthes
            dal.AddChild(C);
        }
        public void RemoveChild(BE.Child C)
        {//removes child from program
            dal.RemoveChild(C);
        }
        public BE.Child findChild(int Cid)
        {//finds Mother from program
            return dal.findChild(Cid);
        }
        public void ChangeInfoChild(BE.Child C,string whatChildsSpecialNeeds,bool toAddOrToRemove)
        {//adds or removes childs special needs acourding to requeset
            if (toAddOrToRemove == true)//add child special need
            {//add child special need
                C.ChildsSpecialNeedsList.Add(whatChildsSpecialNeeds);
                C.ChildWithSpecialNeeds = true;
            }
            else//removes child special need
            {
                C.ChildsSpecialNeedsList.Remove(whatChildsSpecialNeeds);
                if (C.ChildsSpecialNeedsList.Count == 0)
                    C.ChildWithSpecialNeeds = false;
            }
            dal.ChangeInfoChild(C);
        }
        public void AddContract(BE.Contract C)
        {//add contract to list->the contract is basic there for the program must fill in the rest of the details
            BE.Nanny N=dal.findNanny(C.NannyId);//finds nanny from contract
            BE.Mother M= dal.findMother(C.MotherId);
            isNannyFilled(C);
            C.PaymentPerHour=N.NannyPaymentPerHour;//puts nannys payment demands into contract payments
            C.PaymentPermonth = N.NannyPaymentPermonth;
            double start,end;
            for (int i=0;i<6;i++)
            {
                if (M.MotherTimeNeedsNanny[i, 0] < N.NannyTimeIsWorkingOnDay[i, 0])//find when nanny starts working
                    start = N.NannyTimeIsWorkingOnDay[i, 0];
                else
                    start = M.MotherTimeNeedsNanny[i, 0];
                if (M.MotherTimeNeedsNanny[i, 1] < N.NannyTimeIsWorkingOnDay[i, 1])//finds when nanny stops working
                    end = N.NannyTimeIsWorkingOnDay[i, 1];
                else
                    end = M.MotherTimeNeedsNanny[i, 1];
                C.TimeNannyWorkingWeek[i] = end - start;
            }
            dal.AddContract(C);
        }
        public void RemoveContract(BE.Contract C)
        {//removes contract from program
            dal.RemoveContract(C);
        }
        public BE.Contract findContract(int Cid)
        {//finds Mother from program
            return dal.findContract(Cid);
        }
        public void ChangeInfoContract(BE.Contract C)
        {//changes the way of payment in contract
            
            if (C.IsPymentPerHour == true)
                C.IsPymentPerHour = false;
            else
                C.IsPymentPerHour = true;
            dal.ChangeInfoContract(C);
        }
        public List<BE.Child> DoesNotHaveNanny()
        {//returns list of childs that do not a nanny
            List<BE.Child> l = new List<BE.Child>();
            bool check;
            foreach (BE.Child item in GetListOfChildS())
            {//goes through the whole list of childs and for each one goes through whole list of contract and tries to find contract that has child in it
                check = false;
                foreach (BE.Contract item2 in GetListOfContracts())
                {
                    if (item.ChildId == item2.ChildId)
                        check = true;
                }
                if (check == false)//if child is not in eany contract then he does not have a nanny
                    l.Add(item);
            }
            return l;
        }
        public List<BE.Nanny> worksByVactionByMEducation()
        {//returns list of nannys that work by minster of education vactions
            List<BE.Nanny> l2 = new List<BE.Nanny>();
            IEnumerable<BE.Nanny> l = new List<BE.Nanny>();
            l = from item in GetListOfNannys()
				where item.NannyVactionByMEducation == true
                select item;
            foreach (BE.Nanny v in l)//goes trough list of nannys and finds the ones that work by minster of education vactions
                l2.Add(v);
            return l2;
        }
        public double Payment(BE.Contract C)
        {//calculates and returns how much mother owes the nanny in contract
            int amount = doesHeHaveBrotherInNanny(C.NannyId, C.ChildId);//finds how many brothers are also by this nanny
            BE.Nanny N = dal.findNanny(C.NannyId);//find of nanny
            double payThisMonth;
            double HoursPreWeek = 0;
            if (C.IsPymentPerHour == true)//checks if payment is by hour
            {
                for (int i = 0; i < 6; i++)//adds up time nanny works every week
                    HoursPreWeek +=C.TimeNannyWorkingWeek[i];
                payThisMonth = C.PaymentPerHour * 4 * HoursPreWeek;
            }
            else//if payment is by month
                payThisMonth = C.PaymentPermonth;
            for (int j = amount; j > 0; j--)//reduces 2% of payment for each brother child has at nnany
                payThisMonth = payThisMonth - (payThisMonth * 0.02);
            return payThisMonth;


        }
        public void isNannyFilled(BE.Contract C)
        {//checks if nanny is filled or still has space for more kids
            int amount = amoutOfChildByNanny(C.NannyId);
            BE.Nanny N = dal.findNanny(C.NannyId);
            if (amount >= N.NannyMaxNumberOfKids)
                throw new Exception("nanny has to many kids");
        }
        public int amoutOfChildByNanny(int nannyid)
        {//calculate amount of childs at nanny
            int count = 0;
            var v = from item in GetListOfContracts()//goes through all contracts and addes up all the ones nanny is in
					where nannyid == item.NannyId
                    select item;
            foreach (var item2 in v)
                count++;
            return count;
        }
        public void CalculateNannyAge(DateTime DateOfBirth)
        {//checks if nanny is older then 18
            DateTime today = DateTime.Today;//the date today
            today.ToString("dd/MM/yyyy");
            DateTime littletoday = today.AddYears(-18);//minuses 18 years from the date today
            int result = DateTime.Compare(littletoday, DateOfBirth);//compares the nannys date of birth to today -18
             if (result < 0)//if its bigger then nanny is not 18 yet
                 throw new Exception("to young");
        }
        public void CalculateChildAge(DateTime DateOfBirth)
        {//checks if child is older then 3 months
            DateTime today = DateTime.Today;//the date today
            today.ToString("dd/MM/yyyy");
            DateTime littletoday = today.AddMonths(-3);//minuses 3 months from the date today
            int result = DateTime.Compare(littletoday, DateOfBirth);//compares the childs date of birth to today -3
            DateTime today2 = DateTime.Today;//the date today
            DateTime bigtoday = today2.AddYears(-10);
            int result2 = DateTime.Compare(DateOfBirth, bigtoday);
            if ((result < 0) || (result2 < 0))//if its bigger then child is not 3 months yet
                throw new Exception("to old/young");
        }
        public int doesHeHaveBrotherInNanny(int NannyId, int ChildId)
        {//gets child and nanny and calculates how many brothers does the child have by nanny
            int count = 0;
            BE.Child C = dal.findChild(ChildId);
            foreach (BE.Contract item in GetListOfContracts())
            {//goes through all contracts and checks 
                if ((item.MotherId == C.ChildMotherId) && (NannyId == item.NannyId) && (ChildId != item.ChildId))//if the mother is the same mother nanny and not himself
                    count++;//then its childs brother
            }
            return count;
        }
        public List<BE.Nanny>  GetListOfNannys()
        {
            return dal.GetListOfNannys();
        }
        public List<BE.Mother> GetListOfMotherS()
        {
            return dal.GetListOfMotherS();
        }
        public List<BE.Child>  GetListOfChildS()
        {
            return dal.GetListOfChildS();
        }
        public List<BE.Contract>  GetListOfContracts()
        {
            return dal.GetListOfContracts();
        }
        public List<BE.Nanny> workRightTimeforMother(BE.Mother M)
        {//finds all the nannys that work in the time the mother needs
            List<BE.Nanny> l = new List<BE.Nanny>();
            bool flage;
            int i;
            foreach (BE.Nanny item in GetListOfNannys())
            {//goes through list of nannys 
                flage = true;
                i = 0;
                while ((i < 6) && (flage == true))//for each nanny check that every day she start earlly then the mother needs and ends later then the mother needs
                {

                    if ((M.MotherNeedsNanny[i] == true) && (item.NannyIsWorkingOnDay[i] == true))
                        if (!((M.MotherTimeNeedsNanny[i, 0] >= item.NannyTimeIsWorkingOnDay[i, 0]) && (M.MotherTimeNeedsNanny[i, 1] <= item.NannyTimeIsWorkingOnDay[i, 1])))
                            flage = false;
                    i++;
                }
                if (flage == true)//if the nanny every day start earlly then the mother needs and ends later then the mother needs adds to list
                    l.Add(item);
            }
            return l;
        }
        public int returnMaxPlace(double[] array1)
        {//finds the place in the array with the highest number and returns its place
            double max = 0.0;
            int maxPlace = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                if (max < array1[i])
                {
                    max = array1[i];
                    maxPlace = i;
                }
            }
            return maxPlace;
        }
        public double WorksForMotherAndNannyTime(BE.Mother M, BE.Nanny N)
        {//returns the amount of time the mother needs nanny but nanny does not work
            int i = 0;
            double sum = 0;
            while (i < 6)
            {

                if (M.MotherNeedsNanny[i] == true)//mother needs nanny on day i
                    if (N.NannyIsWorkingOnDay[i] == true)//nanny works on day i
                    {
                        if (M.MotherTimeNeedsNanny[i, 0] < N.NannyTimeIsWorkingOnDay[i, 0])//if nanny starts later then mother needs
                            sum = sum + N.NannyTimeIsWorkingOnDay[i, 0] - M.MotherTimeNeedsNanny[i, 0];
                        if (M.MotherTimeNeedsNanny[i, 1] > N.NannyTimeIsWorkingOnDay[i, 1])//if nanny end earlier then mother needs
                            sum = sum + M.MotherTimeNeedsNanny[i, 1] - N.NannyTimeIsWorkingOnDay[i, 1];
                    }
                    else//if nanny does not work on day i
                    {
                        sum = sum + M.MotherTimeNeedsNanny[i, 1] - M.MotherTimeNeedsNanny[i, 0];
                    }
                i++;
            }
            return sum;
        }
        public BE.Nanny[] bestNannysForMother(BE.Mother M)
        {//returns the array of nannys that are best for the mother
            double missedT;
            if (GetListOfNannys().Capacity <= 5)//if there are less then 5 nannies in nanny list then return all of them
            {
                BE.Nanny[] BestNanny2 = GetListOfNannys().ToArray();
                return BestNanny2;
            }
            BE.Nanny[] BestNanny = new BE.Nanny[5];
            double[] NannyMissedTime = new double[5];//saves the amount of hours each nanny is bad for mother
            int switchplace = returnMaxPlace(NannyMissedTime);//saves the place of the worst nanny for mother 
            for (int i = 0; i < 5; i++)//places the 5 first nannies into array
            {
                BestNanny[i] = GetListOfNannys()[i];
                NannyMissedTime[i] = WorksForMotherAndNannyTime(M, GetListOfNannys()[i]);
            }
            for (int j = 6; j < GetListOfNannys().Capacity; j++)
            {//goes through the rest of the nanny list and if its better then the worst nanny in array it switches them
                missedT = WorksForMotherAndNannyTime(M, GetListOfNannys()[j]);
                if (missedT < NannyMissedTime[switchplace])
                {
                    NannyMissedTime[switchplace] = missedT;
                    BestNanny[switchplace] = GetListOfNannys()[j];
                    switchplace = returnMaxPlace(NannyMissedTime);
                }
            }
            return BestNanny;
        }
        public List<BE.Nanny> ClosestAndBestNanny(BE.Mother M)
        {//returns the best nannys that are also closses to mothers home
            List<BE.Nanny> l = workRightTimeforMother(M);//returns all nannys that have the hours mother needs
            List<BE.Nanny> l2 = new List<BE.Nanny>();
            if (l.Count == 0)//if no nannies work exastliy for mother
                l = bestNannysForMother(M).ToList();//will find the 5 best
            foreach (BE.Nanny item in l)//if the distance is to smaller then what the mother wants
            {
                if (M.MotherNannyInArea >= CalculateDistance(M.MotherAddress, item.NannyAddress))
                    l2.Add(item);
            }
            return l2;
        }
        public int CalculateDistance(string source, string dest)
        {//caculates the distance between the sorce to destuntion->by using google maps
            var drivingDirectionRequest = new DirectionsRequest
            {
                TravelMode = TravelMode.Walking,
                Origin = source,
                Destination = dest,
            };
            DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
            Route route = drivingDirections.Routes.First();
            Leg leg = route.Legs.First();
            return leg.Distance.Value;
        }
        public List<BE.Contract> allContractsByRequest(Func<BE.Contract, bool> a)
        {//returns a list of all the contracts that when you send them to function a they return true
            List<BE.Contract> l = new List<BE.Contract>();
            foreach(BE.Contract item in GetListOfContracts())
            {
                if (a(item) == true)//function a they return true
                    l.Add(item);
            }
            return l;
        }
        public int amountThatFallowContractsByRequest(Func<BE.Contract, bool> a)
        {//returns the amount of contracts that when you send them to function a they return true
            int count = 0;
            foreach (BE.Contract item in GetListOfContracts())
            {
                if (a(item) == true)//function a they return true
                    count++;
            }
            return count;
        }
        public List<BE.Nanny>[] dividNannyByMaxOrMinAge(bool bigOrLittle)
        {//divides the nannies acourding to the max/min age of kids they will take->acourding to big or little
            List<BE.Nanny>[] l = new List<BE.Nanny>[5];
            l[0] = new List<BE.Nanny>();
            l[1] = new List<BE.Nanny>();
            l[2] = new List<BE.Nanny>();
            l[3] = new List<BE.Nanny>();
            l[4] = new List<BE.Nanny>();
            int j = 0;
            if (bigOrLittle == true)//divides the nannies acourding to the max age of kids
            {
                IEnumerable<IGrouping<int, BE.Nanny>> resultmax = from item in GetListOfNannys()
																  group item by item.NannyMaxAgeOfKid_InMonth / 12;//there will not be childs bigger then 4 years old
                foreach (IGrouping<int, BE.Nanny> item2 in resultmax)
                {
                    foreach (BE.Nanny N in item2)
                        l[j].Add(N);
                    j++;
                }
            }
            else//divides the nannies acourding to the min age of kids
            {
                IEnumerable<IGrouping<int, BE.Nanny>> resultmin = from item in GetListOfNannys()
																  group item by item.NannyMinAgeOfKid_InMonth / 12;
                foreach (IGrouping<int, BE.Nanny> item2 in resultmin)
                {
                    foreach (BE.Nanny N in item2)
                        l[j].Add(N);
                    j++;
                }
            }
            return l;
        }
        public int ContractDistance(BE.Contract C)
        {//calcutats the distance between the mother and nanny in contract
            BE.Mother M = dal.findMother(C.MotherId);
            BE.Nanny N = dal.findNanny(C.NannyId);
            return CalculateDistance(M.MotherAddress, N.NannyAddress);
        }
        public List<BE.Contract>[] dividContractByDistance()
        {//divides the contracts acourding to distance in between the mother and nanny in contract
            IEnumerable<IGrouping<int, BE.Contract>> result = from item in GetListOfContracts()
															  group item by item.Distance;
            int count = 0;
            int j = 0;
            foreach (IGrouping<int, BE.Contract> item2 in result)//counts how many groups there will be
            {
                count++;
            }
            List<BE.Contract>[] l = new List<BE.Contract>[count];
            for(int i=0;i<count;i++)
            {
                l[i] = new List<BE.Contract>();
            }
            foreach (IGrouping<int, BE.Contract> item in result)//places the contract in the right place
            {
                foreach (BE.Contract N in item)
                    l[j].Add(N);
                j++;
            }
            return l;
        }
    }
}
