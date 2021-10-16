using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPReSP.Classes
{

    class ItemsRevenue : IChartData
    {
        public List<double> revenues = new List<double>();
        public List<string> items = new List<string>();

        public ItemsRevenue()
        {

            PopulateLists();
           
        }

        public void PopulateLists()
        {
            revenues.Clear();
            items.Clear();

            MySqlConnection connection = new MySqlConnection(
           "server=localhost;uid=root;pwd=password;database=phpsreps_db");

            connection.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT products.productName, SUM(sales.NumberSold * products.Price) AS Revenue FROM sales INNER JOIN Products ON Products.productID = sales.ProductID GROUP BY ProductName; ", connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.FieldCount > 0)
            {
                while (reader.Read())
                {
                    this.items.Add(reader[0].ToString());
                    this.revenues.Add(Convert.ToDouble(reader[1]));
                }
            }


            reader.Close();

            connection.Close();

        }
    }
}
