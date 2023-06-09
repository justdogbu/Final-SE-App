﻿using System;
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
    public partial class Product : UserControl
    {
        public Product()
        {
            InitializeComponent();
        }

        public event EventHandler DeleteButtonClicked;
        private string _NAME;
        private int _PRICE;
        private string _NUMBER;
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
                lblPrice.Text = Price.ToString("C", CultureInfo.CreateSpecificCulture("vi-VN")); ;
            }
        }

        public string Number
        {
            get
            {
                return _NUMBER;
            }
            set
            {
                _NUMBER = value;
                txtNum.Text = value;
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
            set { 
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

        private void picAdd_Click(object sender, EventArgs e)
        {
            int number = int.Parse(txtNum.Text);
            number += 1;
            txtNum.Text = number.ToString();
            this.Number = number.ToString();
        }

        private void picMinus_Click(object sender, EventArgs e)
        {
            int number = int.Parse(txtNum.Text);
            if(number > 0)
            {
                number -= 1;
                txtNum.Text = number.ToString();
                this.Number = number.ToString();
            }
        }

        private void lblRemove_Click(object sender, EventArgs e)
        {
            if (DeleteButtonClicked != null)
            {
                DeleteButtonClicked(this, e);
            }
        }

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            this.Number = txtNum.Text;
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void picPhone_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }


    }
}
