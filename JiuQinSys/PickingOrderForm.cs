using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;

namespace JiuQinSys
{
    public partial class PickingOrderForm : Form
    {
        PrepareOrder p = null;

        public PickingOrderForm()
        {
            InitializeComponent();
            gvProducts.AutoGenerateColumns = false;
            IsEdided = false;
        }
        public PickingOrderForm(QuoteOrder Quote, DateTime DeliverDay)
        {
            InitializeComponent();
            gvProducts.AutoGenerateColumns = false;

            p = new PrepareOrder(Quote, DeliverDay);
            p.Save();
            LoadOrder(Quote);
            tDeliverDate.Value = DeliverDay;

            if (!string.IsNullOrEmpty(p.Remark))
            {
                lbRemark.Text = p.Remark;
                tableLayoutPanel9.RowStyles[3].SizeType = SizeType.AutoSize;
            }
            else
            {
                tableLayoutPanel9.RowStyles[3].SizeType = SizeType.Absolute;
                tableLayoutPanel9.RowStyles[3].Height = 0;
            }
            IsEdided = false;
        }

        public void LoadOrder(QuoteOrder Order)
        {
            lbOrderNo.Text = p.No;
            tOrderDate.Value = p.Date;
            tbCustmorID.Text = p.CustID;
            tbCustmorName.Text = p.CustName;
            cbContact.Text = p.Contact;

            cbTel.Text = p.Phone;
            cbFax.Text = p.Fax;
            cbPhone.Text = p.Mobile;
            tbInvoiceaddr.Text = p.Invoiceaddr;

            ReflashProductList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            p.Save();
            IsEdided = false;
            foreach (KeyValuePair<int, short> kvp in RemainderStockList)
                gvProducts[colStock.Index, kvp.Key].Value = kvp.Value;
            MessageBox.Show(string.Format(@"儲存成功"));
        }

        void ReflashProductList()
        {
            gvProducts.Rows.Clear();
            if (p.ProductList.Count > 0)
            {
                gvProducts.Rows.Add(p.ProductList.Count);
                for (int i = 0; i < p.ProductList.Count; i++)
                {
                    gvProducts.Rows[i].Cells["colNo"].Value = i + 1;
                    gvProducts.Rows[i].Cells["colProductNo"].Value = p.ProductList[i].Id;
                    gvProducts.Rows[i].Cells["colProductName"].Value = p.ProductList[i].Name;
                    gvProducts.Rows[i].Cells["colDescript"].Value = p.ProductList[i].Descript;
                    gvProducts.Rows[i].Cells["colCount"].Value = p.ProductList[i].Count;
                    gvProducts.Rows[i].Cells["colUnit"].Value = p.ProductList[i].Unit;
                    gvProducts.Rows[i].Cells["colAvailable"].Value = p.ProductList[i].Available;
                    gvProducts.Rows[i].Cells["colStock"].Value = p.ProductList[i].Stock;
                }
            }
        }

        private void btnLoadOrder_Click(object sender, EventArgs e)
        {
            using (PickingLoadOrder fm = new PickingLoadOrder(OrderType.Prepare))
            {
                fm.ShowDialog();
                if (!string.IsNullOrEmpty(fm.OrderNo))
                {
                    p = new PrepareOrder(fm.OrderNo);
                    tbCustmorID.Text = p.CustID;
                    tbCustmorName.Text = p.CustName;
                    cbContact.Text = p.Contact;
                    cbTel.Text = p.Phone;
                    cbFax.Text = p.Fax;
                    cbPhone.Text = p.Mobile;
                    tbInvoiceaddr.Text = p.Invoiceaddr;
                    tOrderDate.Value = p.Date;
                    lbOrderNo.Text = p.No;
                    tDeliverDate.Value = p.DeliverDate;
                    if (!string.IsNullOrEmpty(p.Remark))
                    {
                        lbRemark.Text = p.Remark;
                        tableLayoutPanel9.RowStyles[3].SizeType = SizeType.AutoSize;
                    }
                    else
                    {
                        tableLayoutPanel9.RowStyles[3].SizeType = SizeType.Absolute;
                        tableLayoutPanel9.RowStyles[3].Height = 0;
                    }

                    ReflashProductList();
                    //gvProducts.DataSource = o.ProductList;
                    IsEdided = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (PickingCrystalReport fm = new PickingCrystalReport(p))
            {
                fm.ShowDialog();
            }
        }

        bool IsEdided { get; set; }

        private void controlEdited(object sender, EventArgs e)
        {
            IsEdided = true;
        }

        private void PickingOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsEdided)
            {
                var resule = MessageBox.Show("本單已編輯，是否不儲存就關閉?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                e.Cancel = resule == System.Windows.Forms.DialogResult.No;
            }
        }

        short BeforeChangePickingCount = 0;
        SortedList<int, short> RemainderStockList = new SortedList<int, short>();

        private void gvProducts_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            BeforeChangePickingCount = Convert.ToInt16(gvProducts[e.ColumnIndex, e.RowIndex].Value);
        }

        private void gvProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var Available = Convert.ToInt16(gvProducts[e.ColumnIndex, e.RowIndex].Value);
            var Stock = Convert.ToInt16(gvProducts[colStock.Index, e.RowIndex].Value);
            if (Available > Stock)
            {
                MessageBox.Show(Stock == -1 ? "該產品庫存量尚未設定，請先至\"產品資料\"設定庫存數量" : "輸入的數值大於庫存量", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                gvProducts[e.ColumnIndex, e.RowIndex].Value = BeforeChangePickingCount;
                return;
            }
            if (Available > Convert.ToInt16(gvProducts[colCount.Index, e.RowIndex].Value))
            {
                MessageBox.Show("揀貨量不可大於數量", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gvProducts[e.ColumnIndex, e.RowIndex].Value = BeforeChangePickingCount;
                return;
            }

            if (!Available.Equals(p.ProductList[e.RowIndex].Available))
            {
                var RemainderStock = (short)(Stock - (Available - p.ProductList[e.RowIndex].Available));
                p.UpdateStock(p.ProductList[e.RowIndex].Id, RemainderStock);
                p.ProductList[e.RowIndex].Available = Available;
                if (RemainderStockList.ContainsKey(e.RowIndex))
                    RemainderStockList[e.RowIndex] = RemainderStock;
                else
                    RemainderStockList.Add(e.RowIndex, RemainderStock);
                controlEdited(null, null);
            }
        }
    }
}
