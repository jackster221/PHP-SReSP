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
using MySql.Data.MySqlClient;
using System.Data;


namespace PHPReSP
{
    /// <summary>
    /// Interaction logic for SearchSalesRecordsPage.xaml
    /// </summary>
    public partial class SearchSalesRecordsPage : Window
    {
        public SearchSalesRecordsPage()
        {
            InitializeComponent();
        }

        private void SearchRecordsByPID(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    using (DataTable dt = new DataTable("SearchResults"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Sales WHERE ProductID = '"+ EnterData.Text + "' ", connection))
                        {
                            cmd.Parameters.AddWithValue("ProductID", EnterData.Text);
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            SearchResults.ItemsSource = dt.DefaultView;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot Connect to the Database", MessageBoxButton.OK);
            }
        }

        private void SearchRecordsByDate(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    using (DataTable dt = new DataTable("SearchResults"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM Sales WHERE SaleDate = '" + Convert.ToDateTime(EnterDate.Text).ToString("dd/mm/yyyy") + "' ", connection))
                        {
                            cmd.Parameters.AddWithValue("SaleDate", EnterDate.Text);
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            SearchResults.ItemsSource = dt.DefaultView;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot Connect to the Database", MessageBoxButton.OK);
            }
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //vie refreecne
        }

    }
}
