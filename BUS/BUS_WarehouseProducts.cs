using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_WarehouseProducts
    {
        DAL_WarehouseProducts warehouseProducts;
        public BUS_WarehouseProducts()
        {

        }

        public BUS_WarehouseProducts(int warehouseID, int phoneID, int quantity)
        {
            warehouseProducts = new DAL_WarehouseProducts(warehouseID, phoneID, quantity);
        }


        public void addQuery()
        {
            warehouseProducts.addQuery();
        }

        public void updateQuery()
        {
            warehouseProducts.updateQuery();
        }

        public void updateQuantity()
        {
            warehouseProducts.updateQuantity();
        }

        public int selectQuantity()
        {
            DataTable table = warehouseProducts.selectQuantity();
            if(table.Rows.Count > 0 )
            {
                return (int)table.Rows[0][0];
            }
            return -1;
        }
    }
}
