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
    /// Interaction logic for ChildChangInfo.xaml
    /// </summary>
    public partial class ChildChangInfo : Window
    {
        BL.IBL bl;
        BE.Child C;
        string help;
        public ChildChangInfo()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            List<BE.Child> boys = bl.GetListOfChildS();//gets all list of childsas from BL
			foreach (BE.Child item in boys)//puts all childs id in childIdComboBox
			{
                childIdComboBox.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
		{//changes childs info-adds special need
			try
            {
                help = this.TextBox.Text;//help contans what is curently in textbox
				C =(((BE.Child)this.childIdComboBox.SelectedItem));
                bl.ChangeInfoChild(C, help, true);//adds special need
				this.TextBox.ClearValue(TextBox.TextProperty);//emptys the textbox
				this.checkAdd.IsChecked = false;//changes checkbox to not be checked
			}
            catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                C = (((BE.Child)this.childIdComboBox.SelectedItem));
                bl.ChangeInfoChild(C, help, false);//removes special need
				this.TextBox.ClearValue(TextBox.TextProperty);//emptys the textbox
				this.checkRemove.IsChecked = false;//changes checkbox to not be checked
			}
            catch (FormatException)
            {
                MessageBox.Show("check your input and try again");
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{//updates what is writen in text box
			help = this.TextBox.Text;
        }
    }
}
