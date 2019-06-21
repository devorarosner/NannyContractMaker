using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ShowContract.xaml
    /// </summary>
    public partial class ShowContract : Window
    {
		BL.IBL bl = BL.FactoryBL.GetBL();//Building a BL type bone
		public ShowContract()
		{
			InitializeComponent();//Startup (initializes component)
			List<BE.Contract> C = bl.GetListOfContracts();//Copies the list of the "contract" from the database in BL
			foreach (BE.Contract item in C)//Displays on the screen the fields of the current contract object
			{
				this.contractDataGrid.Items.Add(item);//Displays on the screen the fields of the current contract object

			}
		}


	}
}
