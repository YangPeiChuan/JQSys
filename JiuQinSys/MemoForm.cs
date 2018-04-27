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
    public partial class MemoForm : Form
    {
        public MemoForm(OrderFormProduct Product, bool IsPrintVisible = true)
        {
            InitializeComponent();

            this.Text = Product.Name;
            tbMemo.Text = Product.Descript;
            tbMemo.ImeMode = System.Windows.Forms.ImeMode.OnHalf;
            cbIsPrint.Checked = Product.IsDisplayNameAndDescript;
            p = Product;
            cbIsPrint.Visible = IsPrintVisible;
        }

        OrderFormProduct p = null;

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.Descript = tbMemo.Text;
            p.IsDisplayNameAndDescript = cbIsPrint.Checked;
            Close();
        }
    }
}
