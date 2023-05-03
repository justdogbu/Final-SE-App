using DAL;
using DTO;
using System.Data;

namespace BUS
{
    public class BUS_Reseller
    {
        DAL_Reseller reseller;

        public BUS_Reseller(int resellerID)
        {
            reseller = new DAL_Reseller(resellerID);
        }

        public BUS_Reseller()
        {

        }

        public string getShopname()
        {
            DataTable table = reseller.selectName();
            if(table.Rows.Count > 0) {
                return table.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }

        
    }
}