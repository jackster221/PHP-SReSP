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

    public partial class ProductRecordPage : Window, IRefresh
    {

        MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");

        private Refresh myRefresh = new Refresh();

        public ProductRecordPage()
        {
            InitializeComponent();
            myRefresh.RefreshDataGrid(ProductsGrid, "Products");
        }

        private void AddNewProduct(object sender, RoutedEventArgs e)
        {
            AddProductsPage page = new AddProductsPage();
            page.ShowDialog();
        }

        private void EditProduct(object sender, RoutedEventArgs e)
        {
            int result=0;
            MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");
            try
            {
                MySqlCommand cmd = new MySqlCommand("select COUNT(1) from products where ProductID = '" + EditProductID.Text + "';", connection);
                connection.Open();
                result = (int)(long)cmd.ExecuteScalar();
                connection.Close();
            }
            catch { }
            
            if (result == 1)
            {
                EditProductPage page = new EditProductPage(EditProductID.Text);
                page.ShowDialog();
            }
            else
            {
                MessageBox.Show("Make sure to enter a valid Product Id number first before pressing edit.");
            }
        }

        private void UpdateInventory(object sender, RoutedEventArgs e)
        {
            if(EditInventoryID.Text != "" & EditInventoryAmount.Text != "")
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");
                try
                {
                    MySqlCommand cmd = new MySqlCommand("update Products set CurrentInventory=" + Int32.Parse(EditInventoryAmount.Text) + " where ProductID=" + Int32.Parse(EditInventoryID.Text) + ";", connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    //refresh datagrid here?
                    connection.Close();
                    MessageBox.Show("Done");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void SetRestockLevel(object sender, RoutedEventArgs e)
        {
            if (RestockProductID.Text != "" & RestockLevel.Text != "")
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");
                try
                {
                    MySqlCommand cmd = new MySqlCommand("update Products set RestockLevel=" + Int32.Parse(RestockLevel.Text) + " where ProductID=" + Int32.Parse(RestockProductID.Text) + ";", connection);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Done");
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void RefreshGrid(object sender, RoutedEventArgs e)
        {
            myRefresh.RefreshDataGrid(ProductsGrid, "Products");
        }
    }
}
