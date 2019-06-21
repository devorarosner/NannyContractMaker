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
    /// Interaction logic for AddContract.xaml
    /// </summary>
    public partial class AddContract : Window
    {
        BE.Mother M;
        BE.Nanny N;
        BE.Contract C;
        BE.Child child;
        BL.IBL bl;//Builds an IBL type object
		string source;
        string dest;
        int distance = -1;
        List<BE.Child> boys;
        public AddContract()
        {
            InitializeComponent();//Startup (initializes component)
			bl = BL.FactoryBL.GetBL();//Links the panel to the BL database
			M = new BE.Mother();
            N = new BE.Nanny();
            C = new BE.Contract();
            child = new BE.Child();
            boys= bl.GetListOfChildS();//Copies the list of the "child" from the database in BL
            List<BE.Mother> m = bl.GetListOfMotherS();//Copies the list of "mothers" to a new list
			foreach (BE.Mother item in m)//Passing the list of "mothers"
			{
                motherIdComboBox.Items.Add(item);//Adds the ID of all mothers to a selection panel
			}
            List<BE.Nanny> n = bl.GetListOfNannys();//Copies the list of "nannys" to a new list
			foreach (BE.Nanny item in n)//Passing the list of "nannys"
			{
                nannyIdComboBox.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            M = ((BE.Mother)this.motherIdComboBox.SelectedItem);//Retrieve from the list of the appropriate mother for the selected ID in the panel
			N = ((BE.Nanny)this.nannyIdComboBox.SelectedItem);//Retrieve from the list of the appropriate nannys for the selected ID in the panel
			source = M.MotherAddress;//Sets the source to be the address of the selected mother
			dest = N.NannyAddress;//Sets the dest to be the address of the selected nanny

            errorReport.Content = " ";
            System.ComponentModel.BackgroundWorker work = new System.ComponentModel.BackgroundWorker();
            work.DoWork += W_DoWork;
            work.RunWorkerCompleted += W_RunWorkerCompleted;
            work.RunWorkerAsync();
            double differenceOfHours = bl.WorksForMotherAndNannyTime(M, N);//Examines the difference between what the mother needs and what the nanny agrees to work with
			if (differenceOfHours==0)
			{//If the nanny works all the hours the mother needs
				checkTime.Content = "nanny works in all the hours mother needs";
            }
            else
            {
                checkTime.Content = "nanny does not work for " + differenceOfHours + " hours that you need";
            }
        }
        private void W_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{ // Activating the function that checks the distance between the mother's address and the nanny's
			try
            {
                distance = bl.CalcDistance2(source, dest);
            }
            catch (Exception)
            {
                distance = -1;
            }
        }
        private void W_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{//Activating a function that shows on the screen the distance between the mother and the nanny
			if (distance != -1)
            {
                if (distance < 1000)
                    checkLable.Content = "nanny is located "+distance + " meters from you";
                else
                    checkLable.Content = "nanny is located " + distance / 1000.0 + " km from you";
				//If the distance between the mother and the current nanny is greater than the maximum distance the mother wished to be,
				//We'll write it on the screen
				if ((distance > M.MotherNannyInArea) && (M.MotherNannyInArea > 0))
                    errorReport.Content = "the nanny is not in the range you asked";
            }
            else
            {
                checkLable.Content = "no result";
                
            }
        }

        private void nannyIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{ //View the details of the selected nanny
			try
            {
                if (this.nannyIdComboBox.SelectedItem is BE.Nanny)
                {
                    N = ((BE.Nanny)this.nannyIdComboBox.SelectedItem);
                    this.DataContext = N;
                }
                else
                {
                    N = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void motherIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{//View the details of the selected mother
			try
            {
                foreach (BE.Child item in boys)
                {
                    childIdComboBox.Items.Remove(item);//Deletes the selected ID from the pane that displays the ID numbers
                }
                    foreach (BE.Child item in boys)
                {
                    childIdComboBox.Items.Add(item);//Deletes the selected ID from the pane that displays the ID numbers
                }
               
                if (this.motherIdComboBox.SelectedItem is BE.Mother)
                {
                    M = ((BE.Mother)this.motherIdComboBox.SelectedItem);
                    motherLastNameTextBlock.Text = M.MotherLastName;
                    motherFirstNameTextBlock.Text = M.MotherFirstName;

                    
                    foreach (BE.Child item in boys)//Passing the list of "child"
                    {
                        if (M.MotherId != item.ChildMotherId)
                        {
                            childIdComboBox.Items.Remove(item);//Adds the ID of all childs to a selection panel
                        }
                    }
                }
                else
                {
                    M = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
		{//What happens when you press the "creat contract" button
			try
            {
                System.ComponentModel.BackgroundWorker work2 = new System.ComponentModel.BackgroundWorker();
                work2.DoWork += W_DoWork2;//Running the thread W_DoWork2
				work2.RunWorkerCompleted += W_RunWorkerCompleted2;
                work2.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void W_DoWork2(object sender, System.ComponentModel.DoWorkEventArgs e)
		{ //Calculates the distance between the 2 entered addresses
			try
            {
                distance = bl.CalcDistance2(source, dest);
            }
            catch (Exception)
            {
                distance = -1;
            }
        }
        private void W_RunWorkerCompleted2(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (distance != -1)//Initializes the fields within the built contract
                {
                    M = ((BE.Mother)this.motherIdComboBox.SelectedItem);
                    N = ((BE.Nanny)this.nannyIdComboBox.SelectedItem);
                    child = ((BE.Child)this.childIdComboBox.SelectedItem);
                    C.Distance = distance;
                    C.NannyId = N.NannyId;
                    C.MotherId = M.MotherId;
                    C.ChildId = child.ChildId;
                    bl.AddContract(C);//Add the contract object to the contract list 
                    C = new BE.Contract();
                }
                else
                {
                    M = ((BE.Mother)this.motherIdComboBox.SelectedItem);
                    N = ((BE.Nanny)this.nannyIdComboBox.SelectedItem);
                    child = ((BE.Child)this.childIdComboBox.SelectedItem);
                    C.NannyId = N.NannyId;
                    C.MotherId = M.MotherId;
                    C.ChildId = child.ChildId;
                    bl.AddContract(C);//Add the contract object to the contract list 
                    C = new BE.Contract();
                    M = new BE.Mother();
                    N = new BE.Nanny();
                    child = new BE.Child();
                }
                App.Current.Windows[2].Close();//closes current window
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void childIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
		{//Shows on the screen the nannys who are most suitable for mother
			new BestContracts(M.MotherId).Show();
        }
    }
}
