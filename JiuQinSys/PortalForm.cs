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
        Staff u = null;

        public PortalForm(Staff User)
        {
            InitializeComponent();
            u = User;
            JiuQinHelper.Initialization();

            btnAssessment.Visible = u.Position < 2;
            btnQuote.Visible = u.Position < 2;
            //btnPrepareOrder.Visible = u.Position != byte.MaxValue;
            btnCustomer.Visible = u.Position < 2;
            btnProduct.Visible = u.Position < 2;
            btnAccountReciable.Visible = u.Position < 2;
        }

        private void PortalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            u.Logout();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuoteOrderForm fm = new QuoteOrderForm(u);
            fm.Show(this);
        }

        private void btnPrepareOrder_Click(object sender, EventArgs e)
        {
            PickingOrderForm fm = new PickingOrderForm();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AssessmentOrderForm fm = new AssessmentOrderForm(u);
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerLoad fm = new CustomerLoad();
            fm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductLoad fm = new ProductLoad();
            fm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AccountReciableForm fm = new AccountReciableForm();
            fm.Show();
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            PurchaseOrderForm fm = new PurchaseOrderForm();
            fm.Show();
        }
    }
}
