using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_ResellerImportReceipt
    {
        DAL_ResellerImportReceipt receipt;
        public BUS_ResellerImportReceipt() {
        
        }

        public BUS_ResellerImportReceipt(int resellerReceiptID, int resellerID)
        {
            receipt = new DAL_ResellerImportReceipt(resellerReceiptID, resellerID);
        }

        public DataTable selectReceipt()
        {
            return receipt.selectReceipt();
        }

        public DataTable sortDateAsc()
        {
            return receipt.sortDateAsc();
        }

        public DataTable sortDateDesc()
        {
            return receipt.sortDateDesc();
        }
        public DataTable sortPriceAsc()
        {
            return receipt.sortPriceAsc();
        }
        public DataTable sortPriceDesc()
        {
            return receipt.sortPriceDesc();
        }

        public void updateStatus()
        {
            receipt.updateStatus();
        }
        public int countReceipt()
        {
            DataTable table = receipt.selectReceipt();
            return table.Rows.Count;
        }
    }
}
