using DTO;
using System;
using System.Data;
using System.Diagnostics;

namespace DAL
{
    public class DAL_ResellerImportReceipt
    {
        DTO_ResellerImportReceipt receipt;

        public DAL_ResellerImportReceipt(int resellerReceiptID, int resellerID)
        {
            receipt = new DTO_ResellerImportReceipt(resellerReceiptID, resellerID);
        }

        public DataTable selectReceipt()
        {
            string str = "select * from ResellerImportReceipt where DeliveryStatusId = 1";
            return Connection.selectQuery(str);
        }

        public DataTable sortDateAsc()
        {
            string str = "select * from ResellerImportReceipt where DeliveryStatusId = 1 ORDER BY DateCreated ASC";
            return Connection.selectQuery(str);
        }

        public DataTable sortDateDesc()
        {
            string str = "select * from ResellerImportReceipt where DeliveryStatusId = 1 ORDER BY DateCreated DESC";
            return Connection.selectQuery(str);
        }

        public DataTable sortPriceAsc()
        {
            string str = "select * from ResellerImportReceipt where DeliveryStatusId = 1 ORDER BY TotalPrice ASC";
            return Connection.selectQuery(str);
        }
        public DataTable sortPriceDesc()
        {
            string str = "select * from ResellerImportReceipt where DeliveryStatusId = 1 ORDER BY TotalPrice DESC";
            return Connection.selectQuery(str);
        }

        public void updateStatus()
        {
            string str = "update ResellerImportReceipt set DeliveryStatusId = 2 where ResellerImportReceiptID = " + receipt._RESELLERRECEIPTID;
            Connection.actionQuery(str);
        }
    }
    
}
