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
    /// Interaction logic for RemoveChild.xaml
    /// </summary>
    public partial class RemoveChild : Window
    {
		BL.IBL bl;//Building a BL type bone
        BE.Child child;//Building a child - type object
        public RemoveChild()
        {
            InitializeComponent();//Startup (initializes component)
			bl = BL.FactoryBL.GetBL();
			child = new BE.Child();
			this.DataContext = child;//Displays on the screen the fields of the new child where the fields of the deleted child were displayed
			List<BE.Child> boys = bl.GetListOfChildS();//Copies the list of the "child" from the database in BL
            foreach (BE.Child item in boys)//Passing the list of "child"
            {
                childIdComboBox.Items.Add(item);//Adds the ID of all childs to a selection panel
            }
        }
      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //What happens in the program when you click the button (as is said when you start the Click event)
            try
            {
				
				child = ((BE.Child)this.childIdComboBox.SelectedItem);//Retrieve from the list of the appropriate child for the selected ID in the panel
				bl.RemoveChild(child);//Removes the "child" selected from the list of "childs" in the BL database
				childIdComboBox.Items.Remove(child);//Deletes the selected ID from the pane that displays the ID numbers
				child = new BE.Child();//Builds a new child within the variable that was inserted before the "child" was erased
                this.DataContext = child;//Displays on the screen the fields of the new child where the fields of the deleted child were displayed
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void childIdComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //A function that takes the child's ID 
            //and shows on the screen the details that are in the fields of the "child" selected
            try
            {
                if (this.childIdComboBox.SelectedItem is BE.Child)//If there is a "child" object that matches the selected ID
                {
                    child = ((BE.Child)this.childIdComboBox.SelectedItem);//Retrieve from the list of the appropriate child for the selected ID in the panel
                    this.DataContext = child;//shows on the screen the details that are in the fields of the "child" selected
                }
                else
                {
                    child = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
