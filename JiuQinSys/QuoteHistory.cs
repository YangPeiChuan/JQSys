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
    public partial class QuoteHistory : Form
    {
        private string custID = "";
        public QuoteHistory(string CustID)
        {
            InitializeComponent();
            gvQueryResult.AutoGenerateColumns = false;
            custID = CustID;
            dStart.Value = DateTime.Now.AddYears(-1);
            dEnd.Value = DateTime.Now;
            btnQuery_Click(null, null);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            using (JiuQinEntities db = new JiuQinEntities())
            {
                var query = from m in db.QuoteOrderMain
                            join s in db.QuoteOrderSub on m.no equals s.no
                            join p in db.Product on s.productID equals p.id
                            where m.custID == custID
                            orderby m.date descending, s.orderno descending
                            select new
                            {
                                m.date,
                                m.no,
                                s.productName,
                                s.count,
                                p.unit,
                                s.pice
                            };
                if (cbDateRange.Checked)
                {
                    var endDate = dEnd.Value.AddDays(1);
                    query = query.Where(a => a.date >= dStart.Value && a.date <= endDate);
                }
                else
                    query = query.Take(1000);
                gvQueryResult.DataSource = query.ToList();
            }
        }

        private void cbDateRange_CheckedChanged(object sender, EventArgs e)
        {
            dStart.Enabled = cbDateRange.Enabled;
            dEnd.Enabled = cbDateRange.Enabled;
        }
    }
}
