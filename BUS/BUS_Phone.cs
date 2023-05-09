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

        public BUS_Phone()
        {
            phone = new DAL_Phone();
        }

        public BUS_Phone(string phoneName)
        {
            phone = new DAL_Phone(phoneName);
        }

        public BUS_Phone(int phoneId)
        {
            phone = new DAL_Phone(phoneId);
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

        public int countPhone()
        {
            DataTable table = phone.countPhone();
            int count = (int)table.Rows[0][0];
            return count;
        }

        public DataTable selectTable()
        {
            return phone.selectTable();
        }

        public string selectName()
        {
            DataTable table = phone.selectName();
            if(table.Rows.Count > 0)
            {
                return table.Rows[0][0].ToString();
            }
            return "";
        }

        public DataTable selectPhone() {
            return phone.selectPhone();
        }
        
    }
}
