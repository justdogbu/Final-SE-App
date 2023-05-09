using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_Receipt
    {
        private int ReceiptID, TotalPrice, AccountantID;
        private string DateCreated;

        public int _RECEIPTID
        {
            get
            {
                return ReceiptID;
            }
            set
            {
                ReceiptID = value;
            }
        }

        public int _TOTALPRICE
        {
            get
            {
                return TotalPrice;
            }
            set
            {
                TotalPrice = value;
            }
        }

        public String _DATECREATED
        {
            get
            {
                return DateCreated;
            }
            set
            {
                DateTime now = DateTime.Now;
                string formattedDateTime = now.ToString("yyyy-MM-dd HH:mm:ss.fffffff");
                DateCreated = formattedDateTime;
            }
        }

        public int _ACCOUNTANTID
        {
            get
            {
                return AccountantID;
            }
            set
            {
                AccountantID = value;
            }
        }

        public DTO_Receipt(int ReceiptID, int TotalPrice, string DateCreated, int AccountantID )
        {
            this.ReceiptID = ReceiptID;
            this.TotalPrice = TotalPrice;
            this.DateCreated = DateCreated;
            this.AccountantID = AccountantID;
        }

        public DTO_Receipt(int AccountantID) 
        {
            this.AccountantID = AccountantID;
        }
    }
}
