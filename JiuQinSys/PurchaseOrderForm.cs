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
    public partial class PurchaseOrderForm : Form
    {
        JiuQinEntities db = new JiuQinEntities();
        SortedList<DateTime, List<StockProduct>> gvProductsList = new SortedList<DateTime, List<StockProduct>>();
        SortedList<DateTime, List<PurchaseOrder>> dbProductsList = new SortedList<DateTime, List<PurchaseOrder>>();
        //List<PurchaseOrder> PurchaseOrderList = null;
        Task tLoadPurchaseOrder = null;

        public PurchaseOrderForm()
        {
            InitializeComponent();

            LoadPurchaseOrder();
        }

        DateTime date
        {
            get { return dateTimePicker1.Value.Date; }
        }

        private void LoadPurchaseOrder()
        {
            if (!gvProductsList.ContainsKey(date))
            {
                string query = string.Format(@"SELECT [ProductNo],p.name AS ProductName,[Count],[Company]
FROM [JiuQin].[dbo].[PurchaseOrder] AS po
LEFT JOIN [dbo].[Product] AS p ON po.productNo = p.id
WHERE date = '{0}'", date.ToString("yyyy-MM-dd"));
                gvProductsList.Add(date, db.Database.SqlQuery<StockProduct>(query).ToList());

                tLoadPurchaseOrder = Task.Run(() =>
                {
                    dbProductsList.Add(date, db.PurchaseOrder.Where(a => a.date == date).ToList());
                });
            }
            ReflashGridView();
        }

        private void ReflashGridView()
        {
            gvProducts.Rows.Clear();
            if (gvProductsList[date].Count > 0)
            {
                foreach (var o in gvProductsList[date])
                    gvProducts.Rows.Add(o.ProductNo, o.ProductName, o.Count, o.Company);
            }
        }

        private void gvProducts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            if (gvProducts.CurrentCell.ColumnIndex == colProductNo.Index ||
                gvProducts.CurrentCell.ColumnIndex == colProductName.Index)
            {
                tb.AutoCompleteMode = AutoCompleteMode.Suggest;
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                if (gvProducts.CurrentCell.ColumnIndex == colProductNo.Index)
                {
                    tb.AutoCompleteCustomSource = JiuQinHelper.pidac;
                }
                else
                {
                    tb.AutoCompleteCustomSource = JiuQinHelper.pname;
                }
            }
            else if (gvProducts.CurrentCell.ColumnIndex == colCount.Index)
            {
                tb.AutoCompleteMode = AutoCompleteMode.None;
                tb.AutoCompleteSource = AutoCompleteSource.None;
            }

            if (gvProducts.CurrentCell.ColumnIndex == colProductNo.Index ||
                gvProducts.CurrentCell.ColumnIndex == colCount.Index)
            {
                tb.ImeMode = System.Windows.Forms.ImeMode.Disable;
            }
            else
            {
                tb.ImeMode = System.Windows.Forms.ImeMode.On;
            }
        }

        string GetRowProductID(int RowIndex)
        {
            if (gvProducts[colProductNo.Index, RowIndex].Value == null)
            {
                MessageBox.Show("請先指定產品", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ReflashGridView();
                return null;
            }
            return gvProducts[colProductNo.Index, RowIndex].Value.ToString().Trim();
        }

        private class StockProduct
        {
            /// <summary>
            /// 產品型號
            /// </summary>
            public string ProductNo { get; set; }
            /// <summary>
            /// 產品名稱
            /// </summary>
            public string ProductName { get; set; }
            /// <summary>
            /// 數量
            /// </summary>
            public short Count { get; set; }
            /// <summary>
            /// 廠商名稱
            /// </summary>
            public string Company { get; set; }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadPurchaseOrder();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Task.WaitAll(tLoadPurchaseOrder);
            db.SaveChanges();
            MessageBox.Show("儲存完成");
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            using (AddProduct fm = new AddProduct())
            {
                fm.ShowDialog();
                if (string.IsNullOrEmpty(fm.SelectProductID)) return;
                var p = db.Product.First(a => a.id == fm.SelectProductID);

                if (gvProductsList[date].Count(a => a.ProductNo.Trim() == p.id.Trim()) > 0)
                {
                    MessageBox.Show(string.Format("產品\"{0}:{1}\"已在此進貨單中", p.id.Trim(), p.name.Trim()), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ReflashGridView();
                    return;
                }

                if (p.stock == -1)
                {
                    p = SetProductStock(p);
                    if (p == null)
                    {
                        ReflashGridView();
                        return;
                    }
                }

                StockProduct sp = new StockProduct() { ProductNo = p.id, ProductName = p.name };
                PurchaseOrder po = new PurchaseOrder() { date = date, productNo = p.id, count = 0 };
                gvProductsList[date].Add(sp);
                dbProductsList[date].Add(po);
                db.PurchaseOrder.Add(po);

                ReflashGridView();
            }
        }

        //private void gvProducts_MouseClick(object sender, MouseEventArgs e)
        //{
        //    gvProducts.ImeMode = System.Windows.Forms.ImeMode.Disable;
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private Modle.Product SetProductStock(Modle.Product p)
        {
            DialogResult dr = MessageBox.Show(string.Format("產品\"{0}:{1}\"尚未設定庫存量，是否設定當前庫存量", p.id.Trim(), p.name.Trim()), "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                using (ProductEdit pe = new ProductEdit(p.id))
                {
                    pe.ShowDialog();
                    if (pe.ProductObject.stock == -1)
                    {
                        MessageBox.Show("庫存量不可為-1！本產品將從進貨單移除", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return null;
                    }
                    else return pe.ProductObject;
                }
            }
            return null;
        }

        private void gvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == colDelete.Index)
                {
                    if (gvProducts[colProductName.Index, e.RowIndex].Value == null) return;
                    var ProductName = gvProducts[colProductName.Index, e.RowIndex].Value.ToString().Trim();
                    var r = MessageBox.Show("確定刪除\"" + ProductName + "\"？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (r == System.Windows.Forms.DialogResult.OK)
                    {
                        gvProductsList[date].RemoveAt(e.RowIndex);
                        var po = dbProductsList[date][e.RowIndex];
                        dbProductsList[date].Remove(po);
                        db.PurchaseOrder.Remove(po);
                        ReflashGridView();
                    }
                }
            }
        }

        private void gvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvProducts[e.ColumnIndex, e.RowIndex].Value != null)
            {
                if (e.ColumnIndex == colProductNo.Index)
                {
                    string query = string.Format(@"SELECT [name] FROM JiuQin.dbo.Product
where id = '{0}'", gvProducts[e.ColumnIndex, e.RowIndex].Value);
                    var connectCount = 0;
                    while (true)
                    {
                        try
                        {
                            using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
                            {
                                if (dt.Rows.Count == 0) return;
                                else
                                    gvProducts[colProductName.Index, e.RowIndex].Value = dt.Rows[0][0];
                                break;
                            }
                        }
                        catch { if (connectCount++ == 10) throw; }
                    }
                }
            }


            if (e.ColumnIndex == colProductNo.Index || e.ColumnIndex == colCount.Index)
            {
                gvProducts.ImeMode = System.Windows.Forms.ImeMode.Disable;
            }
            else
            {
                gvProducts.ImeMode = System.Windows.Forms.ImeMode.On;
            }
        }
    }
}
