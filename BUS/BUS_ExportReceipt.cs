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

        public BUS_ExportReceipt(int accountantID)
        {
            receipt = new DAL_ExportReceipt(accountantID);
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

        public DataTable getReceipt()
        {
            return receipt.getReceipt();
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

        public DataTable sortDateAscLessThan10()
        {
            return receipt.sortDateAscLessThan10();
        }

        public DataTable sortDateDescLessThan10()
        {
            return receipt.sortDateDescLessThan10();
        }
        public DataTable sortPriceAscLessThan10()
        {
            return receipt.sortPriceAscLessThan10();
        }
        public DataTable sortPriceDescLessThan10()
        {
            return receipt.sortPriceDescLessThan10();
        }

        public DataTable sortDateAscLessThan100()
        {
            return receipt.sortDateAscLessThan100();
        }

        public DataTable sortDateDescLessThan100()
        {
            return receipt.sortDateDescLessThan100();
        }
        public DataTable sortPriceAscLessThan100()
        {
            return receipt.sortPriceAscLessThan100();
        }
        public DataTable sortPriceDescLessThan100()
        {
            return receipt.sortPriceDescLessThan100();
        }

        public DataTable sortDateAscGreaterThan100()
        {
            return receipt.sortDateAscGreaterThan100();
        }

        public DataTable sortDateDescGreaterThan100()
        {
            return receipt.sortDateDescGreaterThan100();
        }
        public DataTable sortPriceAscGreaterThan100()
        {
            return receipt.sortPriceAscGreaterThan100();
        }
        public DataTable sortPriceDescGreaterThan100()
        {
            return receipt.sortPriceDescGreaterThan100();
        }

        public DataTable sortGreaterThan100()
        {
            return receipt.sortGreaterThan100();
        }
        public DataTable sortLessThan100()
        {
            return receipt.sortLessThan100();
        }
        public DataTable sortLessThan10()
        {
            return receipt.sortLessThan10();
        }
    }
}
