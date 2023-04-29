using BUS;
using GUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Home : Form
    {
        BUS_Accountant acc;
        BUS_Receipt receipt;
        BUS_ReceiptDetails receiptDetails;
        private string accountantName, accountantEmail, accountantPassword;
        private int accountantID, warehouseID;
        public Home()
        {
            InitializeComponent();
        }

        public Home(string email, string password)
        {
            InitializeComponent();
            acc = new BUS_Accountant(0, "", email, password, 0);
            accountantName = acc.selectName().Rows[0][0].ToString();
            accountantID = (int) acc.selectID().Rows[0][0];
            warehouseID = (int) acc.selectWarehouse().Rows[0][0];
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lblName.Text = accountantName;
            lblWarehouse.Text = "Warehouse " + warehouseID.ToString();
            panelButtonDB.Visible = true;
            panelButtonE.Visible = false;
            panelButtonI.Visible = false;
            panelButtonR.Visible = false;
            panelImport.Visible = false;
            panelComfirm.Visible = true;
        }


        private void picMenu1_Click(object sender, EventArgs e)
        {
            panelMenuBar.Visible = true;
        }

        private void picMenu2_Click(object sender, EventArgs e)
        {
            panelMenuBar.Visible = false;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picMaximum_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void bImport_Click(object sender, EventArgs e)
        {
            panelButtonDB.Visible = false;
            panelButtonE.Visible = false;
            panelButtonI.Visible = true;
            panelButtonR.Visible = false;

            panelComfirm.Visible = false;
            panelImport.Visible = true;
        }

        private void bExport_Click(object sender, EventArgs e)
        {
            panelButtonDB.Visible = false;
            panelButtonE.Visible = true;
            panelButtonI.Visible = false;
            panelButtonR.Visible = false;
        }

        private void bReceipts_Click(object sender, EventArgs e)
        {
            panelButtonDB.Visible = false;
            panelButtonE.Visible = false;
            panelButtonI.Visible = false;
            panelButtonR.Visible = true;
        }

        private void bDashboard_Click(object sender, EventArgs e)
        {
            panelButtonDB.Visible = true;
            panelButtonE.Visible = false;
            panelButtonI.Visible = false;
            panelButtonR.Visible = false;
        }


        private void bImportIP14_Click(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelComfirm.Visible = true;

            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && product.Name == "iPhone 14")
                {
                    int num = int.Parse(product.Number);
                    num += 1;
                    product.Number = num.ToString();
                    Debug.WriteLine("Exist");
                    return;
                }
            }

            Product iPhone14 = new Product();
            iPhone14.Name = "iPhone 14";
            BUS_Phone ip14Phone = new BUS_Phone(iPhone14.Name);
            iPhone14.Price = ip14Phone.getPrice();
            iPhone14.ID = ip14Phone.getPhoneID();
            iPhone14.Icon = Resources.ip14;
            iPhone14.Number = "1";
            iPhone14.DeleteButtonClicked += UserControl_DeleteButtonClicked;
            fPanelProduct.Controls.Add(iPhone14);

            iPhone14.Index = fPanelProduct.Controls.IndexOf(iPhone14);


        }

        private void bImportRN8_Click_1(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelComfirm.Visible = true;
            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && product.Name == "Redmi Note 8")
                {
                    int num = int.Parse(product.Number);
                    num += 1;
                    product.Number = num.ToString();
                    Debug.WriteLine("Exist");
                    return;
                }
            }

            Product redmi8 = new Product();
            redmi8.Name = "Redmi Note 8";
            BUS_Phone redmi8Phone = new BUS_Phone(redmi8.Name);
            redmi8.Price = redmi8Phone.getPrice();
            redmi8.ID = redmi8Phone.getPhoneID();
            redmi8.Icon = Resources.redmi_note_8;
            redmi8.Number = "1";
            redmi8.DeleteButtonClicked += UserControl_DeleteButtonClicked;

            fPanelProduct.Controls.Add(redmi8);
            redmi8.Index = fPanelProduct.Controls.IndexOf(redmi8);

        }

        private void UserControl_DeleteButtonClicked(object sender, EventArgs e)
        {
            Product control = sender as Product;
            if (control != null)
            {
                fPanelProduct.Controls.Remove(control);
                updateTotal();
            }
        }

        private void panelImport_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bImportXiaomi13_Click_1(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelComfirm.Visible = true;
            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && product.Name == "Xiaomi 13")
                {
                    int num = int.Parse(product.Number);
                    num += 1;
                    product.Number = num.ToString();
                    Debug.WriteLine("Exist");
                    return;
                }
            }

            Product xm13 = new Product();
            xm13.Name = "Xiaomi 13";
            BUS_Phone xm13Phone = new BUS_Phone(xm13.Name);
            xm13.Price = xm13Phone.getPrice();
            xm13.ID = xm13Phone.getPhoneID();
            xm13.Icon = Resources.xiaomi_13;
            xm13.Number = "1";
            xm13.DeleteButtonClicked += UserControl_DeleteButtonClicked;

            fPanelProduct.Controls.Add(xm13);
            xm13.Index = fPanelProduct.Controls.IndexOf(xm13);

        }

        private void bImportA34_Click(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelComfirm.Visible = true;
            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && product.Name == "Samsung Galaxy A34")
                {
                    int num = int.Parse(product.Number);
                    num += 1;
                    product.Number = num.ToString();
                    Debug.WriteLine("Exist");
                    return;
                }
            }

            Product a34 = new Product();
            a34.Name = "Samsung Galaxy A34";
            BUS_Phone a34Phone = new BUS_Phone(a34.Name);
            a34.Price = a34Phone.getPrice();
            a34.ID = a34Phone.getPhoneID();
            a34.Icon = Resources.a343;
            a34.Number = "1";
            a34.DeleteButtonClicked += UserControl_DeleteButtonClicked;

            fPanelProduct.Controls.Add(a34);
            a34.Index = fPanelProduct.Controls.IndexOf(a34);

        }

        private void bImportN2_Click(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelComfirm.Visible = true;
            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && product.Name == "OPPO Find N2 Flip")
                {
                    int num = int.Parse(product.Number);
                    num += 1;
                    product.Number = num.ToString();
                    Debug.WriteLine("Exist");
                    return;
                }
            }

            Product n2flip = new Product();
            n2flip.Name = "OPPO Find N2 Flip";
            BUS_Phone n2flipPhone = new BUS_Phone(n2flip.Name);
            n2flip.Price = n2flipPhone.getPrice();
            n2flip.ID = n2flipPhone.getPhoneID();
            n2flip.Icon = Resources.images_kv_en_purple_mo_1_png;
            n2flip.Number = "1";
            n2flip.DeleteButtonClicked += UserControl_DeleteButtonClicked;

            fPanelProduct.Controls.Add(n2flip);
            n2flip.Index = fPanelProduct.Controls.IndexOf(n2flip);
        }

        private void bBack_Click_1(object sender, EventArgs e)
        {
            panelImport.Visible = true;
            panelComfirm.Visible = false;
        }

        private void bComfirm_Click_1(object sender, EventArgs e)
        {
            receipt = new BUS_Receipt(0, 0, "", 0);
            if(lblSubtotal.Text == "$NULL" || lblSubtotal.Text == "$0")
            {
                MessageBox.Show("You should update your cart first");
            }
            else
            {
                int id = receipt.getReceiptID();
                int total = int.Parse(lblSubtotal.Text.Substring(1, lblSubtotal.Text.Length - 1));

                receipt = new BUS_Receipt(id, total, "", accountantID);
                receipt.addQuery();
                clearCart(id);
                lblTotal.Text = "$NULL";
                lblSubtotal.Text = "$NULL";

                panelComfirm.Visible = false;
                panelImport.Visible = true;
            }
            

        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            updateTotal();
        }

        private void updateTotal()
        {
            int total = 0;
            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && int.Parse(product.Number) > 0)
                {
                    Debug.WriteLine(product.Number);
                    int sum = product.Price * int.Parse(product.Number);
                    total += sum;
                }
            }

            lblTotal.Text = "$" + total.ToString();
            lblSubtotal.Text = "$" + total.ToString();
        }

        private void clearCart(int id)
        {
            for(int i = fPanelProduct.Controls.Count - 1; i >= 0; i--)
            {   
                Control control = fPanelProduct.Controls[i];
                if(control is Product product)
                {
                    receiptDetails = new BUS_ReceiptDetails(id, product.ID, int.Parse(product.Number), product.Price);
                    receiptDetails.addQuery();
                    control.Dispose();
                }
            }
        }
        private void panelComfirm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
