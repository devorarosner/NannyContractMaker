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
    /// Interaction logic for MothersPayments.xaml
    /// </summary>
    public partial class MothersPayments : Window
    {
        BL.IBL bl;//Building a BL type bone
        BE.Mother mother;//Building a mother - type object
        BE.Child child;
        List<BE.Child> boys;
        public MothersPayments()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            child = new BE.Child();
            mother = new BE.Mother();
            boys= bl.GetListOfChildS();//Copies the list of the "child" from the database in BL
            List<BE.Mother> m = bl.GetListOfMotherS();//Copies the list of the "mother" from the database in BL
            foreach (BE.Mother item in m)//Passing the list of "mother"
            {
                motherIdComboBox.Items.Add(item);//Adds the ID of all mothers to a selection panel
            }
        }

        private void motherIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (this.motherIdComboBox.SelectedItem is BE.Mother)//If there is a "mother" object that matches the selected ID
                {
                    mother = ((BE.Mother)this.motherIdComboBox.SelectedItem);//Retrieve from the list of the appropriate mother for the selected ID in the panel
                    this.DataContext = mother;//shows on the screen the details that are in the fields of the "mother" selected
                    if (this.motherIdComboBox.SelectedItem is BE.Mother)
                    {
                        
                        foreach (BE.Child item in boys)
                        {
                            childIdComboBox.Items.Remove(item);//Deletes the selected ID from the pane that displays the ID numbers
                        }
                        foreach (BE.Child item in boys)
                        {
                            childIdComboBox.Items.Add(item);//Deletes the selected ID from the pane that displays the ID numbers
                        }
                        foreach (BE.Child item in boys)//Passing the list of "child"
                        {
                            if (mother.MotherId != item.ChildMotherId)
                            {
                                childIdComboBox.Items.Remove(item);//Adds the ID of all childs to a selection panel
                            }
                        }
                    }
                    else
                    {
                        mother = null;
                    }
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

        private void childIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.childIdComboBox.SelectedItem is BE.Child)//If there is a "child" object that matches the selected ID
            {
                child = ((BE.Child)this.childIdComboBox.SelectedItem);//Retrieve from the list of the appropriate child for the selected ID in the panel
                childFirstNameTextBlock.Text = child.ChildFirstName;
            }
            else
            {
                child = null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<BE.Contract> C = bl.GetListOfContracts();
                double sum = 0;
                foreach (BE.Contract item in C)
                {
                    if ((item.MotherId == mother.MotherId) && (item.ChildId == child.ChildId))
                        sum = sum + bl.Payment(item);
                }
                paymentC.Content = sum + " NIS";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);//Drop Error Message
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<BE.Contract> C = bl.GetListOfContracts();
            double sum = 0;
            foreach (BE.Contract item in C)
            {
                if (item.MotherId == mother.MotherId)
                    sum = sum + bl.Payment(item);
            }
            totalPayment.Content = sum + " NIS";
        }
    }
}
