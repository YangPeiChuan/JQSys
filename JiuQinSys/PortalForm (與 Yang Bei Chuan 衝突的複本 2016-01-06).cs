using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JiuQinSys
{
    public partial class PortalForm : Form
    {
        User u = null;

        public PortalForm(User User)
        {
            InitializeComponent();
            u = User;
        }

        private void PortalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            u.Logout();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Form1 fm = new Form1(u))
            {
                Hide();
                fm.ShowDialog();
                Show();
            }
        }
    }
}
