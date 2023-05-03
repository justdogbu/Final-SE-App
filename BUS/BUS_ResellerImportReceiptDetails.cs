using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_ResellerImportReceiptDetails
    {
        DAL_ResellerImportReceiptDetails receiptDetails;
        public BUS_ResellerImportReceiptDetails() {
        
        }

        public BUS_ResellerImportReceiptDetails(int resellerReceiptID)
        {
            receiptDetails = new DAL_ResellerImportReceiptDetails(resellerReceiptID);
        }

        public DataTable selectReceipt()
        {
            return receiptDetails.selectReceipt();
        }

       

        public int countReceipt()
        {
            DataTable table = receiptDetails.selectReceipt();
            return table.Rows.Count;
        }
    }
}
