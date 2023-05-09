using DTO;
using System;
using System.Data;
using System.Diagnostics;

namespace DAL
{
    public class DAL_ResellerImportReceiptDetails
    {
        DTO_ResellerImportReceiptDetails receiptDetails;

        public DAL_ResellerImportReceiptDetails(int resellerReceiptID)
        {
            receiptDetails = new DTO_ResellerImportReceiptDetails(resellerReceiptID);
        }

        public DataTable selectReceipt()
        {
            string str = "select * from ResellerImportReceiptDetail where ResellerImportReceiptID = " + receiptDetails._RESELLERRECEIPTDETAILSID;
            return Connection.selectQuery(str);
        }
    }
    
}
