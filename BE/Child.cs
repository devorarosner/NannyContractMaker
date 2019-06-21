using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        private int childId;
        private int childMotherId;
        private string childFirstName;
        private DateTime childDateOfBirth;
        private bool childWithSpecialNeeds;
        private List<string> childsSpecialNeedsList = new List<string>();
        //get and set of every one:
        public int ChildId
        {
            get { return childId; }
            set { childId = value; }
        }
        public int ChildMotherId
        {
            get { return childMotherId; }
            set {  childMotherId = value; }
        }
        public string ChildFirstName
        {
            get{ return childFirstName;  }
            set { childFirstName = value; }
        }
        public DateTime ChildDateOfBirth
        {
            get {  return childDateOfBirth; }
            set { childDateOfBirth = value; }
        }
        public bool ChildWithSpecialNeeds
        {
            get{ return childWithSpecialNeeds; }
            set { childWithSpecialNeeds = value; }
        }

        public List<string> ChildsSpecialNeedsList
        {
            get { return childsSpecialNeedsList;}
            set {  childsSpecialNeedsList = value; }
        }
        public override string ToString()
        {//returns childs name
            return ChildFirstName;
        }
    }
}

