using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{   public interface Idol
    {
        void AddNanny(BE.Nanny obj);
        void RemoveNanny(BE.Nanny obj);
        void ChangeInfoNanny(BE.Nanny obj);

        void AddMother(BE.Mother obj);
        void RemoveMother(BE.Mother obj);
        void ChangeInfoMother(BE.Mother obj);

        void AddChild(BE.Child obj);
		void RemoveChild(BE.Child obj);
		void ChangeInfoChild(BE.Child obj);

        void AddContract(BE.Contract obj);
        void RemoveContract(BE.Contract obj);
        void ChangeInfoContract(BE.Contract obj);

        List<BE.Nanny> GetListOfNannys();
        List<BE.Mother> GetListOfMotherS();
        List<BE.Child>  GetListOfChildS();
        List<BE.Contract> GetListOfContracts();
        BE.Child findChild(int childid);
        BE.Nanny findNanny(int nannyid);
        BE.Mother findMother(int motherid);
        BE.Contract findContract(int Contractid);
    }
}
