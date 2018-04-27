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
    public partial class PickingLoadOrder : Form
    {
        OrderType OrderType;

        List<LoadPrepare> conditionQuery = new List<LoadPrepare>();
        public PickingLoadOrder(OrderType OrderType)
        {
            InitializeComponent();
            gvResult.AutoGenerateColumns = false;
            gvPrepareItem.AutoGenerateColumns = false;
            this.OrderType = OrderType;
            string query = string.Format(@"SELECT p.[no],q.[date],[custName],[contact],[done],[deliverDate]
FROM PrepareOrderMain as p
left join QuoteOrderMain as q on p.quoteNo = q.no
order by deliverDate,p.[no]");

            using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    conditionQuery.Add(new LoadPrepare(dr));
                }
            }

            query = string.Format(@"SELECT p.[no],q.[orderno],[productID],[productName],q.[count] QCount,p.[count] PCount,[stock]
FROM [PrepareOrderSub] as p
LEFT JOIN [QuoteOrderSub] as q on p.quoteNo = q.no and p.orderno = q.orderno
LEFT JOIN [Product] as item on q.productID = item.id
WHERE q.[count] != p.count");

            JiuQinEntities db = new JiuQinEntities();
            var PrepareItemList = new List<LoadPrepareItem>();

            foreach (var o in db.Database.SqlQuery<LoadPrepareStatus>(query))
            {
                conditionQuery.Find(a => a.no == o.No).WaitTypeCount++;
                var p = PrepareItemList.Find(a => a.ProductID == o.ProductID);
                if (p != null) p.Count = (short)(o.QCount - o.PCount);
                PrepareItemList.Add(new LoadPrepareItem()
                {
                    ProductID = o.ProductID,
                    ProductName = o.ProductName,
                    Count = (short)(o.QCount - o.PCount),
                    Stock = o.Stock
                });
            }

            gvPrepareItem.DataSource = PrepareItemList;

            gvResult.DataSource = conditionQuery;

            //            Task.Run(() =>
            //            {
            //                lock (conditionQuery)
            //                {
            //                    JiuQinEntities e = new JiuQinEntities();
            //                    conditionQuery = e.Database.SqlQuery<LoadPrepare>(string.Format(@"SELECT q.[no],q.[date],[custName],[contact]
            //FROM PrepareOrderMain as p left join QuoteOrderMain as q on p.quoteNo = q.no
            //order by p.date desc")).ToList();
            //                }
            //            });
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

        private void gvPrepareItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var item = (LoadPrepareItem)gvPrepareItem.Rows[e.RowIndex].DataBoundItem;
            if (item.Count > item.Stock) e.CellStyle.ForeColor = Color.Red;
        }
    }
}
