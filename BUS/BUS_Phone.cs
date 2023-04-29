using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Phone
    {
        DAL_Phone phone;
        public BUS_Phone(string phoneName)
        {
            phone = new DAL_Phone(phoneName);
        }

        public int getPhoneID()
        {
            DataTable table = phone.getPhoneID();
            int id = (int)table.Rows[0][0];
            return id;
        }

        public int getPrice()
        {
            DataTable table = phone.getPrice();
            int price = (int)table.Rows[0][0];
            return price;
        }
    }
}
