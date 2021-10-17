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

namespace PHPReSP
{
    public partial class HomeInterface : Window
    {

        private DataManager Manager = new DataManager();

        public HomeInterface()
        {
            InitializeComponent();
        }

        private void ExportCSV(object sender, RoutedEventArgs e)
        {
            List<SalesRecord> records = new List<SalesRecord>();

            Manager.ConvertDBtoSalesObj();
            Manager.SaveToCSV(Manager.records);
        }

        private void Sales(object sender, RoutedEventArgs e)
        {
            SalesPage page = new SalesPage();
            page.Show();
            this.Close();
        }

        private void Report(object sender, RoutedEventArgs e)
        {
            GenerateReport page = new GenerateReport();
            page.Show();
            this.Close();
        }

        private void Products(object sender, RoutedEventArgs e)
        {
            ProductRecordPage page = new ProductRecordPage();
            page.Show();
            this.Close();
        }
    }
}
