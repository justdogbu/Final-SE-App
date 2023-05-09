using DTO;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DAL
{
    public class DAL_Accountant
    {
        DTO_Accountant acc;

        public DAL_Accountant(int accID, string accName, string accEmail, string accPassword, int wareID)
        {
            acc = new DTO_Accountant(accID, accName, accEmail, accPassword, wareID);
        }

        public DataTable selectEmail()
        {
            string query = "select * from Accountant where AccountantEmail = '" + acc._ACCOUNTANTEMAIL + "'";
            return Connection.selectQuery(query);
        }

        public DataTable selectPassword()
        {
            string query = "select AccountantPassword from Accountant where AccountantEmail = '" + acc._ACCOUNTANTEMAIL + "'";
            return Connection.selectQuery(query);
        }

        public DataTable selectID()
        {
            string query = "select AccountantID from Accountant where AccountantEmail = '" + acc._ACCOUNTANTEMAIL + "'";
            return Connection.selectQuery(query);
        }
        public DataTable selectName ()
        {
            string query = "select AcccountantName from Accountant where AccountantEmail = '" + acc._ACCOUNTANTEMAIL + "'";
            return Connection.selectQuery(query);
        }
        public DataTable selectWarehouse()
        {
            string query = "select WarehouseID from Accountant where AccountantEmail = '" + acc._ACCOUNTANTEMAIL + "'";
            return Connection.selectQuery(query);
        }

        public DataTable selectProfit()
        {
            string query = @"
            SELECT
                AccountantId,
                CONVERT(date, DateCreated) as Date,
                SUM(CASE WHEN ExportReceiptId IS NOT NULL THEN TotalPrice ELSE 0 END) as TotalExport,
                SUM(CASE WHEN ReceiptId IS NOT NULL THEN TotalPrice ELSE 0 END) as TotalImport
            FROM
                (
                    SELECT AccountantId, TotalPrice, DateCreated, ExportReceiptId, null as ReceiptId
                    FROM ExportReceipt
                    UNION ALL
                    SELECT AccountantId, TotalPrice, DateCreated, null as ExportReceiptId, ReceiptId
                    FROM Receipt
                ) as temp
            WHERE
                AccountantId =" + acc._ACCOUNTANTID + @"AND
                DateCreated >= DATEADD(day, -7, GETDATE()) AND
                DateCreated <= GETDATE()
            GROUP BY
                AccountantId, CONVERT(date, DateCreated)";
            Debug.WriteLine(query);
            return Connection.selectQuery(query);
        }
    }
}