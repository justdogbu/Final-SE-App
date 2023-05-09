using BUS;
using GUI;
using OpenTK.Graphics.ES11;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AccuPhone
{
    public partial class fLogin : Form
    {
        BUS_Accountant acc;
        public fLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void fLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void fLogin_Load(object sender, EventArgs e)
        {
            bLogin.TabStop = false;
            bLogin.FlatStyle = FlatStyle.Flat;
            bLogin.FlatAppearance.BorderSize = 0;
            bLogin.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            txtUserEmail.KeyPress += new KeyPressEventHandler(txtEmail_KeyPress);
            txtPassword.KeyPress += new KeyPressEventHandler(txtPassword_KeyPress);
            
        }

        
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char) Keys.Enter) {
                bLogin_Click(sender, e);
            }
        }
        
        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                bLogin_Click(sender, e);
            }
            if (e.KeyChar == (char)Keys.Tab)
            {
                txtPassword_Click(sender, e);
            }
        }


        private void txtPassword_Leave(object sender, EventArgs e)
        {
            panelPassword.BackColor = Color.Silver;
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Type your password";
                txtPassword.UseSystemPasswordChar = true;
            }
        }


        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
            panelPassword.BackColor = Color.DeepSkyBlue;
            if (txtPassword.Text == "Type your password")
            {
                txtPassword.Text = string.Empty;
            }
        }

        private void txtUserEmail_Click(object sender, EventArgs e)
        {
            panelUser.BackColor = Color.DeepSkyBlue;
            if (txtUserEmail.Text == "Type your email")
            {
                txtUserEmail.Text = string.Empty;
            }
        }

        private void txtUserEmail_Leave(object sender, EventArgs e)
        {
            panelUser.BackColor = Color.Silver;
            if (txtUserEmail.Text == "")
            {
                txtUserEmail.Text = "Type your email";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(txtPassword.Text);
            acc = new BUS_Accountant(0, "", txtUserEmail.Text, "", 0);
            DataTable account = acc.selectEmail();
            if(account.Rows.Count > 0)
            {
                DataTable passwordQuery = acc.selectPassword();
                string password = passwordQuery.Rows[0][0].ToString();
                Debug.WriteLine(password);
                if (password == txtPassword.Text){
                    Home home = new Home(txtUserEmail.Text, txtPassword.Text) ;
                    this.Visible = false;
                    home.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid password");
                }
            }
            else
            {
                MessageBox.Show("The email is not exist");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}