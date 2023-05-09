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
    public class DAL_ReceiptDetails
    {
        DTO_ReceiptDetails receiptDetails;
        public DAL_ReceiptDetails(int receiptID, int phoneID, int quantity, int price)
        {
            receiptDetails = new DTO_ReceiptDetails(receiptID, phoneID, quantity, price);
        }

        public DAL_ReceiptDetails(int receiptID)
        {
            receiptDetails = new DTO_ReceiptDetails(receiptID);
        }
        public void addQuery()
        {
            string querry = "insert into ReceiptDetails values (" + receiptDetails._RECEIPTID + "," + receiptDetails._PHONEID + "," + receiptDetails._QUANTITY + "," + receiptDetails._PRICE + ")";
            Debug.WriteLine(querry);
            Connection.actionQuery(querry);
        }

        public DataTable selectReceiptDetails() {
            string str = "select * from ReceiptDetails where ReceiptId = " + receiptDetails._RECEIPTID;
            return Connection.selectQuery(str);
        }
    }
}
