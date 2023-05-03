using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ImportBill : UserControl
    {
        public ImportBill()
        {
            InitializeComponent();
        }
        
        private DateTime Date;
        private int BillID;
        private int Total;
        private int ResellerID;

        public ImportBill(int billID, int total, DateTime date, int resellerID)
        {
            this.BillID = billID;
            this.Total = total;
            this.Date = date;
            this.ResellerID = resellerID;
        }
        public DateTime _DATE
        {
            get
            {
                return Date;
            }
            set
            {
                Date = value;
                lblDate.Text = _DATE.ToString("dd/MM/yyyy");
            }
        }
        
        public int _BILLID
        {
            get
            {
                return BillID;
            }
            set
            {
                BillID = value;
                lblReceiptID.Text = "RECEIPT " + _BILLID.ToString();
            }
        }

        public int _TOTAL
        {
            get
            {
                return Total;
            }
            set
            {
                Total = value;
                lblTotal.Text = _TOTAL.ToString("C");
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
                lblReseller.Text = ResellerID.ToString();
            }
        }

    }
}
