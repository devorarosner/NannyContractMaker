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
    /// Interaction logic for MotherChangeNotes.xaml
    /// </summary>
    public partial class MotherChangeNotes : Window
    {
        BL.IBL bl = BL.FactoryBL.GetBL();//Building a BL type bone
        BE.Mother mother;//Building a mother - type object
        string help;

        public MotherChangeNotes()

        {
            InitializeComponent();//Startup (initializes component)
            List<BE.Mother> m = bl.GetListOfMotherS();//Copies the list of the "mother" from the database in BL
            foreach (BE.Mother item in m)//Passing the list of "mother"
            {
                motherIdComboBox.Items.Add(item);//Adds the ID of all mothers to a selection panel
            }
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        //What happens in the program when you click the button (as is said when you start the Click event)
        {
            try
            {
                help = textBoxForChange.Text;//Inputs the inserted text into the transformation panel and inserts it into an auxiliary variable
                mother = (((BE.Mother)this.motherIdComboBox.SelectedItem));//Retrieve from the list of the appropriate mother for the selected ID in the panel
                bl.ChangeInfoMother(mother, help);//Send a "mother" object and a string to a function whose function is to insert the string into the comment field in the "mother"
                this.textBoxForChange.ClearValue(TextBox.TextProperty);//Clean the panel to be ready for next use
            }
            catch (FormatException)//If incorrect input is entered instead of ID
            {
                MessageBox.Show("check your input and try again");
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void motherIdCSelectionomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //A function that takes the mother's ID 
            //and shows on the screen the details that are in the fields of the "mother" selected
            {
                try
                {
                    if (this.motherIdComboBox.SelectedItem is BE.Mother)//If there is a "mother" object that matches the selected ID
                    {
                        mother = ((BE.Mother)this.motherIdComboBox.SelectedItem);//Retrieve from the list of the appropriate mother for the selected ID in the panel
                        motherFirstNameTextBlock.Text = mother.MotherFirstName;//shows on the screen the details that are in the fields of the "mother" selected
                        motherLastNameTextBlock.Text = mother.MotherLastName;//shows on the screen the details that are in the fields of the "mother" selected
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
        }
    }
}
