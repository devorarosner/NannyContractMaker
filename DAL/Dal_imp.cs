using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DS.DataSource;
using DS;

namespace DAL
{
    public class Dal_imp: DAL.Idol
    {
        public static Idol GetDal()
        {
            return new Dal_imp();
        }
        public void AddNanny(BE.Nanny N)
        {//adds nanny to list after checking that he does not exist already
            if (checkNanny(N) == true)
                throw new Exception("nanny already exists");
             listOfNannys.Add(N);     
        }
        public void RemoveNanny(BE.Nanny N)
        {//removes nanny from program
            listOfNannys.Remove(N);
            foreach (BE.Contract item in listOfContracts)//deletes all contracts that nanny is in
            {
                if (N.NannyId == item.NannyId)
                    RemoveContract(item);
            }
        }
        public void ChangeInfoNanny(BE.Nanny N) { }

        public void AddMother(BE.Mother M)
        {//adds mother to list after checking that he does not exist already
            
            if (checkMother(M) == true)
              throw new Exception("mother already exists");
            
            listOfMothers.Add(M);
            
        }
        public void RemoveMother(BE.Mother M)
        {//removes mother from program
            listOfMothers.Remove(M);
            foreach (BE.Contract item in listOfContracts)//deletes all contracts that mother is in
            {
                if (M.MotherId == item.MotherId)
                    RemoveContract(item);
            }
            foreach (BE.Child item in listOfChilds)////deletes all childs that M is there mother
            {
                if (M.MotherId == item.ChildMotherId)
                    RemoveChild(item);
            }
        }
        public void ChangeInfoMother(BE.Mother M) { }

        public void AddChild(BE.Child C)
        {//adds child to list after checking that he does not exist already
           if (checkChild(C) == true)
             throw new Exception("Child already exists");
            listOfChilds.Add(C);
        }
        public void RemoveChild(BE.Child C)
        {//remove child from program
            listOfChilds.Remove(C);
            foreach (BE.Contract item in listOfContracts)//removes contracts that child is in
            {
                if (C.ChildId == item.ChildId)
                    RemoveContract(item);
            }
        }
        public void ChangeInfoChild(BE.Child c) { }

        public void AddContract(BE.Contract C)
        {//checks that contract does not exist already and the nanny and child do
            if (checkContract(C) == true)
             throw new Exception("Contract already exists");
             bool flage=false;
              foreach (BE.Nanny item in listOfNannys)
            {
                if (C.NannyId == item.NannyId)
                    flage=true;
            }
            if(flage==false)
              throw new Exception("Nanny does not exist");
             foreach (BE.Child item in listOfChilds)
            {
                if (item.ChildId == item.ChildId)
                    flage = false;
            }
            if(flage==true)
              throw new Exception("Child does not exist");
            
            listOfContracts.Add(C);
        }
        public void RemoveContract(BE.Contract C)
        {//removes contract from list
            listOfContracts.Remove(C);
        }
        public void ChangeInfoContract(BE.Contract c) { }

        public List<BE.Nanny> GetListOfNannys()
        {
            List<BE.Nanny> l = new List<BE.Nanny>();
            foreach (BE.Nanny item in listOfNannys)
            {
                l.Add(item);
            }
            return l;
        }
        public List<BE.Mother> GetListOfMotherS()
        {
            List<BE.Mother> l = new List<BE.Mother>();
            foreach (BE.Mother item in listOfMothers)
            {
                l.Add(item);
            }
            return l;
        }
        public List<BE.Child> GetListOfChildS()
        {
            List<BE.Child> l = new List<BE.Child>();
            foreach (BE.Child item in listOfChilds)
            {
                l.Add(item);
            }
            return l;
        }
        public List<BE.Contract> GetListOfContracts()
        {
            List<BE.Contract> l = new List<BE.Contract>();
            foreach (BE.Contract item in listOfContracts)
            {
                l.Add(item);
            }
            return l;
        }

        public bool checkNanny(BE.Nanny N2)
        {//checks if nanny is already in list
            foreach (BE.Nanny item in listOfNannys)
            {
                if (N2.NannyId == item.NannyId)
                    return true;
            }
            return false;
        }
        public bool checkMother(BE.Mother N2)
        {//checks if mother is already in list
            Console.WriteLine(listOfMothers.Count);
            if(listOfMothers.Count==0)
                return false;
            foreach (BE.Mother item in listOfMothers)
            {
                if (N2.MotherId == item.MotherId)
                    return true;
            }
            return false;
        }
        public bool checkChild(BE.Child N2)
        {//checks if child is already in list
            foreach (BE.Child item in listOfChilds)
            {
                if (N2.ChildId == item.ChildId)
                    return true;
            }
            return false;
        }
        public bool checkContract(BE.Contract N2)
        {//checks if Contract is already in list
            foreach (BE.Contract item in listOfContracts)
            {
                if (N2.getNumber() == item.getNumber())
                    return true;
            }
            return false;
        }
        public BE.Child findChild(int childid)
        {//returns child that her id is childid
            foreach (BE.Child item in listOfChilds)
            {
                if (childid == item.ChildId)
                    return item;
            }
            throw new Exception("child does not exits");
        }
        public BE.Nanny findNanny(int nannyid)
        {//returns nanny that her id is nannyid
            foreach (BE.Nanny item in listOfNannys)
            {
                if (nannyid == item.NannyId)
                    return item;
            }
            throw new Exception("nanny does not exits");
        }
        public BE.Mother findMother(int motherid)
        {//returns mother that her id is motherid
            foreach (BE.Mother item in listOfMothers)
            {
                if (motherid == item.MotherId)
                    return item;
            }
           // BE.Mother m =  listOfMothers.Find(x => x.MotherId == motherid);
            throw new Exception("Mother does not exits");
        }
        public BE.Contract findContract(int Contractid)
        {//returns mother that her id is motherid
            foreach (BE.Contract item in listOfContracts)
            {
                if (Contractid == item.getNumber())
                    return item;
            }
            throw new Exception("Contract does not exits");
        }
    }
}
