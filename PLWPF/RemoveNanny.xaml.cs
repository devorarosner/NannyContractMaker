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
    /// Interaction logic for RemoveNanny.xaml
    /// </summary>
    public partial class RemoveNanny : Window
    {
        BL.IBL bl = BL.FactoryBL.GetBL();
        BE.Nanny N;
        public RemoveNanny()
		{//opens window
			InitializeComponent();
            List<BE.Nanny> n = bl.GetListOfNannys();//gets all list of nannys from BL
			foreach (BE.Nanny item in n)//puts all nannys id in nannyIdComboBox
			{
                nannyIdComboBox.Items.Add(item);
            }
        }
        
        private void nannyIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{//if the content in nannyIdComboBox has changed then so will the rest of the context on window involed with nanny
			try
            {
                if (this.nannyIdComboBox.SelectedItem is BE.Nanny)
                {
                    N = ((BE.Nanny)this.nannyIdComboBox.SelectedItem);
                    this.DataContext = N;//changes the rest of the context on window involed with nanny
				}
                else
				{//if it nothing then you change nothing
					N = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
		{//removes the nanny the his id is in nannyIdComboBox from program
			try
            {
                N = ((BE.Nanny)this.nannyIdComboBox.SelectedItem);//saves the nanny the his id is in nannyIdComboBox from program
				
				bl.RemoveNanny(N);//removes the id from program
				nannyIdComboBox.Items.Remove(N);//and removes its idfrom nannyIdComboBox
				N = new BE.Nanny();
                this.DataContext = N;//puts default context into all context on window
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
