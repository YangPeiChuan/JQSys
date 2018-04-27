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
    public partial class AssessmentLoadOrder : Form
    {
        OrderType OrderType;

        List<LoadAssessment> conditionQuery = new List<LoadAssessment>();
        public AssessmentLoadOrder(OrderType OrderType)
        {
            InitializeComponent();
            gvResult.AutoGenerateColumns = false;
            this.OrderType = OrderType;
            string query = "";
            switch (OrderType)
            {
                case JiuQinSys.OrderType.Quote:
                    query = string.Format(@"SELECT TOP 10 [no],[date],[custName],[contact]
FROM [JiuQin].[dbo].[QuoteOrderMain]
order by date desc");
                    break;

                case JiuQinSys.OrderType.Prepare:
                    query = string.Format(@"SELECT TOP 10 p.[no],q.[date],[custName],[contact]
FROM PrepareOrderMain as p left join QuoteOrderMain as q on p.quoteNo = q.no
order by p.date desc");
                    break;
                case JiuQinSys.OrderType.Assessment:
                    query = string.Format(@"SELECT TOP 10 [no],[date],[custName],[contact],[quoteno]
FROM [JiuQin].[dbo].[AssessmentOrderMain]
order by date desc");
                    break;
            }

            using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    conditionQuery.Add(new LoadAssessment(dr));
                }
            }
            gvResult.DataSource = conditionQuery;

            Task.Run(() =>
            {
                lock (conditionQuery)
                {
                    JiuQinEntities e = new JiuQinEntities();
                    switch (OrderType)
                    {
                        case JiuQinSys.OrderType.Quote:
                            conditionQuery = e.Database.SqlQuery<LoadAssessment>(string.Format(@"SELECT [no],[date],[custName],[contact]
FROM [JiuQin].[dbo].[QuoteOrderMain]
order by date desc")).ToList();
                            break;
                        case JiuQinSys.OrderType.Prepare:
                            conditionQuery = e.Database.SqlQuery<LoadAssessment>(string.Format(@"SELECT q.[no],q.[date],[custName],[contact]
FROM PrepareOrderMain as p left join QuoteOrderMain as q on p.quoteNo = q.no
order by p.date desc")).ToList();
                            break;
                        case JiuQinSys.OrderType.Assessment:
                            conditionQuery = e.Database.SqlQuery<LoadAssessment>(string.Format(@"SELECT [no],[date],[custName],[contact],[quoteno]
FROM [JiuQin].[dbo].[AssessmentOrderMain]
order by date desc")).ToList();
                            break;
                    }
                }
            });
        }

        private void LoadOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            conditionQuery.Clear();
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            gvResult.DataSource = conditionQuery.Where(a =>
                            a.custName.Contains(tbCustName.Text) &&
                            a.contact.Contains(tbContact.Text)
                            ).ToList();
        }

        string _orderNo = null;

        public string OrderNo { get { return _orderNo; } }

        private void gvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colSelect.Index)
            {
                _orderNo = (gvResult.Rows[e.RowIndex].DataBoundItem as LoadOrderModel).no;
                Close();
            }
        }
    }
}
