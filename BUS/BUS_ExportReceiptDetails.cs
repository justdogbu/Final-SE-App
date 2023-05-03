using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ExportReceiptDetails
    {
        DAL_ExportReceiptDetails receiptDetails;
        public BUS_ExportReceiptDetails()
        {

        }

        public BUS_ExportReceiptDetails(int receiptID, int phoneID, int quantity, int price)
        {
            receiptDetails = new DAL_ExportReceiptDetails(receiptID, phoneID, quantity, price);
        }


        public void addQuery()
        {
            receiptDetails.addQuery();
        }
    }
}
