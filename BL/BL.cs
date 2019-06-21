using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        int CalcDistance2(string source, string dest);
        void AddNanny(BE.Nanny N);
        void RemoveNanny(BE.Nanny N);
        void ChangeInfoNanny(BE.Nanny N, string Recommendations);

        void AddMother(BE.Mother M);
        void RemoveMother(BE.Mother M);
        void ChangeInfoMother(BE.Mother M, string moreNotes);

        void AddChild(BE.Child C);
        void RemoveChild(BE.Child C);
        void ChangeInfoChild(BE.Child C, string whatChildsSpecialNeeds, bool toAddOrToRemove);

        void AddContract(BE.Contract C);
        void RemoveContract(BE.Contract C);
        void ChangeInfoContract(BE.Contract C);

        List<BE.Nanny>  GetListOfNannys();
        List<BE.Mother>  GetListOfMotherS();
        List<BE.Child>  GetListOfChildS();
        List<BE.Contract>  GetListOfContracts();
        List<BE.Child> DoesNotHaveNanny();

         List<BE.Nanny> worksByVactionByMEducation();

         double Payment(BE.Contract C);

         void isNannyFilled(BE.Contract C);

         int amoutOfChildByNanny(int nannyid);

         void CalculateNannyAge(DateTime DateOfBirth);

         void CalculateChildAge(DateTime DateOfBirth);

        int doesHeHaveBrotherInNanny(int NannyId, int ChildId);
        
         List<BE.Nanny> workRightTimeforMother(BE.Mother M);

        int returnMaxPlace(double[] array1);


         double WorksForMotherAndNannyTime(BE.Mother M, BE.Nanny N);

        BE.Nanny[] bestNannysForMother(BE.Mother M);


         List<BE.Nanny> ClosestAndBestNanny(BE.Mother M);


         int CalculateDistance(string source, string dest);


         List<BE.Contract> allContractsByRequest(Func<BE.Contract, bool> a);


       int amountThatFallowContractsByRequest(Func<BE.Contract, bool> a);


        List<BE.Nanny>[] dividNannyByMaxOrMinAge(bool bigOrLittle);


         int ContractDistance(BE.Contract C);


        List<BE.Contract>[] dividContractByDistance();
        BE.Nanny findNanny(int Nid);
        BE.Mother findMother(int Mid);
        BE.Child findChild(int Cid);
        BE.Contract findContract(int Cid);
    }
}
   
    
