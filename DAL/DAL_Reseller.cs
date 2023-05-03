using DTO;
using System.Data;

namespace DAL
{
    public class DAL_Reseller
    {
        DTO_Reseller reseller;

        public DAL_Reseller(int resellerID)
        {
            reseller = new DTO_Reseller(resellerID);
        }

        public DataTable selectName()
        {
            string query = "select ResellerName from Reseller where ResellerId = " + reseller._RESELLERID;
            return Connection.selectQuery(query);
        }

    }
}