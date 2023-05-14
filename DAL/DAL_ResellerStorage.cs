using DTO;
using System.Data;
using System.Diagnostics;

namespace DAL
{
    public class DAL_ResellerStorage
    {
        DTO_ResellerStorage reseller;

        public DAL_ResellerStorage(int resellerID)
        {
            reseller = new DTO_ResellerStorage(resellerID);
        }

        public DAL_ResellerStorage(int resellerID, int phoneID, int quantity)
        {
            reseller = new DTO_ResellerStorage(resellerID, phoneID, quantity);
        }

        public void addQuery()
        {
            string query = "insert into ResellerStorage values (" + reseller._RESELLERID + "," + reseller._PHONEID + "," + reseller._QUANTITY + ")";
            Debug.WriteLine(query);
            Connection.actionQuery(query);
        }

        public void updateQuery()
        {
            string query = "update ResellerStorage set Quantity = Quantity + " + reseller._QUANTITY + " where ResellerId = " + reseller._RESELLERID + " and PhoneId = " + reseller._PHONEID;
            Debug.WriteLine(query);
            Connection.actionQuery(query);
        }

        public DataTable selectQuantity()
        {
            string query = "select Quantity from ResellerStorage where ResellerId = " + reseller._RESELLERID + " and PhoneId = " + reseller._PHONEID;
            Debug.WriteLine(query);
            return Connection.selectQuery(query);
        }

    }
}