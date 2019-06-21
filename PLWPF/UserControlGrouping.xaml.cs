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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UserControlGrouping.xaml
    /// </summary>
    public partial class UserControlGrouping : UserControl
    {
		List<BE.Contract> b2;//Defines a list of contracts
		public UserControlGrouping()
		{
			InitializeComponent();//Startup (initializes component)
			b2 = new List<BE.Contract>();//Initializing the list to be an empty list
		}

		public void set(List<BE.Contract> b, int group)
		{
			foreach (BE.Contract item in b2)//Passing the list of "contract"
			{
				this.contractDataGrid.Items.Remove(item);//Deletes the list that appears on the screen
			}
			b2.Clear();//delete the contracts in the new list
			groupName.Content = "group is: " + group;//Displays the name of the group on the screen

			foreach (BE.Contract item in b)//Passing the list of "contract"
			{
				this.contractDataGrid.Items.Add(item);
				b2.Add(item);
			}

		}


	}
}
