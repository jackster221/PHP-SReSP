using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPReSP
{
    class DataManager
    {

        private List<SalesRecord> _records = new List<SalesRecord>();

        public DataManager()
        {

        }

        
        public IEnumerable<SalesRecord> ReadCSV(string fileName)
        {

            string[] lines = File.ReadAllLines(System.IO.Path.ChangeExtension(fileName, ".csv"));

            return lines.Select(line =>
            {
                string[] data = line.Split(',');
               
                return new SalesRecord(Convert.ToInt32(data[0]), data[1], Convert.ToDouble(data[2]), Convert.ToInt32(data[3]));
            });
        }

    }
}
