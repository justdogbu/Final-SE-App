using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Bill : UserControl
    {
        public Bill()
        {
            InitializeComponent();
        }

        private void Bill_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler ApproveButtonClicked;

        private DateTime Date;
        private int BillID;
        private int Total;
        private int WarehouseID;
        private string ResellerName;
        private string PaymentMethod;
        private int ResellerID;

       
        public DateTime _DATE
        {
            get
            {
                return Date;
            }
            set
            {
                Date = value;
                lblDate.Text = value.ToString("dd/MM/yyyy");
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
                lblReceiptID.Text = "RECEIPT " + value.ToString();
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
                lblTotal.Text = value.ToString("C", CultureInfo.CreateSpecificCulture("vi-VN"));

            }
        }
        public string _RESELLERNAME
        {
            get
            {
                return ResellerName;
            }
            set
            {
                ResellerName = value;
                lblReseller.Text = value.ToUpper();
            }
        }

        public string _PAYMENTMETHOD
        {
            get
            {
                return PaymentMethod;
            }
            set
            {
                PaymentMethod = value;
                lblPayment.Text = value.ToUpper();
            }
        }

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

        private void bApprove_Click(object sender, EventArgs e)
        {
            if (ApproveButtonClicked != null)
            {
                ApproveButtonClicked(this, e);
            }
        }
    }
}
