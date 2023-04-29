using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_Receipt
    {
        DAL_Receipt receipt;
        public BUS_Receipt() { 
        
        }

        public BUS_Receipt(int receiptID, int totalPrice, string dateCreated, int accountantID) {
            receipt = new DAL_Receipt(receiptID, totalPrice, dateCreated, accountantID);
        }

        public void addQuery()
        {
            receipt.addQuery();
        }

        public int getReceiptID()
        {
            DataTable table = receipt.getReceiptIDDesc();
            int id = (int) (table.Rows[0][0]) + 1;
            return id;
        }
    }
}
