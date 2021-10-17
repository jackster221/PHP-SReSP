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

    public partial class EditExisitngSalePage : Window
    {
        public EditExisitngSalePage()
        {
            InitializeComponent();
        }

        private void EditSale(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");

            try
            { 
                MySqlCommand cmd = new MySqlCommand("update Sales set ProductID = '" + ProductIDBox.Text +
                    "', NumberSold = '" + NumberSoldBox.Text + "', SaleDate = '" + Convert.ToDateTime(SaleDateBox.Text).ToString("yyyy-MM-dd") + 
                    "' where SaleID = " + SaleID.Text, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated");
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
            Hide();
            
        }
    }
}
