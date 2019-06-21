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
    /// Interaction logic for ChildNoNanny.xaml
    /// </summary>
    public partial class ChildNoNanny : Window
    {
        BL.IBL bl = BL.FactoryBL.GetBL();
        public ChildNoNanny()
        {
            InitializeComponent();
            List<BE.Child> boys = bl.DoesNotHaveNanny();//gets a list of all childs that are not in contract
            foreach (BE.Child item in boys)
            {
                this.childDataGrid.Items.Add(item);

            }
        }

        
    }
}
