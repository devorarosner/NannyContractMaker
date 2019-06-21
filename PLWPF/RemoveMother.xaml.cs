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
    /// Interaction logic for RemoveMother.xaml
    /// </summary>
    public partial class RemoveMother : Window
    {
        BL.IBL bl = BL.FactoryBL.GetBL();//Building a BL type bone
        BE.Mother mother;//Building a mother - type object
        public RemoveMother()
        {
            InitializeComponent();//Startup (initializes component)
            List<BE.Mother> m = bl.GetListOfMotherS();//Copies the list of the "mother" from the database in BL
            foreach (BE.Mother item in m)//Passing the list of "mother"
            {
                motherIdComboBox.Items.Add(item);//Adds the ID of all mothers to a selection panel
            }
        }
        private void motherIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //A function that takes the mother's ID 
        //and shows on the screen the details that are in the fields of the "mother" selected
        {
            try
            {
                if (this.motherIdComboBox.SelectedItem is BE.Mother)//If there is a "mother" object that matches the selected ID
                {
                    mother = ((BE.Mother)this.motherIdComboBox.SelectedItem);//Retrieve from the list of the appropriate mother for the selected ID in the panel
                    this.DataContext = mother;//shows on the screen the details that are in the fields of the "mother" selected
                }
                else
                {
                    mother = null;
                }
            }
            catch (Exception ex)//If no "mother" is found who has such an ID number
            {
                MessageBox.Show(ex.Message);//Drop Error Message
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        //What happens in the program when you click the button (as is said when you start the Click event)
        {
            try
            {
                mother = ((BE.Mother)this.motherIdComboBox.SelectedItem);//Retrieve from the list of the appropriate mother for the selected ID in the panel
                
                bl.RemoveMother(mother);//Removes the "mother" selected from the list of "mothers" in the BL database
				motherIdComboBox.Items.Remove(mother);//Deletes the selected ID from the pane that displays the ID numbers
				mother = new BE.Mother();//Builds a new mother within the variable that was inserted before the "mother" was erased
                this.DataContext = mother;//Displays on the screen the fields of the new mother where the fields of the deleted mother were displayed
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
