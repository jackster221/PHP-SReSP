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
    class Refresh : IRefresh
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=password;database=phpsreps_db");

        public void RefreshDataGrid(DataGrid dtg, string table)
        {
            MySqlCommand cmd = new MySqlCommand("select * from " + table, connection);
            DataTable dt = new DataTable();
            connection.Open();
            MySqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            connection.Close();
            dtg.ItemsSource = dt.DefaultView;
        }

    }
}
