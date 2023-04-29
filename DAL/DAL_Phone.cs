using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Phone
    {
        DTO_Phone phone;
        
        public DAL_Phone(string phoneName)
        {
            phone = new DTO_Phone(phoneName);
        }


        public DataTable getPhoneID()
        {
            string str = "select PhoneId from Phone where PhoneName = '" + phone._PHONENAME + "'";
            return Connection.selectQuery(str);
        }

        public DataTable getPrice()
        {
            string str = "select Price from Phone where PhoneName = '" + phone._PHONENAME + "'";
            return Connection.selectQuery(str);
        }
    }
}
