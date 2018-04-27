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
        Staff user = new Staff();

        public LoginForm()
        {
            InitializeComponent();

            btnLogin_Click(null, null);

            tbID.DataBindings.Add("Text", user, "ID", false, DataSourceUpdateMode.OnPropertyChanged);
            tbPassword.DataBindings.Add("Text", user, "Password", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (user.Login())
            {
                Hide();
                using (PortalForm fm = new PortalForm(user))
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
