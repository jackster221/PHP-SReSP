using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PHPReSP
{
    /// <summary>
    /// Interaction logic for AddRecord.xaml
    /// </summary>
    public partial class AddSaleRecordPage : Window
    {
        public AddSaleRecordPage()
        {
            InitializeComponent();

        }


        // When the button is pressed add new sales record
        private void AddNewRecord(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(
                "server=localhost;uid=root;pwd=password;database=phpsreps_db");

            try
            {

                MySqlCommand cmd = new MySqlCommand("Insert Into Sales (ProductID,NumberSold,SaleDate) values " +
                    "(" + ProductIDBox.Text + "," + NumberSoldBox.Text +
                    ", \"" + Convert.ToDateTime(SaleDateBox.Text).ToString("yyyy-MM-dd") + "\");", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }


            Int32 stock = 0;
            string productName;
            int RestockAmnt;
            try
            {
                MySqlCommand cmd2 = new MySqlCommand("SELECT CurrentInventory FROM Products WHERE ProductID=" + Int32.Parse(ProductIDBox.Text) + ";", connection);

                connection.Open();
                stock = (Int32)cmd2.ExecuteScalar();
                stock = stock - Int32.Parse(NumberSoldBox.Text);
                connection.Close();

                MySqlCommand cmd = new MySqlCommand("update Products set CurrentInventory=" + stock + " where ProductID=" + Int32.Parse(ProductIDBox.Text) + ";", connection);
                MySqlCommand cmd3 = new MySqlCommand("SELECT ProductName FROM Products WHERE ProductID="+ Int32.Parse(ProductIDBox.Text) + ";", connection);
                MySqlCommand cmd4 = new MySqlCommand("SELECT RestockLevel FROM Products WHERE ProductID=" + Int32.Parse(ProductIDBox.Text) + ";", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                productName = (string)cmd3.ExecuteScalar();
                RestockAmnt = (Int32)cmd4.ExecuteScalar();
                connection.Close();

                //just picked 10 as the low amount. Can easily be changed
                if (stock <= RestockAmnt)
                {
                    MessageBox.Show("Warning: Stock Level on " + productName + " is low (less than "+ RestockAmnt +"). Current stock amount: " + stock);
                }
                else
                {
                    MessageBox.Show("Done");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            Hide();
        }
    }
}