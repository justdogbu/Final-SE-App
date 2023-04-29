using DTO;
using System;
using System.Data;
using System.Diagnostics;

namespace DAL
{
    public class DAL_Receipt
    {
        DTO_Receipt receipt;

        public DAL_Receipt(int receiptID, int totalPrice, string dateCreated, int accountantID)
        {
            receipt = new DTO_Receipt(receiptID, totalPrice, dateCreated, accountantID);
        }

        public void addQuery()
        {
            DateTime now = DateTime.Now;
            string dateTime = now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            string dateTime2 = "CAST(N'" + dateTime + "' AS DateTime2)";


            string querry = "insert into Receipt values (" + receipt._TOTALPRICE + "," + dateTime2 + "," + receipt._ACCOUNTANTID + ")";
            Debug.WriteLine(querry); 
            Connection.actionQuery(querry);
        }

        public DataTable getReceiptIDDesc()
        {
            string str = "select top 1 ReceiptId from Receipt order by ReceiptId desc";
            return Connection.selectQuery(str);
        }
    }
    
}
