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
    public partial class MainWindow : Window, IRefresh
    {

        MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");

        private DataManager Manager = new DataManager();

        private Refresh myRefresh = new Refresh();



        public MainWindow()
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
            //Manager.SaveToCSV(Manager._records);
        }

        // Open the dialog to enter a new sale
        private void Open_New_Sale(object sender, RoutedEventArgs e)
        {
            AddSaleRecordPage page = new AddSaleRecordPage();
            page.ShowDialog();
        }


        private void ViewProducts(object sender, RoutedEventArgs e)
        {
            ProductRecordPage page = new ProductRecordPage();
            page.ShowDialog();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //vie refreecne
        }

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
            //update inventory
            int SaleAmount;
            int Stock;
            int ProductID;
            MySqlCommand cmd5 = new MySqlCommand("SELECT ProductID FROM Sales WHERE SaleID=" + Int32.Parse(searchbyID.Text) + ";", connection);
            
            connection.Open();
            ProductID = (Int32)cmd5.ExecuteScalar();
            connection.Close();
            MySqlCommand cmd2 = new MySqlCommand("SELECT CurrentInventory FROM Products WHERE ProductID=" + ProductID + ";", connection);
            MySqlCommand cmd3 = new MySqlCommand("SELECT NumberSold FROM Sales WHERE SaleID=" + Int32.Parse(searchbyID.Text) + ";", connection);
            connection.Open();
            Stock = (Int32)cmd2.ExecuteScalar();
            SaleAmount = (Int32)cmd3.ExecuteScalar();
            Stock = Stock + SaleAmount;
            connection.Close();
            MySqlCommand cmd4 = new MySqlCommand("update Products set CurrentInventory=" + Stock + " where ProductID=" + ProductID + ";", connection);
            connection.Open();
            cmd4.ExecuteNonQuery();
            connection.Close();

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
            page.ShowDialog();
        }

    }

}


