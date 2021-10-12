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

    public partial class BarChartViewer : Window
    {
        private DataManager manager = new DataManager();

        public BarChartViewer()
        {
            InitializeComponent();
           
            ChartData(0);
        }



        public void ChartData(int index)
        {
            manager.ConvertDBtoSalesObj();

            if (index == 0)
            {
                var revenues = new ItemsRevenue();
                var chartData = new KeyValuePair<string, double>[revenues.items.Count()];


                for (int i = 0; i <= revenues.items.Count() - 1; i++)
                {
                    chartData[i] = new KeyValuePair<string, double>(revenues.items[i], revenues.revenues[i]);
                }

                ((BarSeries)mcChart.Series[0]).ItemsSource = chartData;
            }
            else
            {
                var revenues = new MonthsRevenue();
                var chartData = new KeyValuePair<string, double>[revenues.months.Count()];


                for (int i = 0; i <= revenues.months.Count() - 1; i++)
                {
                    chartData[i] = new KeyValuePair<string, double>(revenues.months[i], revenues.revenues[i]);
                }
                ((BarSeries)mcChart.Series[0]).ItemsSource = chartData;
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChartData(cbx_chartType.SelectedIndex);
        }
    }
        
    
}
