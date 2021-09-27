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
        private MySqlConnection con = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");

        public MainWindow()
        {
            InitializeComponent();
            LoadGrid();
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
       
                Manager.ReadCSV(filename);
            }

            LoadGrid();
        }




        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<SalesRecord> records = new List<SalesRecord>();

          
            Manager.SaveToCSV(Manager._records);
        }

        // Open the dialog to enter a new sale
        private void Open_New_Sale(object sender, RoutedEventArgs e)
        {
            AddSaleRecordPage page = new AddSaleRecordPage();
            page.ShowDialog();
        }



        private void RefreshGrid(object sender, RoutedEventArgs e)
        {
            LoadGrid();
        }


        public void LoadGrid()
        {
            MySqlCommand cmd = new MySqlCommand("select * from Sales", con);
            DataTable dt = new DataTable();
            con.Open();
            MySqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid_salesdata.ItemsSource = dt.DefaultView;
        }


        private void DeleteRecord(object sender, RoutedEventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Sales where ProductID = " + searchbyID.Text + " ", con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted");
                con.Close();
                LoadGrid();
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            LoadGrid();
        }


        private void Edit_Sales_Record(object sender, RoutedEventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("update Sales set ProductID = '" + productID.Text + "', NumberSold = '" + numberSold.Text + "', SaleDate = '" + Convert.ToDateTime(SaleDateBox.Text).ToString("yyyy-MM-dd") + "' where ProductID = " + searchbyID.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
                con.Close();
                LoadGrid();
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            LoadGrid();

        }


    }
}
