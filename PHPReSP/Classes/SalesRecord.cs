using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHPReSP
{

    class SalesRecord
    {
        private System.Guid GUID { get; } //guid to uniquely identify each sale (may replace SaleID)
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
            this.GUID = System.Guid.NewGuid();
        }

    }
}

