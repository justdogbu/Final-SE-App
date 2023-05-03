﻿using DTO;
using System;
using System.Data;
using System.Diagnostics;

namespace DAL
{
    public class DAL_ExportReceipt
    {
        DTO_ExportReceipt receipt;

        public DAL_ExportReceipt(int receiptID, int totalPrice, string dateCreated, int accountantID)
        {
            receipt = new DTO_ExportReceipt(receiptID, totalPrice, dateCreated, accountantID);
        }

        public void addQuery()
        {
            DateTime now = DateTime.Now;
            string dateTime = now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            string dateTime2 = "CAST(N'" + dateTime + "' AS DateTime2)";
            string querry = "insert into ExportReceipt values (" + receipt._TOTALPRICE + "," + dateTime2 + "," + receipt._ACCOUNTANTID + ")";
            Debug.WriteLine(querry); 
            Connection.actionQuery(querry);
        }

        public DataTable getReceiptIDDesc()
        {
            string str = "select top 1 ExportReceiptId from ExportReceipt order by ExportReceiptId desc";
            return Connection.selectQuery(str);
        }
    }
    
}