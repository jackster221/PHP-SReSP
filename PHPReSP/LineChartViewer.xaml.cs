using PHPReSP.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PHPReSP
{
    /// <summary>
    /// Interaction logic for LineChartViewer.xaml
    /// </summary>
    public partial class LineChartViewer : Window
    {
        private DataManager manager = new DataManager();

        public LineChartViewer()
        {
            InitializeComponent();
            cmbx_monthweek.SelectedIndex = 0;

            LineChartData(cmbx_monthweek.SelectedIndex);
        }



        public void LineChartData(int index)
        {
            if (index == 0)
            {
                var revenues = new MonthsRevenue();
                var chartData = new KeyValuePair<string, double>[revenues.months.Count()];


                for (int i = 0; i <= revenues.months.Count() - 1; i++)
                {
                    chartData[i] = new KeyValuePair<string, double>(revenues.months[i], revenues.revenues[i]);
                }
                ((LineSeries)mcChart.Series[0]).ItemsSource = chartData;
            }
            else if (index == 1)
            {
                var revenues = new WeeksRevenue();
                var chartData = new KeyValuePair<string, double>[revenues.weeks.Count()];


                for (int i = 0; i <= revenues.weeks.Count() - 1; i++)
                {
                    chartData[i] = new KeyValuePair<string, double>(revenues.weeks[i], revenues.revenues[i]);
                }
               ((LineSeries)mcChart.Series[0]).ItemsSource = chartData;
            }

        }

        private void cmbx_monthweek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LineChartData(cmbx_monthweek.SelectedIndex);
        }
    }
}

