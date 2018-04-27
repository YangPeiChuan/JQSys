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
    public partial class DealDate : Form
    {
        public DealDate()
        {
            InitializeComponent();
        }

        bool _isDeal = false;

        public bool IsDeal { get { return _isDeal; } }

        public DateTime DeliverDate { get { return dateTimePicker1.Value; } }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _isDeal = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
