using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ExportReceiptDetails
    {
        private int ReceiptID, PhoneID, Quantity, Price, ResellerID;
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

        public int _PRICE
        {
            get
            {
                return Price;
            }
            set
            {
                Price = value;
            }
        }

        public int _RESELLERID
        {
            get
            {
                return ResellerID;
            }
            set
            {
                ResellerID = value;
            }
        }


        public DTO_ExportReceiptDetails(int ResellerID, int PhoneID, int ReceiptID, int Quantity, int Price)
        {
            this.ResellerID = ResellerID;
            this.PhoneID = PhoneID;
            this.ReceiptID = ReceiptID;
            this.Quantity = Quantity;
            this.Price = Price;
        }

        public DTO_ExportReceiptDetails(int receiptID)
        {
            this.ReceiptID = receiptID;
        }
    }
}
