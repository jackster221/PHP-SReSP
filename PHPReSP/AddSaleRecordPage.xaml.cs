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
            MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;");

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("Insert Into Sales (ProductID,NumberSold,SaleDate) values " +
                    ProductIDBox.Text + "," + NumberSoldBox.Text + "," + SaleDateBox.SelectedDate, connection);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            connection.Close();

            Hide();

        }
    }
}
