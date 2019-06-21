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
    /// Interaction logic for RemoveContract.xaml
    /// </summary>
    public partial class RemoveContract : Window
    {
		BL.IBL bl;//Building a BL type bone
		BE.Contract C;
		public RemoveContract()
		{
			InitializeComponent();//Startup (initializes component)
			bl = BL.FactoryBL.GetBL();//Links the panel to the BL database
			C = new BE.Contract();
			this.DataContext = C;
			
			List<BE.Contract> n = bl.GetListOfContracts();//Copies the list of "Contracts" to a new list
			foreach (BE.Contract item in n)//Passing the list of "Contracts"
			{
				numberOfContractComboBox.Items.Add(item);//Adds the ID of all Contracts to a selection panel
			}
		}



		private void numberOfContractComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			//A function that takes the number Of Contract 
			//and shows on the screen the details that are in the fields of the "contract" selected
			try
			{
                if (this.numberOfContractComboBox.SelectedItem is BE.Contract)//If there is a "contract" object that matches the selected number
				{
                   C = ((BE.Contract)this.numberOfContractComboBox.SelectedItem);//Retrieve from the list of the appropriate contract for the selected number in the panel
					this.DataContext = C;//shows on the screen the details that are in the fields of the "contract" selected
				}
                else
                {
                    C= null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
		{//What happens in the program when you click the button (as is said when you start the Click event)
			try
            {
                C = ((BE.Contract)this.numberOfContractComboBox.SelectedItem);
                bl.RemoveContract(C);
				numberOfContractComboBox.Items.Remove(C);
				C = new BE.Contract();
                this.DataContext = C;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
