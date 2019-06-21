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
    /// Interaction logic for ShowMother.xaml
    /// </summary>
    public partial class ShowMother : Window
    {
        BL.IBL bl = BL.FactoryBL.GetBL();//Building a BL type bone
        public ShowMother()
        {
            InitializeComponent();//Startup (initializes component)
            List<BE.Mother> M = bl.GetListOfMotherS();//Copies the list of the "mother" from the database in BL
            foreach (BE.Mother item in M)//Displays on the screen the fields of the current mother object
            {
                this.motherDataGrid.Items.Add(item);//Displays on the screen the fields of the current mother object

            }
        }

       
    }
}
