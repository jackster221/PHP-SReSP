﻿using Microsoft.Win32;
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

namespace PHPReSP
{

    public partial class MainWindow : Window
    {

        private DataManager Manager = new DataManager();
        
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var filedlog = new OpenFileDialog();
            filedlog.Title = "Open CSV File";
            filedlog.Filter = "CSV Files (*.csv)|*.csv";

            filedlog.Multiselect = false;
            if (filedlog.ShowDialog() == true)
            {
                string filename = "";
                filename = filedlog.FileName;
                ListViewSales.ItemsSource = Manager.ReadCSV(filename);
            }

            
        }
    }
}
