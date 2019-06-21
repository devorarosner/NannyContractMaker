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
    /// Interaction logic for ShowChild.xaml
    /// </summary>
    public partial class ShowChild : Window
    {
        BL.IBL bl = BL.FactoryBL.GetBL();
        public ShowChild()
		{//opens window
			InitializeComponent();
            List<BE.Child> boys = bl.GetListOfChildS();//gets all childs that are in program fron BL
			foreach (BE.Child item in boys)//puts all childs into window for show
			{
                this.childDataGrid.Items.Add(item);
 
            }
        }

       
    }
}
