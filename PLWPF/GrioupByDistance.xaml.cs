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
    /// Interaction logic for GrioupByDistance.xaml
    /// </summary>
    public partial class GrioupByDistance : Window
    {
        BL.IBL bl;
        List<BE.Contract>[] G;

        public GrioupByDistance()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            System.ComponentModel.BackgroundWorker work = new System.ComponentModel.BackgroundWorker();
            work.DoWork += W_DoWork;
            work.RunWorkerCompleted += W_RunWorkerCompleted;
            work.RunWorkerAsync();
        }


        private void W_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {//divids contracts acourding to distance and puts them in G
            try
            {
                G = bl.dividContractByDistance();

            }
            catch (Exception)
            {

            }
        }
        private void W_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{//shows the contracts distaces in distanceBox so user can chose which to see
			foreach (List<BE.Contract> item in G)
            {

                distanceBox.Items.Add(item.First().Distance);
            }


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{//acourding to what distance user choses will be displad on groupUser
			foreach (List<BE.Contract> item in G)
            {
                if (item.First().Distance == ((int)this.distanceBox.SelectedItem))
                    groupUser.set(item, item.First().Distance);
            }
            
        }
    } 
}
