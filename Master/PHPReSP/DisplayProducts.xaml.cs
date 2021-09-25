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

namespace PHPReSP
{

    public partial class DisplayProducts : Window
    {
        public DisplayProducts()
        {
            InitializeComponent();
        }

        private void AddNewProduct(object sender, RoutedEventArgs e)
        {
            AddProductRecordPage page = new AddProductRecordPage();
            page.ShowDialog();
        }

        private void EditProducts(object sender, RoutedEventArgs e)
        {
            EditProductPage page = new EditProductPage();
            page.ShowDialog();
        }
    }
}
