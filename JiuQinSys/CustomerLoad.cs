using JiuQinSys.Modle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiuQinSys
{
    public partial class CustomerLoad : Form
    {
        JiuQinEntities db = new JiuQinEntities();
        static List<item> list = null;
        public Task CustomerList = null;
        bool isTransferCust = false;
        public string SelectedCustID { get; set; }
        public CustomerLoad()
        {
            InitializeComponent();

            CustomerList = new Task(Init);
            CustomerList.Start();
            dataGridView1.AutoGenerateColumns = false;
            SelectedCustID = "";
            colQuotoHistory.Visible = !isTransferCust;
        }

        public CustomerLoad(bool IsTransferCust)
            : this()
        {
            isTransferCust = IsTransferCust;
        }

        public void Init()
        {
            var query = string.Format(@"SELECT [custid],[custName],name,[invoiceaddr]
FROM [JiuQin].[dbo].[Customer] AS C
LEFT JOIN (
SELECT id,name
FROM ContactPhone
GROUP BY id,name) AS CP ON C.custid=CP.id");
            list = db.Database.SqlQuery<item>(query).ToList();
            foreach (var i in list.Where(a => a.name == null)) i.name = "";
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            Task.WaitAll(CustomerList);
            dataGridView1.DataSource = list.Where(a =>
                (a.custid.Contains(tbCustID.Text.ToUpper()) ||
                a.custid.Contains(tbCustID.Text.ToLower())) &&
                a.custName.Contains(tbCustName.Text) &&
                a.name.Contains(tbSName.Text)
            ).ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == colSelect.Index)
                {
                    if (isTransferCust)
                    {
                        var cust = dataGridView1.Rows[e.RowIndex].DataBoundItem as item;
                        SelectedCustID = cust.custid + ";" + cust.custName;
                        Close();
                    }
                    else
                    {
                        var custID = (dataGridView1.Rows[e.RowIndex].DataBoundItem as item).custid;
                        using (CustomerEdit fm = new CustomerEdit(custID))
                        {
                            fm.ShowDialog(this);
                        }
                    }
                }
                else if (e.ColumnIndex == colQuotoHistory.Index)
                {
                    var custID = (dataGridView1.Rows[e.RowIndex].DataBoundItem as item).custid;
                    using (QuoteHistory fm = new QuoteHistory(custID))
                    {
                        fm.ShowDialog(this);
                    }
                }
            }
        }

        class item
        {
            public string custid { get; set; }
            public string custName { get; set; }
            public string name { get; set; }
            public string invoiceaddr { get; set; }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (CustomerEdit fm = new CustomerEdit(""))
            {
                Hide();
                fm.ShowDialog(this);
            }
        }
    }
}
