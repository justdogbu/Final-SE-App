using BUS;
using GUI;
using System.Data;
using System.Diagnostics;

namespace AccuPhone
{
    public partial class fLogin : Form
    {
        BUS_Accountant acc;
        public fLogin()
        {
            InitializeComponent();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            bLogin.TabStop = false;
            bLogin.FlatStyle = FlatStyle.Flat;
            bLogin.FlatAppearance.BorderSize = 0;
            bLogin.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
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
                    Home home = new Home();
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
    }
}