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
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            panelButtonDB.Visible = true;
            panelButtonE.Visible = false;
            panelButtonI.Visible = false;
            panelButtonR.Visible = false;
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
            /*
            if (fPanelProduct.Controls.ContainsKey("iPhone14"))
            {
                Debug.WriteLine("Exist");
            }
            else
            {
                Product iPhone14 = new Product();
                iPhone14.Name = "iPhone14";
                iPhone14.Price = "$799";
                iPhone14.Icon = Resources.ip14;
                iPhone14.Number = "1";

                fPanelProduct.Controls.Add(iPhone14);

                Debug.WriteLine(fPanelProduct.Controls.IndexOf(iPhone14));
                Debug.WriteLine(fPanelProduct.Contains(iPhone14));
                Debug.WriteLine(fPanelProduct.Controls.Contains(iPhone14));
                Debug.WriteLine(fPanelProduct.Controls.ContainsKey("iPhone14"));

            }
            */

            foreach (Control control in fPanelProduct.Controls)
            {
                if (control is Product product && product.Name == "iPhone14")
                {
                    int num = int.Parse(product.Number);
                    num += 1;
                    product.Number = num.ToString();
                    Debug.WriteLine("Exist");
                    return;
                }
            }

            Product iPhone14 = new Product();
            iPhone14.Name = "iPhone14";
            iPhone14.Price = "$799";
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
            redmi8.Price = "$149";
            redmi8.Icon = Resources.redmi_note_8;
            redmi8.Number = "1";
            redmi8.DeleteButtonClicked += UserControl_DeleteButtonClicked;

            fPanelProduct.Controls.Add(redmi8);
            redmi8.Index = fPanelProduct.Controls.IndexOf(redmi8);

        }

        private void bBack_Click(object sender, EventArgs e)
        {
            panelImport.Visible = true;
            panelComfirm.Visible = false;
        }

        private void bComfirm_Click(object sender, EventArgs e)
        {

        }
        private void UserControl_DeleteButtonClicked(object sender, EventArgs e)
        {
            Product control = sender as Product;
            if (control != null)
            {
                fPanelProduct.Controls.Remove(control);
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
            xm13.Price = "$1088";
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
            a34.Price = "$459";
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
            n2flip.Price = "$850";
            n2flip.Icon = Resources.images_kv_en_purple_mo_1_png;
            n2flip.Number = "1";
            n2flip.DeleteButtonClicked += UserControl_DeleteButtonClicked;

            fPanelProduct.Controls.Add(n2flip);
            n2flip.Index = fPanelProduct.Controls.IndexOf(n2flip);
        }
    }
}
