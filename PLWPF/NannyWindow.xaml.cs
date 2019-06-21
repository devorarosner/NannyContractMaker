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
    /// Interaction logic for NannyWindow.xaml
    /// </summary>
    public partial class NannyWindow : Window
    {
        public NannyWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddNanny().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new ShowNanny().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new RemoveNanny().ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new NannyRecommendations().ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new Minstrey().ShowDialog();
        }
    }
}
