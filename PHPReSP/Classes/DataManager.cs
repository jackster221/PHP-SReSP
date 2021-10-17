using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PHPReSP
{
    class DataManager
    {

        public List<SalesRecord> records = new List<SalesRecord>();

        public DataManager()
        {

        }


        public void ReadCSV(string fileName)
        {

            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));

            foreach (string line in lines)
            {
                string[] data = line.Split(',');


                //DateTime purchaseDate = new DateTime(Convert.ToInt32(dateData[0]), Convert.ToInt32(dateData[1]), Convert.ToInt32(dateData[2]));

                SalesRecord curRecord = new SalesRecord(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), data[2]);

                AddNewRecord(curRecord);
            }

        }


        public void SaveToCSV<T>(List<T> salesData)
        {
            SaveFileDialog saveFiledlg = new SaveFileDialog();
            saveFiledlg.Title = "SalesData";
            saveFiledlg.Filter = "CSV Files (*.csv)|*.csv";

            if (saveFiledlg.ShowDialog() == true)
            {
                var lines = new List<string>();
                IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
                var header = string.Join(",", props.ToList().Select(x => x.Name));
                lines.Add(header);
                var valueLines = salesData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
                lines.AddRange(valueLines);
                File.WriteAllLines(saveFiledlg.FileName, lines.ToArray());
            }
        }

        public void AddNewRecord(SalesRecord curRecord)
        {

            MySqlConnection connection = new MySqlConnection(
            "server=localhost;uid=root;pwd=password;database=phpsreps_db");


            MySqlCommand cmd = new MySqlCommand("Insert Into Sales (ProductID,NumberSold,SaleDate) values " +
                "(" + curRecord.ProductID + "," + curRecord.NumberSold +
                ", \"" + Convert.ToDateTime(curRecord.SaleDate).ToString("yyyy-MM-dd") + "\");", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public void ConvertDBtoSalesObj()
        {
            records.Clear();

            MySqlConnection connection = new MySqlConnection(
            "server=localhost;uid=root;pwd=password;database=phpsreps_db");

            connection.Open();

            MySqlCommand cmd = new MySqlCommand("Select * From Sales;", connection);
            
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                records.Add(new SalesRecord(Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2]), reader[3].ToString(), Convert.ToInt32(reader[0])));
            }

            reader.Close();
            
            connection.Close();
            
        }

    }
}