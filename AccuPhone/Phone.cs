using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI
{
    public partial class Phone : UserControl
    {
        public Phone()
        {
            InitializeComponent();
        }


        public event EventHandler ImportButtonClicked;
        private string _NAME;
        private int _PRICE;
        private int _INDEX;
        private Image _ICON;
        private int _ID;


        public string Name
        {
            get
            {
                return _NAME;
            }
            set
            {
                _NAME = value;
                lblPhone.Text = value;
                this.Size = new Size(lblPhone.Width + 50, 260);
                bImportPhone.Location = new Point(this.Width/2 - 50, 204);
                picPhone.Location = new Point(this.Width / 2 - 82, 18);
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
            }
        }

        public int Index
        {
            get
            {
                return _INDEX;
            }
            set
            {
                _INDEX = value;
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



        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void bImportPhone_Click(object sender, EventArgs e)
        {
            if (ImportButtonClicked != null)
            {
                ImportButtonClicked(this, e);
            }
        }

    }


}
