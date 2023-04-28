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


        private void bImportRN8_Click(object sender, EventArgs e)
        {

        }

        private void bImportXiaomi13_Click(object sender, EventArgs e)
        {

        }

        private void bImportA34_Click(object sender, EventArgs e)
        {

        }

        private void bImportN2_Click(object sender, EventArgs e)
        {

        }

        private void bImportIP14_Click(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelComfirm.Visible = true;
            if (!fPanelProduct.Controls.ContainsKey("iPhone14"))
            {
                Product iPhone14 = new Product();
                iPhone14.Name = "iPhone14";
                iPhone14.Price = "$799";
                iPhone14.Icon = Resources.ip14;
                iPhone14.Number = "1";
              
                fPanelProduct.Controls.Add(iPhone14);
                
                Debug.WriteLine(fPanelProduct.Controls.IndexOf(iPhone14));

            }
            else
            {
                Product iPhone14 = fPanelProduct.Controls.Find("iPhone14", true).FirstOrDefault() as Product;
                int num = int.Parse(iPhone14.Number) + 1;
                iPhone14.Number = num.ToString();
            }
        }

        public void DeleteProduct(int index)
        {
            bool count = fPanelProduct.Controls.ContainsKey("iPhone14");
            Debug.WriteLine(count);
        }

        private void bImportRN8_Click_1(object sender, EventArgs e)
        {
            panelImport.Visible = false;
            panelComfirm.Visible = true;
            if (!fPanelProduct.Controls.ContainsKey("iPhone14"))
            {
                Product iPhone14 = new Product();
                iPhone14.Name = "Redmi Note 8";
                iPhone14.Price = "$799";
                iPhone14.Icon = Resources.redmi_note_8;
                iPhone14.Number = "1";

                fPanelProduct.Controls.Add(iPhone14);

                Debug.WriteLine(fPanelProduct.Controls.IndexOf(iPhone14));

            }
        }
    }
}
