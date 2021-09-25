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

    public partial class MainWindow : Window
    {

        private DataManager Manager = new DataManager();

        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
        }

        MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");

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

                //ListViewSales.ItemsSource = null;
                //ListViewSales.ItemsSource = Manager.ReadCSV(filename);
            }


        }




        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.SaveToCSV(Manager._records);
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
            LoadGrid();
        }

        public void LoadGrid()
        {
            MySqlCommand cmd = new MySqlCommand("select * from Sales", connection);
            DataTable dt = new DataTable();
            connection.Open();
            MySqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            connection.Close();
            datagrid.ItemsSource = dt.DefaultView;
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
                LoadGrid();
                connection.Close();
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
           
            MySqlCommand cmd = new MySqlCommand("update Sales set ProductID = '" + productID.Text + "', NumberSold = '" + numberSold.Text + "', SaleDate = '" + Convert.ToDateTime(SaleDateBox.Text).ToString("yyyy-MM-dd") + "' where ProductID = " + searchbyID.Text + " ", connection);
            connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                connection.Close();
                LoadGrid();
                connection.Close();
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
    }
}