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
        public DAL_ExportReceiptDetails(int receiptID, int phoneID, int quantity, int price)
        {
            receiptDetails = new DTO_ExportReceiptDetails(receiptID, phoneID, quantity, price);
        }

        public void addQuery()
        {
            string querry = "insert into ExportReceiptDetails values (" + receiptDetails._RECEIPTID + "," + receiptDetails._PHONEID + "," + receiptDetails._QUANTITY + "," + receiptDetails._PRICE + ")";
            Debug.WriteLine(querry);
            Connection.actionQuery(querry);
        }
    }
}
