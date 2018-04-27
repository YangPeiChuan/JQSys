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
    public partial class AddProduct : Form
    {
        public AddProduct()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private string _selectProductID = "";
        public string SelectProductID { get { return _selectProductID.Trim(); } }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbKeyWord_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            if (!string.IsNullOrEmpty(tbKeyWord.Text))
                dataGridView1.DataSource = JiuQinHelper.ProductList.Where(a => a.Name !=null && a.Name.Contains(tbKeyWord.Text)).ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colSelect.Index)
            {
                _selectProductID = dataGridView1[colId.Index, e.RowIndex].Value.ToString();
                Close();
            }
        }
    }
}
