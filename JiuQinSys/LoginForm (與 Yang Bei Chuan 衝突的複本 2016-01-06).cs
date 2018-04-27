using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace JiuQinSys
{
    public partial class LoginForm : Form
    {
        User u = new User();

        public LoginForm()
        {
            InitializeComponent();

            btnLogin_Click(null, null);

            tbID.DataBindings.Add("Text", u, "ID", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPassword.DataBindings.Add("Text", u, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (u.Login())
            {
                Hide();
                using (PortalForm fm = new PortalForm(u))
                {
                    fm.ShowDialog();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(null, null);
        }
    }
}
