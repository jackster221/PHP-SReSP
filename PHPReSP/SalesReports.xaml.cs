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
    /// Interaction logic for SalesReports.xaml
    /// </summary>
    public partial class SalesReports : Window
    {
        public SalesReports()
        {
            InitializeComponent();
        }

        private void FullReport(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    using (DataTable dt = new DataTable("SalesReport"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("select p.ProductID, p.ProductName, SellPrice, SUM(NumberSold) as UnitsSold, Round(SellPrice * SUM(NumberSold), 2) as TotalEarned, CurrentInventory - SUM(NumberSold) as InventoryLevel, SUM(NumberSold) as RestockUnitsNeeded, round(SUM(NumberSold) * RestockPrice, 2) as TotalRestockExp, (SellPrice * SUM(NumberSold)) - (SUM(NumberSold) * RestockPrice) as ProfitAfterRestock FROM sales s NATURAL JOIN products p Group by ProductID ", connection))
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            SalesReport.ItemsSource = dt.DefaultView;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot Connect to the Database", MessageBoxButton.OK);
            }
        }

        private void ThisMonth(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    using (DataTable dt = new DataTable("SalesReport"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("select p.ProductID, p.ProductName, SellPrice, SUM(NumberSold) as UnitsSold, Round(SellPrice * SUM(NumberSold), 2) as TotalEarned, CurrentInventory - SUM(NumberSold) as InventoryLevel, SUM(NumberSold) as RestockUnitsNeeded, round(SUM(NumberSold) * RestockPrice, 2) as TotalRestockExp, (SellPrice * SUM(NumberSold)) - (SUM(NumberSold) * RestockPrice) as ProfitAfterRestock FROM sales s NATURAL JOIN products p WHERE MONTH(SaleDate) = MONTH(now()) Group by ProductID ", connection))
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            SalesReport.ItemsSource = dt.DefaultView;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot Connect to the Database", MessageBoxButton.OK);
            }
        }

        private void LastMonth(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    using (DataTable dt = new DataTable("SalesReport"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("select p.ProductID, p.ProductName, SellPrice, SUM(NumberSold) as UnitsSold, Round(SellPrice * SUM(NumberSold), 2) as TotalEarned, CurrentInventory - SUM(NumberSold) as InventoryLevel, SUM(NumberSold) as RestockUnitsNeeded, round(SUM(NumberSold) * RestockPrice, 2) as TotalRestockExp, (SellPrice * SUM(NumberSold)) - (SUM(NumberSold) * RestockPrice) as ProfitAfterRestock FROM sales s NATURAL JOIN products p WHERE MONTH(SaleDate) = MONTH(now()) -1 Group by ProductID ", connection))
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            SalesReport.ItemsSource = dt.DefaultView;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot Connect to the Database", MessageBoxButton.OK);
            }
        }

        private void LastWeek(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    using (DataTable dt = new DataTable("SalesReport"))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("select p.ProductID, p.ProductName, SellPrice, SUM(NumberSold) as UnitsSold, Round(SellPrice * SUM(NumberSold), 2) as TotalEarned, CurrentInventory - SUM(NumberSold) as InventoryLevel, SUM(NumberSold) as RestockUnitsNeeded, round(SUM(NumberSold) * RestockPrice, 2) as TotalRestockExp, (SellPrice * SUM(NumberSold)) - (SUM(NumberSold) * RestockPrice) as ProfitAfterRestock FROM sales s NATURAL JOIN products p WHERE WEEK(SaleDate) = WEEK(now())-1 Group by ProductID ", connection))
                        {
                            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            SalesReport.ItemsSource = dt.DefaultView;
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
