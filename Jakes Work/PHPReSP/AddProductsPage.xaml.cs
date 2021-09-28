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
    public partial class AddProductsPage : Window
    {
        public AddProductsPage()
        {
            InitializeComponent();
        }

        private void AddNewProduct(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");

            try
            {
                MySqlCommand cmd = new MySqlCommand("Insert Into Products (ProductName,Category,RestockPrice,SellPrice,CurrentInventory) values " +
                    "(\"" + ProductNameBox.Text + "\",\"" + ProductCategoryBox.Text +
                    "\"," + RestockPriceBox.Text + "," + SellPriceBox.Text + "," +
                    AmountInStockBox.Text + ");", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Hide();

        }
    }
}