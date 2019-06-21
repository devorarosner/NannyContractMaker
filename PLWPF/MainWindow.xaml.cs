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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ChildWindow().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new MotherWindow().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new NannyWindow().ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new ContractWindow().ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new Payment().ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            new GroupBy().ShowDialog();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            new NannyAmoutOfKids().ShowDialog();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            new ChildNoNanny().ShowDialog();
        }
    }
}
