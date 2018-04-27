using JiuQinSys.Modle;
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
    public partial class ProductLoad : Form
    {
        JiuQinEntities db = new JiuQinEntities();
        static List<item> list = null;
        public Task ProductList = null;
        public ProductLoad()
        {
            InitializeComponent();
            ProductList = new Task(InitProductList);
            ProductList.Start();
            dataGridView1.AutoGenerateColumns = false;
        }

        public void InitProductList()
        {
            list = db.Product.Select(a => new item
            {
                id = a.id,
                name = a.name,
                brand = a.brand,
                type = a.type,
                price = a.price,
                stock = a.stock
            }).ToList();
            dataGridView1.BeginInvoke((MethodInvoker)delegate { ReflashProductList(); });
        }

        void ReflashProductList()
        {
            dataGridView1.DataSource = list.Where(a =>
                a.id.Contains(tbId.Text) &&
                a.name.Contains(tbName.Text) &&
                a.type.Contains(tbType.Text)
            ).ToList();
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            Task.WaitAll(ProductList);
            dataGridView1.DataSource = list.Where(a =>
                (a.id.Contains(tbId.Text.ToLower()) ||
                a.id.Contains(tbId.Text.ToUpper())) &&
                a.name.Contains(tbName.Text) &&
                a.type.Contains(tbType.Text)
            ).ToList();
        }

        class item
        {
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string brand { get; set; }
            public Nullable<int> price { get; set; }
            public short stock { get; set; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == colSelect.Index)
                {
                    var id = (dataGridView1.Rows[e.RowIndex].DataBoundItem as item).id;
                    using (ProductEdit fm = new ProductEdit(id))
                    {
                        fm.ShowDialog(this);
                    }
                }
                else if (e.ColumnIndex == colHistory.Index)
                {
                    var item = dataGridView1.Rows[e.RowIndex].DataBoundItem as item;
                    using (ProductQuoteHistory fm = new ProductQuoteHistory(item.id, item.name))
                    {
                        fm.ShowDialog(this);
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (ProductEdit fm = new ProductEdit(""))
            {
                fm.ShowDialog(this);
            }
        }
    }
}
