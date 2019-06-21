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
    /// Interaction logic for NannyRecommendations.xaml
    /// </summary>
    public partial class NannyRecommendations : Window
    {
        BL.IBL bl = BL.FactoryBL.GetBL();
        BE.Nanny nanny;
        string help;
        public string Text
		{//builds a Dependency Property that contans the text user whats to add as recommondation
			get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NannyRecommendations), new PropertyMetadata(null));

        public NannyRecommendations()
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
                if (this.nannyIdComboBox.SelectedItem is BE.Nanny)//if the id is realy from nanny
				{
                    nanny = ((BE.Nanny)this.nannyIdComboBox.SelectedItem);
					this.DataContext = nanny;//changes the rest of the context on window involed with nanny
				}
                else
				{//if it nothing then you change nothing
					nanny = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                help = Text;//help contans what is curently in textbox/Text
                nanny = (((BE.Nanny)this.nannyIdComboBox.SelectedItem));
                bl.ChangeInfoNanny(nanny, help);//adds Recommendation to nanny
				this.TextboxR.ClearValue(TextBox.TextProperty);//clears text box
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

        private void TextboxR_TextChanged(object sender, TextChangedEventArgs e)
        {
            Text = TextboxR.Text;
        }
    }
}
