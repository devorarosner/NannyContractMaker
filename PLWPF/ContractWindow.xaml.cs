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
    /// Interaction logic for ContractWindow.xaml
    /// </summary>
    public partial class ContractWindow : Window
    {
        public ContractWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddContract().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new ShowContract().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new ContarctCanged().ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new RemoveContract().ShowDialog();
        }
    }
}
