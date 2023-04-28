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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }


        private void picMenu1_Click(object sender, EventArgs e)
        {
            panelMenuBar.Visible = true;
        }

        private void picMenu2_Click(object sender, EventArgs e)
        {
            panelMenuBar.Visible = false;
        }
    }
}
