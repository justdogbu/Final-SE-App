using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_WarehouseProducts
    {
        private int WarehouseID, PhoneID, Quantity;

        public int _WAREHOUSEID
        {
            get
            {
                return WarehouseID;
            }
            set
            {
                WarehouseID = value;
            }
        }

        public int _PHONEID
        {
            get
            {
                return PhoneID;
            }
            set
            {
                PhoneID = value;
            }
        }

        public int _QUANTITY
        {
            get
            {
                return Quantity;
            }
            set
            {
                Quantity = value;
            }
        }


        public DTO_WarehouseProducts(int WarehouseID, int PhoneID, int Quantity)
        {
            this.WarehouseID = WarehouseID;
            this.PhoneID = PhoneID;
            this.Quantity = Quantity;
        }
    }
}
