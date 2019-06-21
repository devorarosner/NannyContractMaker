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
    /// Interaction logic for GroupByAge.xaml
    /// </summary>
    public partial class GroupByAge : Window
    {
        BL.IBL bl;
        List<BE.Nanny>[] G;
        List<BE.Nanny> old;
        public GroupByAge()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            old = new List<BE.Nanny>();
            G = bl.dividNannyByMaxOrMinAge(true);
            foreach (List<BE.Nanny> item in G)
            {
                if(item.Count>0)
                   MaxAge.Items.Add(item.First().NannyMaxAgeOfKid_InMonth/12);
            }
        }

        private void MaxAge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			if (old.Count() > 0)//if nannyDataGrid has old stuff in it it will be removed
			{
				foreach (BE.Nanny item3 in old)
				{
					this.nannyDataGrid.Items.Remove(item3);
				}
			}
            foreach (List<BE.Nanny> item in G)
            {
				if (item.Count() > 0)
					if (item.First().NannyMaxAgeOfKid_InMonth/12 == ((int)this.MaxAge.SelectedItem))
                {
                    foreach (BE.Nanny item2 in item)//places all nannys in show that match chosen NannyMaxAgeOfKid_InMonth 
						{
                        nannyDataGrid.Items.Add(item2);
                        old.Add(item2);
                    }
                }
            }
        }
    }
}
