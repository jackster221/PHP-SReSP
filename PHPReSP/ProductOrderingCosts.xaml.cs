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

    public partial class ProductOrderingCosts : Window, IRefresh
    {

        MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");

        private Refresh myRefresh = new Refresh();

        public ProductOrderingCosts()
        {
            InitializeComponent();
            LoadGrid();
        }
        
        public void LoadGrid()
        {
            MySqlCommand cmd = new MySqlCommand("select ProductID, ProductName, RestockPrice, CurrentInventory, RestockPrice * CurrentInventory as OrderingCosts from Products", connection);
            DataTable dt = new DataTable();
            connection.Open();
            MySqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            connection.Close();
            ProductsGrid.ItemsSource = dt.DefaultView;
        }
    }
}
 