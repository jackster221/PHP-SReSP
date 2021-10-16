
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPReSP
{

    class SalesRecord
    {
        public int ProductID { get; set; }
        //public string ProductID { get; set; }
        public int NumberSold { get; set; }
        public string SaleDate { get; set; }
        public double TotalCost { get; set; }
        public string Item { get; set; }



        public SalesRecord(int product, int NumberSold, string SaleDate, int ID = -9999)
        {
            if (ID != -9999)
            {
                ProductID = ID;

                MySqlConnection connection = new MySqlConnection(
            "server=localhost;uid=root;pwd=password;database=phpsreps_db");

                connection.Open();

                MySqlCommand cmd = new MySqlCommand("Select products.productName, SUM(sales.NumberSold * products.Price) As Revenue From Sales INNER JOIN Products ON products.ProductID = Sales.ProductID WHERE sales.SaleID =" + ID + ";", connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                if(reader.FieldCount > 0)
                {
                    while (reader.Read())
                    {
                        this.Item = reader[0].ToString();
                        this.TotalCost = Convert.ToDouble(reader[1]);
                    }
                }
                

                reader.Close();

                connection.Close();
            }

            this.ProductID = product;
            this.SaleDate = SaleDate;
            this.NumberSold = NumberSold;

            

        }

    }
}
