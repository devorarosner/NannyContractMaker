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
	/// Interaction logic for BestContracts.xaml
	/// </summary>
	public partial class BestContracts : Window
	{
		BL.IBL bl;
		BE.Mother M;
		List<BE.Nanny> nannys;
		BE.Nanny[] N;

		public BestContracts(int motherid)
		{
			InitializeComponent();
			bl = BL.FactoryBL.GetBL();
			M = new BE.Mother();
			M = bl.findMother(motherid);
			this.DataContext = M;
			nannys = bl.workRightTimeforMother(M);//A list of nannies that work exactly at the times the mother needs
			if (nannys.Count() < 5)//If the number of nannies who work exactly when the mother needs it is less than 5
			{
				N = bl.bestNannysForMother(M);//find the 5 nannies that are suitable for Mom (but their hours do not coincide exactly with the hours she needs)
				foreach (BE.Nanny item in N)
				{
					this.nannyDataGrid.Items.Add(item);// find the 5 nannies that are suitable for Mom(but their hours do not coincide exactly with the hours she needs)
				}
			}
			else
			{
				foreach (BE.Nanny item in nannys)
				{
					this.nannyDataGrid.Items.Add(item);
				}
			}
		}

		private void CheckBox_Checked(object sender, RoutedEventArgs e)
		//A function that shows the caregivers and takes into account the distance
		{
			//Clear the panel
			if (nannys.Count() < 5)
			{
				foreach (BE.Nanny item in N)
				{
					this.nannyDataGrid.Items.Remove(item);
				}
			}
			else
			{
				foreach (BE.Nanny item in nannys)
				{
					this.nannyDataGrid.Items.Remove(item);
				}
			}
			//Running a treadmill that shows the caregivers that also fit the desired distance
			System.ComponentModel.BackgroundWorker work = new System.ComponentModel.BackgroundWorker();
			work.DoWork += W_DoWork;
			work.RunWorkerCompleted += W_RunWorkerCompleted;
			work.RunWorkerAsync();

		}
		private void W_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		//A function that runs a thread that copies the nannys to the list of caregivers most suitable for the distance and hours the mother needs
		{
			try
			{
				nannys = bl.ClosestAndBestNanny(M);

			}
			catch (Exception)
			{

			}
		}
		private void W_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		//Displays on the screen the caregivers on the above list
		{
			foreach (BE.Nanny item in nannys)
			{
				this.nannyDataGrid.Items.Add(item);
			}
		}
		private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
		{
			//Clears the panel from previous details
			
			foreach (BE.Nanny item in nannys)
			{
				this.nannyDataGrid.Items.Remove(item);
			}
			nannys = bl.workRightTimeforMother(M);
			if (nannys.Count() < 5)
			{
				N = bl.bestNannysForMother(M);
				foreach (BE.Nanny item in N)
				{
					this.nannyDataGrid.Items.Add(item);
				}
			}
			else
			{
				foreach (BE.Nanny item in nannys)
				{
					this.nannyDataGrid.Items.Add(item);
				}
			}
		}
	}
}

