﻿using System;
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
    /// Interaction logic for GroupBy.xaml
    /// </summary>
    public partial class GroupBy : Window
    {
        public GroupBy()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new GrioupByDistance().ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new GroupByAge().ShowDialog();
        }
    }
}
