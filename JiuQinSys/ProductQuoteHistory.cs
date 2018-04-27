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
    public partial class ProductQuoteHistory : Form
    {
        public ProductQuoteHistory(string ProductID, string ProductName)
        {
            InitializeComponent();
            _productID = ProductID;
            dStart.Value = DateTime.Now.AddMonths(-6);
            Text = ProductID + "　" + ProductName + "　歷史交易";
            btnQuery_Click(null, null);
        }

        string _productID = "";

        private void btnQuery_Click(object sender, EventArgs e)
        {
            using (JiuQinEntities db = new JiuQinEntities())
            {
                var query = from qs in db.QuoteOrderSub
                            join qm in db.QuoteOrderMain on qs.no equals qm.no
                            where qs.productID == _productID && qs.count != null
                            select new ProductQuoteHistoryVM
                            {
                                contact = qm.contact,
                                count = qs.count,
                                custID = qm.custID,
                                custName = qm.custName,
                                date = qm.date,
                                mobile = qm.mobile,
                                no = qm.no,
                                phone = qm.phone,
                                pice = qs.pice,
                            };
                if (cbDateRange.Checked)
                {
                    var endDate = dEnd.Value.AddDays(1);
                    query = query.Where(a => a.date >= dStart.Value && a.date <= endDate);
                }
                else
                    query = query.Take(500);
                var queryResult = query.OrderByDescending(a => a.no).ToList();
                gvQueryResult.DataSource = queryResult;
                lbCount.Text = cbDateRange.Checked ? "總數：" + queryResult.Sum(a => a.count.Value).ToString("N0") : "";
            }
        }

        private void cbDateRange_CheckedChanged(object sender, EventArgs e)
        {
            dStart.Enabled = cbDateRange.Enabled;
            dEnd.Enabled = cbDateRange.Enabled;
        }

        private class ProductQuoteHistoryVM
        {
            public string no { get; set; }
            public DateTime? date { get; set; }
            public string custID { get; set; }
            public string custName { get; set; }
            public string contact { get; set; }
            public string phone { get; set; }
            public string mobile { get; set; }
            public short? count { get; set; }
            public int? pice { get; set; }
        }

        private void gvQueryResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == colQuoteOrder.Index)
                {
                    var orderNo = (gvQueryResult.Rows[e.RowIndex].DataBoundItem as ProductQuoteHistoryVM).no;
                    QuoteOrderForm fm = new QuoteOrderForm(orderNo);
                    fm.Show();
                }
            }
        }
    }
}
