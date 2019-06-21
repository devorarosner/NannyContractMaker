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
    /// Interaction logic for AddNanny.xaml
    /// </summary>
    public partial class AddNanny : Window
    {

        BE.Nanny N;
        BL.IBL bl;
        public AddNanny()
        {
            InitializeComponent();
            N = new BE.Nanny();
            this.DataContext = N;
            bl = BL.FactoryBL.GetBL();
        }

		private double switctTimeToDouble(string a)
		{//converts a string of time to a double number
			int size = a.Count();
			int a1, a2;
			if (size > 5)//string should look like hh:mm or h:mm
				throw new Exception("not a time");
			if (a[1] == ':')//string should look like h:mm
			{
				a1 = Convert.ToInt32(a[0]) - 48;
				a2 = (Convert.ToInt32(a[2]) - 48) * 10 + Convert.ToInt32(a[3]) - 48;
			}
			else
				if (a[2] == ':')//string should look like hh:mm 
			{
				a1 = (Convert.ToInt32(a[0]) - 48) * 10 + Convert.ToInt32(a[1]) - 48;
				a2 = (Convert.ToInt32(a[3]) - 48) * 10 + Convert.ToInt32(a[4]) - 48;
			}
			else
				throw new Exception("not a time");
			double c = a1 + Convert.ToDouble(a2) / 60;
			if ((c >= 25) || (Convert.ToDouble(a2) / 60 >= 1) || (c < 0))
				throw new Exception("not a time");
			return c;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (N.NannyId >999999999)
                    throw new Exception("your id is not valid");
                if (N.NannyId == 0)
                    throw new Exception("your id is not valid");
                bool[] NannyWorks = new bool[6];
                for (int i = 0; i < 6; i++)
				{//defaults the array
					NannyWorks[i] = false;
                }
                double[,] NannyWorks2 = new double[6, 2];
                if (this.day1.IsChecked == true)//for each check box will check if its checked if so places true in NannyWorks and the times frm text into NannyWorks2
				{
                    NannyWorks[0] = true;
                    NannyWorks2[0, 0] = switctTimeToDouble(daystart1.Text);
                    NannyWorks2[0, 1] = switctTimeToDouble(dayend1.Text);
                }
                if (this.day2.IsChecked == true)
                {
                    NannyWorks[1] = true;
                    NannyWorks2[1, 0] = switctTimeToDouble(daystart2.Text);
                    NannyWorks2[1, 1] = switctTimeToDouble(dayend2.Text);
                }
                if (this.day3.IsChecked == true)
                {
                    NannyWorks[2] = true;
                    NannyWorks2[2, 0] = switctTimeToDouble(daystart3.Text);
                    NannyWorks2[2, 1] = switctTimeToDouble(dayend3.Text);
                }
                if (this.day4.IsChecked == true)
                {
                    NannyWorks[3] = true;
                    NannyWorks2[3, 0] = switctTimeToDouble(daystart4.Text);
                    NannyWorks2[3, 1] = switctTimeToDouble(dayend4.Text);
                }
                if (this.day5.IsChecked == true)
                {
                    NannyWorks[4] = true;
                    NannyWorks2[4, 0] = switctTimeToDouble(daystart5.Text);
                    NannyWorks2[4, 1] = switctTimeToDouble(dayend5.Text);
                }
                if (this.day6.IsChecked == true)
                {
                    NannyWorks[5] = true;
                    NannyWorks2[5, 0] = switctTimeToDouble(daystart6.Text);
                    NannyWorks2[5, 1] = switctTimeToDouble(dayend6.Text);
                }

                N.NannyIsWorkingOnDay = NannyWorks;//places the context of both arrays into arrays in N
				N.NannyTimeIsWorkingOnDay = NannyWorks2;
                bl.AddNanny(N);//adds Nanny to program
				N = new BE.Nanny();
                this.DataContext = N;//puts default context into all context on window
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
