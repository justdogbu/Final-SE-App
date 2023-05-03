using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_ExportReceipt
    {
        DAL_ExportReceipt receipt;
        public BUS_ExportReceipt() { 
        
        }

        public BUS_ExportReceipt(int receiptID, int totalPrice, string dateCreated, int accountantID) {
            receipt = new DAL_ExportReceipt(receiptID, totalPrice, dateCreated, accountantID);
        }

        public void addQuery()
        {
            receipt.addQuery();
        }

        public int getReceiptID()
        {
            DataTable table = receipt.getReceiptIDDesc();
            if(table.Rows.Count > 0) {
                int id = (int)(table.Rows[0][0]) + 1;
                return id;
            }
            return 1;
            
        }
    }
}
