using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiuQinSys
{
    public partial class OrderRemark : Form
    {
        OrderBase o = null;

        public OrderRemark(OrderBase o)
        {
            InitializeComponent();
            this.o = o;
            textBox1.Text = o.Remark;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            o.Remark = textBox1.Text;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
