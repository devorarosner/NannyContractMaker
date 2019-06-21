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
    /// Interaction logic for ContarctCanged.xaml
    /// </summary>
    public partial class ContarctCanged : Window
    {
		BL.IBL bl;//Builds an IBL type object
		BE.Contract C;
		public ContarctCanged()
		{
			InitializeComponent();//Startup (initializes component)
			bl = BL.FactoryBL.GetBL();//Links the panel to the BL database
			C = new BE.Contract();
			InitializeComponent();
			List<BE.Contract> n = bl.GetListOfContracts();//Copies the list of "Contractss" to a new list
			foreach (BE.Contract item in n)//Passing the list of "Contractss"
			{
                if(bl.findNanny(item.NannyId).NannyAllowsPaymentByHour)
				      numberOfContractComboBox.Items.Add(item);//Adds the ID of all Contractss to a selection panel
			}
		}

		private void numberOfContractComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{//A function that takes the Contract's ID 
		 //and shows on the screen the details that are in the fields of the "Contract" selected
			try
			{
                if (this.numberOfContractComboBox.SelectedItem is BE.Contract)//If there is a "Contract" object that matches the selected ID
				{
                    C = ((BE.Contract)this.numberOfContractComboBox.SelectedItem);//Retrieve from the list of the appropriate Contract for the selected ID in the panel
					this.DataContext = C;//shows on the screen the details that are in the fields of the "Contract" selected
                    isPymentPerHourCheckBox.IsChecked = C.IsPymentPerHour;

                }
                else
                {
                    C = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void isPymentPerHourCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                C.IsPymentPerHour = false;
                bl.ChangeInfoContract(C);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void isPymentPerHourCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                C.IsPymentPerHour = true;
                bl.ChangeInfoContract(C);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
