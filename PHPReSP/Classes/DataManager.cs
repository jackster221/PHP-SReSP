using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PHPReSP
{
    class DataManager
    {

        public List<SalesRecord> _records = new List<SalesRecord>();

        public DataManager()
        {

        }

        
        public IEnumerable<SalesRecord> ReadCSV(string fileName)
        {

            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));

            foreach(string line in lines)
            {
                string[] data = line.Split(',');

                string[] dateData = data[2].Split("/");

                DateTime purchaseDate = new DateTime(Convert.ToInt32(dateData[0]), Convert.ToInt32(dateData[1]), Convert.ToInt32(dateData[2]));

                SalesRecord curRecord = new SalesRecord(Convert.ToInt32(data[0]), data[1], purchaseDate, Convert.ToDouble(data[3]), Convert.ToInt32(data[4]));
                
                this._records.Add(curRecord);
            }

            return _records;
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

    }
}
