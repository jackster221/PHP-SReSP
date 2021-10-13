using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPReSP.Classes
{

    class MonthsRevenue : IChartData
    {
        public List<double> revenues = new List<double>();
        public List<string> months = new List<string>();

        public MonthsRevenue()
        {

            PopulateLists();
            
        }

        public void PopulateLists()
        {
            revenues.Clear();
            months.Clear();

            MySqlConnection connection = new MySqlConnection(
           "server=localhost;uid=root;pwd=password;database=phpsreps_db");

            connection.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT EXTRACT(YEAR_MONTH FROM sales.SaleDate) AS Month, SUM(sales.NumberSold * products.sellPrice) AS Revenue FROM sales INNER JOIN Products ON Products.productID = sales.ProductID GROUP BY Month ORDER BY sales.SaleDate; ", connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.FieldCount > 0)
            {
                while (reader.Read())
                {
                    this.months.Add(reader[0].ToString());
                    this.revenues.Add(Convert.ToDouble(reader[1]));
                }
            }


            reader.Close();

            connection.Close();

        }


    }
}
