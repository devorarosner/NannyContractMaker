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
    /// Interaction logic for ShowNanny.xaml
    /// </summary>
    public partial class ShowNanny : Window
    {
        BL.IBL bl = BL.FactoryBL.GetBL();
        public ShowNanny()
		{//opens window
			InitializeComponent();
            List<BE.Nanny> nannys = bl.GetListOfNannys();//gets all nannys that are in program fron BL
			foreach (BE.Nanny item in nannys)//puts all nannys into window for show
			{
                this.nannyDataGrid.Items.Add(item);
            }
        }
    }
}
