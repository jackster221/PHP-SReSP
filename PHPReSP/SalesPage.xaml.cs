using Microsoft.Win32;
using MySql.Data.MySqlClient;
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
    public partial class SalesPage : Window, IRefresh
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");

        private DataManager Manager = new DataManager();

        private Refresh myRefresh = new Refresh();

        public SalesPage()
        {
            InitializeComponent();
            myRefresh.RefreshDataGrid(Maindatagrid, "Sales");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) 
        {
            RefreshGrid();
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


                Manager.ReadCSV(filename);
            }

            myRefresh.RefreshDataGrid(Maindatagrid, "Sales");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<SalesRecord> records = new List<SalesRecord>();

            Manager.ConvertDBtoSalesObj();
            Manager.SaveToCSV(Manager.records);
        }

        // Open the dialog to enter a new sale
        private void Open_New_Sale(object sender, RoutedEventArgs e)
        {
            AddSaleRecordPage page = new AddSaleRecordPage();
            Products page2 = new Products();
            page2.Show(); 
            page.Show();
            this.Close();
        }


        private void ViewSalesProfit(object sender, RoutedEventArgs e)
        {
            SalesProfitPage page = new SalesProfitPage();
            page.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e) { }

        private void RefreshGrid(object sender, RoutedEventArgs e)
        {
            myRefresh.RefreshDataGrid(Maindatagrid, "Sales");
        }
        public void RefreshGrid()
        {
            myRefresh.RefreshDataGrid(Maindatagrid, "Sales");
        }

        private void DeleteRecord(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Sales where SaleID = " + searchbyID.Text + " ", connection);
            connection.Open();

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted");

                connection.Close();
                myRefresh.RefreshDataGrid(Maindatagrid, "Sales");

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                connection.Close();
            }
        }

        private void Edit_Sales_Record(object sender, RoutedEventArgs e)
        {
            EditExisitngSalePage page = new EditExisitngSalePage();
            page.Show();
        }

        private void Button_Click_LineChart(object sender, RoutedEventArgs e)
        {
            var viewer = new LineChartViewer();
            viewer.Show();

        }

        private void Button_Click_BarChart(object sender, RoutedEventArgs e)
        {
            var viewer = new BarChartViewer();
            viewer.Show();

        }

        private void Button_Click_Prediction(object sender, RoutedEventArgs e)
        {
            PredictionPage page = new PredictionPage();
            page.Show();
        }

        private void ViewProducts(object sender, RoutedEventArgs e)
        {
            ProductRecordPage page = new ProductRecordPage();
            page.Show();
        }

        private void FinalReport(object sender, RoutedEventArgs e)
        {
            GenerateReport page = new GenerateReport();
            page.Show();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            HomeInterface page = new HomeInterface();
            page.Show();
            this.Close();
        }
    }

}


