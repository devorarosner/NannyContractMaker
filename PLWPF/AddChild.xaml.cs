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
    /// Interaction logic for AddChild.xaml
    /// </summary>
    public partial class AddChild : Window
    {
        BE.Child child;//Building a chil - type object
        BL.IBL bl;//Builds an IBL type object
        public AddChild()
        {
            InitializeComponent();//Startup (initializes component)
            child = new BE.Child();
            this.DataContext = child;//Displays on the screen the fields of the object being built
            bl = BL.FactoryBL.GetBL();//Links the panel to the BL database
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (child.ChildId >999999999)
                    throw new Exception("your id is not valid");
                if (child.ChildId == 0)
                    throw new Exception("your id is not valid");
                if (child.ChildMotherId == 0)
                    throw new Exception("your mother id is not valid");
                if (child.ChildMotherId > 999999999)
                    throw new Exception("your mother id is not valid");
                bl.AddChild(child);//Add the child object to the "child" list in the BL database
                child = new BE.Child();//initialize child as an empty object of the child type
                this.DataContext = child;//Set the fields of the screen to child
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
