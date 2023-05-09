using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_ExportReceiptDetails
    {
        DTO_ExportReceiptDetails receiptDetails;
        public DAL_ExportReceiptDetails(int resellerID, int receiptID, int phoneID, int quantity, int price)
        {
            receiptDetails = new DTO_ExportReceiptDetails(resellerID, receiptID, phoneID, quantity, price);
        }

        public DAL_ExportReceiptDetails(int receiptID)
        {
            receiptDetails = new DTO_ExportReceiptDetails(receiptID);
        }
        public void addQuery()
        {
            string querry = "insert into ExportReceiptDetails values (" + receiptDetails._RESELLERID + "," + receiptDetails._PHONEID + "," + receiptDetails._RECEIPTID + "," + receiptDetails._QUANTITY + "," + receiptDetails._PRICE + ")";
            Debug.WriteLine(querry);
            Connection.actionQuery(querry);
        }

        public DataTable selectExportReceiptDetails()
        {
            string str = "select * from ExportReceiptDetails where ExportReceiptId = " + receiptDetails._RECEIPTID;
            return Connection.selectQuery(str);
        }
    }
}
