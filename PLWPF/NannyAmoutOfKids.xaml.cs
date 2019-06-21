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
    /// Interaction logic for NannyAmoutOfKids.xaml
    /// </summary>
    public partial class NannyAmoutOfKids : Window
    {

		BL.IBL bl;
        BE.Nanny N;
        public NannyAmoutOfKids()
        {
            InitializeComponent();
			bl = BL.FactoryBL.GetBL();
			N = new BE.Nanny();
			List<BE.Nanny> n = bl.GetListOfNannys();
            foreach (BE.Nanny item in n)
            {
                nannyIdComboBox.Items.Add(item);
            }
        }

        private void nannyIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (this.nannyIdComboBox.SelectedItem is BE.Nanny)
                {
                    N = ((BE.Nanny)this.nannyIdComboBox.SelectedItem);
                    this.DataContext = N;

                    amoutOfKids.Content = "nanny has " + bl.amoutOfChildByNanny(N.NannyId) + " children by her";
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
    }
}
