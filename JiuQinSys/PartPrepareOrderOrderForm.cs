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
    public partial class PartPrepareOrderOrderForm : Form
    {
        JiuQinEntities db = new JiuQinEntities();

        string _quoteOrderNo = "";
        List<PartProduct> Productlist = null;
        List<DateTime> DateTimeList = null;

        public PartPrepareOrderOrderForm(string QuoteOrderNo)
        {
            InitializeComponent();

            _quoteOrderNo = QuoteOrderNo;

            InitGridViews();
        }

        private void InitGridViews()
        {
            gvProductlist.AutoGenerateColumns = false;

            DateTimeList = db.PartPrepareOrderSub
                .Where(a => a.quoteOrderNo == _quoteOrderNo)
                .Select(a => a.time.Value)
                .ToList();

            DateTimeList.Add(DateTime.Now);

            gvDateList.DataSource = DateTimeList
                .Select(a => new { time = a.ToString("yyyy-MM-dd HH:mm") })
                .Distinct().OrderByDescending(a => a.time).ToList();

            //            string query = string.Format(@"SELECT Q.productID,Q.orderno,Q.productName,Q.count,
            //(CASE WHEN PP.count IS NULL THEN 0 ELSE PP.count END) ready, P.count prepare,S.stock, PP.time
            //FROM [JiuQin].[dbo].[QuoteOrderSub] AS Q
            //LEFT JOIN [dbo].[PartPrepareOrderSub] AS PP ON Q.no = PP.quoteOrderNo AND Q.orderno = PP.orderno
            //LEFT JOIN [dbo].[PrepareOrderSub] AS P ON Q.no = P.quoteNo AND Q.orderno = P.orderno
            //LEFT JOIN [dbo].[Product] AS S ON Q.productID = S.id
            //WHERE Q.no = '{0}'
            //ORDER BY Q.orderno", _quoteOrderNo);
            //            Productlist = db.Database.SqlQuery<PartProduct>(query).ToList();

            var debug = from q in db.QuoteOrderSub
                        join pp in db.PartPrepareOrderSub on new
                        {
                            QuoteNo = q.no,
                            OrderNo = q.orderno
                        }
                        equals new
                        {
                            QuoteNo = pp.quoteOrderNo,
                            OrderNo = pp.orderNo.Value
                        } into subGrp
                        from s in subGrp.DefaultIfEmpty()
                        where q.no == _quoteOrderNo
                        select new { q.productName };
            var debugList = debug.ToList();

            var query_PartProduct = from q in db.QuoteOrderSub
                                    join pp in db.PartPrepareOrderSub on new
                                    {
                                        QuoteNo = q.no,
                                        OrderNo = q.orderno
                                    }
                                    equals new
                                    {
                                        QuoteNo = pp.quoteOrderNo,
                                        OrderNo = pp.orderNo.Value
                                    } into subGrp
                                    from s in subGrp.DefaultIfEmpty()

                                    join p in db.PrepareOrderSub on new
                                    {
                                        QuoteNo = q.no,
                                        OrderNo = q.orderno
                                    }
                                    equals new
                                    {
                                        QuoteNo = p.quoteNo,
                                        OrderNo = p.orderno
                                    }
                                    join product in db.Product on q.productID equals product.id
                                    where q.no == _quoteOrderNo
                                    orderby q.orderno
                                    select new PartProduct
                                    {
                                        productId = q.productID,
                                        orderNo = q.orderno,
                                        productName = q.productName,
                                        count = q.count == null ? (short)0 : q.count.Value,
                                        ready = s.count == null ? (short)0 : s.count.Value,
                                        prepare = p.count == null ? (short)0 : p.count.Value,
                                        stock = product.stock,
                                        time = s.time
                                    };

            Productlist = query_PartProduct.ToList();

            gvProductlist.DataSource = DefaultProductlist();

        }

        private IEnumerable<PartProduct> DefaultProductlist()
        {
            var debug = Productlist.Select(a => a.stock).GroupBy(a => a).ToList();
            return Productlist
                .GroupBy(a => new
                {
                    a.productId,
                    a.orderNo,
                    a.productName,
                    a.count,
                    a.prepare,
                    a.stock,
                })
                .Select(a => new PartProduct
                {
                    productId = a.Key.productId,
                    orderNo = a.Key.orderNo,
                    productName = a.Key.productName,
                    count = a.Key.count,
                    waitDispatch = a.Key.count - a.Sum(b => b.ready) - a.Key.prepare,
                    stock = a.Key.stock,
                })
                .ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            db.Dispose();
            db = new JiuQinEntities();
            foreach (DataGridViewRow o in gvProductlist.Rows)
            {
                var item = o.DataBoundItem as PartProduct;
                if (item.prepare != null && item.prepare > 0)
                {
                    db.PartPrepareOrderSub.Add(new PartPrepareOrderSub()
                    {
                        count = item.prepare,
                        orderNo = item.orderNo,
                        quoteOrderNo = _quoteOrderNo,
                        time = DateTime.Now,
                        productName = item.productName,
                        productId = item.productId
                    });
                }
            }
            db.SaveChanges();
            btnReporter.Enabled = true;
            MessageBox.Show("儲存成功");
            InitGridViews();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReporter_Click(object sender, EventArgs e)
        {
            SortedList<string, short> orderNoList = new SortedList<string, short>();
            foreach (DataGridViewRow o in gvProductlist.Rows)
            {
                var item = o.DataBoundItem as PartProduct;
                if (item.prepare != null && item.prepare > 0)
                    orderNoList.Add(item.productId.Trim(), item.prepare);
            }

            QuoteOrder q = new QuoteOrder(db.QuoteOrderMain.First(a => a.no == _quoteOrderNo));
            ProductCollection ProductList = new ProductCollection();
            foreach (var o in q.ProductList)
            {
                if (orderNoList.ContainsKey(o.Id))
                {
                    o.Count = orderNoList[o.Id];
                    ProductList.Add(o);
                }
            }
            var PartNo = db.QuoteOrderMain.Where(a => a.no == _quoteOrderNo).Select(a => a.date).Distinct().Count() + 1;
            q.ProductList = ProductList;
            bool pickReady = false;
            Task taskPart = Task.Run(() => pickReady = checkAllProductReady());
            using (QuoteOrderCrystalReport fm = new QuoteOrderCrystalReport(q, PartNo))
            {
                fm.ShowDialog();
            }

            if (taskPart.IsCompleted && pickReady)
            {
                Task taskMain = Task.Run(() => { q = new QuoteOrder(db.QuoteOrderMain.First(a => a.no == _quoteOrderNo)); });
                MessageBox.Show("本單已全部出貨完畢，按下確認後將顯示總出貨單");
                Task.WaitAll(taskMain);
                using (QuoteOrderCrystalReport fm = new QuoteOrderCrystalReport(q))
                {
                    fm.ShowDialog();
                }
            }
        }

        bool checkAllProductReady()
        {
            var itemList1 = db.QuoteOrderSub.Where(a => a.no == _quoteOrderNo)
            .Select(a => new { productID = a.productID, count = a.count })
            .OrderBy(a => a.productID).ToList();
            var itemList2 = db.PartPrepareOrderSub.Where(a => a.quoteOrderNo == _quoteOrderNo)
                .Select(a => new { productID = a.productId, count = a.count })
                .GroupBy(a => a.productID)
                .Select(b => new { productID = b.Key, count = b.Sum(c => c.count) })
                .OrderBy(a => a.productID).ToList();
            if (itemList1.Count == itemList2.Count)
            {
                for (int i = 0; i < itemList1.Count; i++)
                {
                    if (itemList1[i].productID != itemList2[i].productID || itemList1[i].count != itemList2[i].count)
                        return false;
                }
                return true;
            }
            return false;
        }

        private void gvProductlist_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colPartCount.Index)
            {
                var item = gvProductlist.Rows[e.RowIndex].DataBoundItem as PartProduct;
                if (item.prepare != null)
                {
                    if (item.prepare > 0)
                    {
                        if (item.prepare > item.waitDispatch)
                            gvProductlist[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
                        else
                            gvProductlist[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                    }
                    else
                        gvProductlist[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
                    btnSave.Enabled = !(item.prepare > item.waitDispatch && item.prepare > 0);
                }
                else
                    gvProductlist[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.White;
            }
        }

        private void gvProductlist_MouseClick(object sender, MouseEventArgs e)
        {
            gvProductlist.ImeMode = System.Windows.Forms.ImeMode.Disable;
        }

        private void gvDatelList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                colStock.Visible = true;
                gvProductlist.DataSource = DefaultProductlist();
                colPartCount.ReadOnly = false;
            }
            else if (e.RowIndex > 0)
            {
                colStock.Visible = false;
                colPartCount.ReadOnly = true;
                string value = gvDateList[e.ColumnIndex, e.RowIndex].Value.ToString();
                gvProductlist.DataSource = Productlist
                    .Where(a => a.time != null && a.time.Value.ToString("yyyy-MM-dd HH:mm") == value)
                    .GroupBy(a => new
                    {
                        a.productId,
                        a.orderNo,
                        a.productName,
                        a.count,
                    })
                    .Select(a => new
                    {
                        productId = a.Key.productId,
                        orderNo = a.Key.orderNo,
                        productName = a.Key.productName,
                        count = a.Key.count,
                        prepare = a.Sum(b => b.ready),
                    })
                    .ToList();
            }
        }
    }

    class PartProduct
    {
        public string productId { get; set; }
        public byte orderNo { get; set; }
        public string productName { get; set; }
        public short count { get; set; }
        public short ready { get; set; }
        public short prepare { get; set; }
        public short stock { get; set; }
        public int waitDispatch { get; set; }
        public DateTime? time { get; set; }

    }
}
