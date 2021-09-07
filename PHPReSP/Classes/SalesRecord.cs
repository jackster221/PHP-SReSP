using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPReSP
{

    class SalesRecord
    {

        public int SaleID { get; set; }
        public string Product { get; set; }
        //public string PurchaseDate { get; set; }
        public double Cost { get; set; }
        public int ItemsInSale { get; set; }


        public SalesRecord(int ID, string product, double cost, int numberSold)
        {
            this.SaleID = ID;
            this.Product = product;
            this.Cost = cost;
            this.ItemsInSale = numberSold;
        }

    }
}

