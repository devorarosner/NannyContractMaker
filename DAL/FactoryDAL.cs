using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDAL
    {
        public static void currentMaxContractNumber()
        {
            XElement root = BasicXML.LoadData();
            int max = 0;
            foreach (XElement item in root.Elements())
            {
                if (item.Name == "Contract")
                {
                    if (int.Parse(item.Element("NumberOfContract").Value) > max)
                        max = int.Parse(item.Element("NumberOfContract").Value);
                }
            }
            max++;
            BE.Contract.NumberStatic = max;
        }
        public static Idol GetDal()
        {
            return new Dal_imp();
        }
        public static Idol GetDal2()
        {
            currentMaxContractNumber();
            return new Dal_XML_imp();
        }
    }
}
