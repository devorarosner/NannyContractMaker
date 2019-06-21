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
    /// Interaction logic for MotherWindow.xaml
    /// </summary>
    public partial class MotherWindow : Window
    {
        public MotherWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new AddMother().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new ShowMother().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new RemoveMother().ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new MotherChangeNotes().ShowDialog();
        }
    }
}
