using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_ResellerStorage
    {
        DAL_ResellerStorage resellerStorage;

        public BUS_ResellerStorage(int resellerID, int phoneID, int quantity)
        {
            resellerStorage = new DAL_ResellerStorage(resellerID, phoneID, quantity);
        }


        public void addQuery()
        {
            resellerStorage.addQuery();
        }

        public void updateQuery()
        {
            resellerStorage.updateQuery();
        }

        public int selectQuantity()
        {
            DataTable table = resellerStorage.selectQuantity();
            if(table.Rows.Count > 0)
            {
                return (int)table.Rows[0][0];
            }
            return -1;
        }
    }
}
