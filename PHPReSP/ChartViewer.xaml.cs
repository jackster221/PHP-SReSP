using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Controls.DataVisualization;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System.Data;

using System.Windows.Navigation;
using PHPReSP.Classes;

namespace PHPReSP
{

    public partial class ChartViewer : Window
    {
        private DataManager manager = new DataManager();

        public ChartViewer()
        {
            InitializeComponent();
           
            RefreshBarChart();
        }

        public void RefreshBarChart()
        {
            manager.ConvertDBtoSalesObj();
            var revenues = new ItemsRevenue();
            var chartData = new KeyValuePair<string, double>[revenues.items.Count()];


            for (int i = 0; i <= revenues.items.Count() - 1; i++)
            {
                chartData[i] = new KeyValuePair<string, double>(revenues.items[i], revenues.revenues[i]);
            }

            

            ((BarSeries)mcChart.Series[0]).ItemsSource = chartData;

           
        }


    }
        
    
}
