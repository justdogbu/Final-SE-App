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
    public partial class BillDetails : UserControl
    {
        public BillDetails()
        {
            InitializeComponent();
        }
        private string _NAME;
        private int _PRICE;
        private int _NUMBER;
        private int _BILLID;
        private Image _ICON;
        private int _ID;
        private int _WAREHOUSEID;
        

        public string Name
        {
            get
            {
                return _NAME;
            }
            set
            {
                _NAME = value;
                lblName.Text = value;
            }
        }

        public int Price
        {
            get
            {
                return _PRICE;
            }
            set
            {
                _PRICE = value;
                lblPrice.Text = Price.ToString("C", CultureInfo.CreateSpecificCulture("vi-VN"));
            }
        }

        public int Number
        {
            get
            {
                return _NUMBER;
            }
            set
            {
                _NUMBER = value;
                txtNum.Enabled = false;
                txtNum.Text = value.ToString();
            }
        }

        public int BillID
        {
            get
            {
                return _BILLID;
            }
            set
            {
                _BILLID = value;
            }
        }

        public Image Icon
        {
            get
            {
                return _ICON;
            }
            set
            {
                _ICON = value;
                picPhone.BackgroundImage = value;
                picPhone.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public int WarehouseID
        {
            get
            {
                return _WAREHOUSEID;
            }
            set
            {
                _WAREHOUSEID = value;
            }
        }
    }
}
