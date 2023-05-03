using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_ResellerImportReceipt
    {
        private int ResellerReceiptID, ResellerID;

        public int _RESELLERRECEIPTID
        {
            get
            {
                return ResellerReceiptID;
            }
            set
            {
                ResellerReceiptID = value;
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



        public DTO_ResellerImportReceipt(int ResellerReceiptID, int ResellerID)
        {
            this.ResellerReceiptID = ResellerReceiptID;
            this.ResellerID = ResellerID;
        }
    }
}
