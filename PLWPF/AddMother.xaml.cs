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
    /// Interaction logic for AddMother.xaml
    /// </summary>
    public partial class AddMother : Window
    {
        BE.Mother M;//Building a mother - type object
        BL.IBL bl;//Builds an IBL type object
        public AddMother()
        {
            InitializeComponent();//Startup (initializes component)
            M = new BE.Mother();
            this.DataContext = M;//Displays on the screen the fields of the object being built
            bl = BL.FactoryBL.GetBL();//Links the panel to the BL database
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
			if ((c >= 25) || (Convert.ToDouble(a2) / 60 >= 1)||(c<0))
				throw new Exception("not a time");
			return c;
		}
        private void Button_Click(object sender, RoutedEventArgs e)
        //What happens in the program when you click the button (as is said when you start the Click event)
        {
            try
            {
                if (M.MotherId >999999999)
                    throw new Exception("your id is not valid");
                if (M.MotherId == 0)
                    throw new Exception("your id is not valid");
                bool[] motherNeedsNannyhelp = new bool[6];//define an array of days when the mother needs a nanny
                for (int i = 0; i < 6; i++)//initialize the array in false
                {
                    motherNeedsNannyhelp[i] = false;
                }
                double[,] motherTimeNeedsNannyhelp = new double[6, 2];//define an array of hours during which the mother needs nanny
                if (this.day1.IsChecked == true)//If the mother indicated she needed a nanny on this day
                {
                    motherNeedsNannyhelp[0] = true;//We set the first array on this day, to be true
                    motherTimeNeedsNannyhelp[0,0] = switctTimeToDouble(daystart1.Text);//take the user's start time from the screen and insert it into the array of hours
                    motherTimeNeedsNannyhelp[0, 1] = switctTimeToDouble(dayend1.Text);//take the user's end time from the screen and insert it into the array of hours
                }
                if (this.day2.IsChecked == true)
                {
                    motherNeedsNannyhelp[1] = true;
                    motherTimeNeedsNannyhelp[1, 0] = switctTimeToDouble(daystart2.Text);
                    motherTimeNeedsNannyhelp[1, 1] = switctTimeToDouble(dayend2.Text);
                }
                if (this.day3.IsChecked == true)
                {
                    motherNeedsNannyhelp[2] = true;
                    motherTimeNeedsNannyhelp[2, 0] = switctTimeToDouble(daystart3.Text);
                    motherTimeNeedsNannyhelp[2, 1] = switctTimeToDouble(dayend3.Text);
                }
                if (this.day4.IsChecked == true)
                {
                    motherNeedsNannyhelp[3] = true;
                    motherTimeNeedsNannyhelp[3, 0] = switctTimeToDouble(daystart4.Text);
                    motherTimeNeedsNannyhelp[3, 1] = switctTimeToDouble(dayend4.Text);
                }
                if (this.day5.IsChecked == true)
                {
                    motherNeedsNannyhelp[4] = true;
                    motherTimeNeedsNannyhelp[4, 0] = switctTimeToDouble(daystart5.Text);
                    motherTimeNeedsNannyhelp[4, 1] = switctTimeToDouble(dayend5.Text);
                }
                if (this.day6.IsChecked == true)
                {
                    motherNeedsNannyhelp[5] = true;
                    motherTimeNeedsNannyhelp[5, 0] = switctTimeToDouble(daystart6.Text);
                    motherTimeNeedsNannyhelp[5, 1] = switctTimeToDouble(dayend6.Text);
                }
                M.MotherTimeNeedsNanny=motherTimeNeedsNannyhelp;//send the array of days we have built as the array of days of the object "mother"
                M.MotherNeedsNanny = motherNeedsNannyhelp;//send the array of hours we have built as the array of hours of the object "mother"
                bl.AddMother(M);//Add the M object to the "mother" list in the BL database
                M = new BE.Mother();//initialize M as an empty object of the mother type
                this.DataContext = M;//Set the fields of the screen to M
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
