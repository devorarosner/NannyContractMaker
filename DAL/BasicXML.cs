using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using BE;
namespace DAL
{
    public class BasicXML
    {
        static XElement Finder;
        static string FinderPath = "..//..//..//XMLfile//progectxml.xml";


        static BasicXML()
        {
            if (!File.Exists(FinderPath))
                CreateFiles();
            else
                LoadData();
        }

        private static void CreateFiles()
        {
            Finder = new XElement("Program");
			Finder.Save(FinderPath);
        }

        public static void Save(XElement r)
        {
            r.Save(FinderPath);
        }

        public static XElement LoadData()
        {
            try
            {
                Finder = XElement.Load(FinderPath);

            }
            catch
            {
                throw new Exception("File upload problem");
            }
            return Finder;
        }
    }
}
