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

            MySqlCommand cmd = new MySqlCommand("SELECT EXTRACT(YEAR_MONTH FROM sales.SaleDate) AS Month, SUM(sales.NumberSold * products.Price) AS Revenue FROM sales INNER JOIN Products ON Products.productID = sales.ProductID GROUP BY Month ORDER BY sales.SaleDate; ", connection);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.FieldCount > 0)
            {
                while (reader.Read())
                {
                    string curDate = reader[0].ToString().Substring(4);

                    switch (curDate)
                    {
                        case "01":
                            this.months.Add("January");
                            break;
                        case "02":
                            this.months.Add("Febuary");
                            break;
                        case "03":
                            this.months.Add("March");
                            break;
                        case "04":
                            this.months.Add("April");
                            break;
                        case "05":
                            this.months.Add("May");
                            break;
                        case "06":
                            this.months.Add("June");
                            break;
                        case "07":
                            this.months.Add("July");
                            break;
                        case "08":
                            this.months.Add("August");
                            break;
                        case "09":
                            this.months.Add("September");
                            break;
                        case "10":
                            this.months.Add("October");
                            break;
                        case "11":
                            this.months.Add("November");
                            break;
                        case "12":
                            this.months.Add("December");
                            break;

                    }
                    
                    this.revenues.Add(Convert.ToDouble(reader[1]));
                }
            }


            reader.Close();

            connection.Close();

        }


    }
}
