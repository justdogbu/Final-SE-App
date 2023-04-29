using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ReceiptDetails
    {
        DAL_ReceiptDetails receiptDetails;
        public BUS_ReceiptDetails()
        {

        }

        public BUS_ReceiptDetails(int receiptID, int phoneID, int quantity, int price)
        {
            receiptDetails = new DAL_ReceiptDetails(receiptID, phoneID, quantity, price);
        }


        public void addQuery()
        {
            receiptDetails.addQuery();
        }
    }
}
