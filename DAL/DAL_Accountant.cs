using DTO;
using System.Data;

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
    }
}