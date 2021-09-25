using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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

        private void AddCSVData(object sender, RoutedEventArgs e)
        {
            var filedlog = new OpenFileDialog();
            filedlog.Title = "Open CSV File";
            filedlog.Filter = "CSV Files (*.csv)|*.csv";

            filedlog.Multiselect = false;
            if (filedlog.ShowDialog() == true)
            {
                string filename = "";
                filename = filedlog.FileName;

                ListViewSales.ItemsSource = null;
                ListViewSales.ItemsSource = Manager.ReadCSV(filename);
            }
        }

        private void ExportCSV(object sender, RoutedEventArgs e)
        {
            Manager.SaveToCSV(Manager._records);
        }

        // Open the dialog to enter a new sale
        private void AddNewSale(object sender, RoutedEventArgs e)
        {
            AddSaleRecordPage page = new AddSaleRecordPage();
            page.ShowDialog();
        }

        private void OpenProductsTab(object sender, RoutedEventArgs e)
        {
            DisplayProducts page = new DisplayProducts();
            page.ShowDialog();
        }
    }
}

