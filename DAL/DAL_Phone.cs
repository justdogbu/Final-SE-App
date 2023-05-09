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
        

        public DAL_Phone()
        {
            phone = new DTO_Phone();
        }
        public DAL_Phone(string phoneName)
        {
            phone = new DTO_Phone(phoneName);
        }

        public DAL_Phone(int phoneId)
        {
            phone = new DTO_Phone(phoneId);
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

        public DataTable countPhone()
        {
            string str = "select count(*) from Phone";
            return Connection.selectQuery(str);
        }

        public DataTable selectTable()
        {
            string str = "select * from Phone";
            return Connection.selectQuery(str);
        }

        public DataTable selectName()
        {
            string str = "select PhoneName from Phone where PhoneId = " + phone._PHONEID;
            return Connection.selectQuery(str);
        }

        public DataTable selectPhone() {

            string str = @"
                            DECLARE @Month INT
                            SET @Month = " + DateTime.Now.Month + @" 

                            SELECT
                                P.PhoneName,
                                MONTH(R.DateCreated) AS [Month],
                                SUM(RD.Quantity) AS ImportQuantity,
                                SUM(ERD.Quantity) AS ExportQuantity
                            FROM
                                Phone P
                                LEFT JOIN ReceiptDetails RD ON P.PhoneId = RD.PhoneId
                                LEFT JOIN Receipt R ON RD.ReceiptId = R.ReceiptId AND MONTH(R.DateCreated) = @Month
                                LEFT JOIN ExportReceiptDetails ERD ON P.PhoneId = ERD.PhoneId
                                LEFT JOIN ExportReceipt ER ON ERD.ExportReceiptId = ER.ExportReceiptId AND MONTH(ER.DateCreated) = @Month
                            GROUP BY
                                P.PhoneName,
                                MONTH(R.DateCreated)
                            ORDER BY
                                ExportQuantity DESC";
            return Connection.selectQuery(str);
        }
    }
}
