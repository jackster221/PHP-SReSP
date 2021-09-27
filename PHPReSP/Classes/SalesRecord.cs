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
        //public string ProductID { get; set; }
        public int NumberSold { get; set; }
        public string SaleDate { get; set; }
        


        public SalesRecord(int productID, int NumberSold, string SaleDate)
        {
            //this.SaleID = ID;
            //this.ProductID = productID;
            this.SaleDate = SaleDate;
            this.NumberSold = NumberSold;
            this.GUID = System.Guid.NewGuid();
        }

    }
}

