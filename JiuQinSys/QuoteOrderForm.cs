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
using JiuQinSys.Modle;
using System.Threading.Tasks;
//using System.Web.UI.WebControls.DataBoundControl;

namespace JiuQinSys
{
    public partial class QuoteOrderForm : Form
    {
        Staff User = null;

        QuoteOrder o = null;

        public QuoteOrderForm(Staff User)
        {
            InitializeComponent();
            this.User = User;
            lbUserName.Text = User.Name;

            tbCustmorID.AutoCompleteCustomSource = JiuQinHelper.cidac;
            tbCustmorName.AutoCompleteCustomSource = JiuQinHelper.cname;

            LoadOrder(new QuoteOrder(User));
            gvProducts.AutoGenerateColumns = false;
            IsEdided = false;
            rbHasTax.Checked = true;
            //tbCustmorContact
        }

        public QuoteOrderForm(AssessmentOrder Assessment, Staff User)
        {
            InitializeComponent();
            o = new QuoteOrder(Assessment);

            //因出貨憑單日期可能不會是今天，所以不自動儲存取得單號
            //Task saveAssessmentTask = Task.Run(() =>
            //{
            //    o.Save();
            //});

            Task saveQuoteOrderTask = Task.Run(() =>
            {
                JiuQinEntities db = new JiuQinEntities();
                var orderAssessment = db.AssessmentOrderMain.Where(a => a.no == Assessment.No).First();
                //因出貨憑單日期可能不會是今天，所以不自動儲存取得單號
                //Task.WaitAll(saveAssessmentTask);
                orderAssessment.quoteno = o.No;
                db.SaveChanges();
            });

            LoadOrder(o);
            CalculateAmt();
            this.User = User;
            lbUserName.Text = User.Name;

            gvProducts.AutoGenerateColumns = false;
            //因出貨憑單日期可能不會是今天，所以不自動儲存取得單號
            //Task.WaitAll(saveAssessmentTask);
            tbOrderNo.Text = o.No;
        }

        public QuoteOrderForm(string OrderNo)
        {
            InitializeComponent();
            gvProducts.AutoGenerateColumns = false;
            LoadOrder(OrderNo);
            CalculateAmt();
        }


        public void LoadOrder(QuoteOrder Order)
        {
            o = Order;
            tOrderDate.Value = o.Date;
            tbCustmorID.Text = o.CustID;
            tbCustmorName.Text = o.CustName;
            cbContact.Text = o.Contact;

            cbTel.Text = o.Phone;
            cbFax.Text = o.Fax;
            cbPhone.Text = o.Mobile;
            tbInvoiceaddr.Text = o.Invoiceaddr;

            rbHasTax.Checked = o.TaxRate != 0;
            rbNonTax.Checked = o.TaxRate == 0;

            ReflashProductList();
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
                    tb.AutoCompleteCustomSource = JiuQinHelper.pidac;
                else
                    tb.AutoCompleteCustomSource = JiuQinHelper.pname;
            }
            else if (gvProducts.CurrentCell.ColumnIndex == colCount.Index)
            {
                tb.AutoCompleteMode = AutoCompleteMode.None;
                tb.AutoCompleteSource = AutoCompleteSource.None;
            }
        }

        Customer c = null;

        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.KeyData == Keys.Enter)
            {
                if (tb.Text.Length > 10 && tb.Text.Contains(';'))
                {
                    FillCustInfo();
                    IsEdided = true;
                }
                tbCustmorName.Focus();
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            using (AddProduct fm = new AddProduct())
            {
                fm.ShowDialog();
                if (!string.IsNullOrEmpty(fm.SelectProductID))
                {
                    //gvProducts[colProductNo.Index, gvProducts.Rows.Count - 1].Selected = true;
                    gvProducts.CurrentCell = gvProducts[colProductNo.Index, gvProducts.Rows.Count - 1];
                    gvProducts.BeginEdit(true);
                    gvProducts[colProductNo.Index, gvProducts.Rows.Count - 1].Value = fm.SelectProductID;
                    gvProducts.EndEdit();
                }
            }
        }

        private void gvProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvProducts[e.ColumnIndex, e.RowIndex].Value != null)
                {
                    if (e.ColumnIndex == colProductNo.Index)
                    {
                        if (e.RowIndex == o.ProductList.Count || o.ProductList[e.RowIndex].Id != gvProducts[e.ColumnIndex, e.RowIndex].Value.ToString())
                        {
                            string query = string.Format(@"SELECT [id],[name],[brand],[type],[unit],[price],[inventory],[buypoint],[buyday],[stock]
FROM JiuQin.dbo.Product
where id = '{0}'", gvProducts[e.ColumnIndex, e.RowIndex].Value);

                            int connectCount = 0;
                            while (true)
                            {
                                try
                                {
                                    using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
                                    {
                                        if (dt.Rows.Count == 0) return;
                                        if (e.RowIndex == o.ProductList.Count)
                                        {
                                            o.ProductList.Add(new OrderFormProduct(dt.Rows[0]));
                                        }
                                        else if (o.ProductList[e.RowIndex].Id != gvProducts[e.ColumnIndex, e.RowIndex].Value.ToString())
                                            o.ProductList[e.RowIndex] = new OrderFormProduct(dt.Rows[0]);
                                    }
                                    break;
                                }
                                catch { if (connectCount++ == 10) throw; }
                            }
                        }
                        ReflashProductList(colProductName.Index, e.RowIndex);
                    }
                    else if (e.ColumnIndex == colProductName.Index)
                    {

                        if (o.ProductList.Count > e.RowIndex)
                        {
                            o.ProductList[e.RowIndex].Name = gvProducts[e.ColumnIndex, e.RowIndex].Value.ToString().Trim();
                            ReflashProductList(colCount.Index, e.RowIndex);
                        }
                        else
                        {
                            MessageBox.Show("請輸入產品編號後再編輯產品名稱", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            ReflashProductList(colProductNo.Index, e.RowIndex);
                        }

                    }
                    else if (e.ColumnIndex == colCount.Index)
                    {
                        o.ProductList[e.RowIndex].Count = Convert.ToInt16(gvProducts[e.ColumnIndex, e.RowIndex].Value);
                        ReflashProductList(colPrice.Index, e.RowIndex);
                    }
                    else if (e.ColumnIndex == colPrice.Index)
                    {
                        o.ProductList[e.RowIndex].Price = Convert.ToInt32(gvProducts[e.ColumnIndex, e.RowIndex].Value);
                        ReflashProductList(colProductNo.Index, e.RowIndex + 1);
                    }

                    //gvProducts.BeginInvoke((MethodInvoker)delegate { ReflashProductList(e.RowIndex); });
                    CalculateAmt();
                    //if (e.ColumnIndex == colProductNo.Index)
                    //    gvProducts.CurrentCell = gvProducts[colCount.Index, e.RowIndex - 1];
                    //else
                    //    gvProducts.CurrentCell = gvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    controlEdited(null, null);
                }
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            o.Date = tOrderDate.Value;
            o.CustID = tbCustmorID.Text;
            o.CustName = tbCustmorName.Text;
            o.Contact = cbContact.Text;

            o.Phone = cbTel.Text;
            o.Fax = cbFax.Text;
            o.Mobile = cbPhone.Text;
            o.Invoiceaddr = tbInvoiceaddr.Text;
            o.TaxRate = rbHasTax.Checked ? (byte)5 : (byte)0;
            o.Save();

            tbOrderNo.Text = o.No;
            IsEdided = false;
            tOrderDate.Enabled = false;
            MessageBox.Show(string.Format(@"儲存成功
出貨單編號：{0}", o.No));
        }

        private void CalculateAmt()
        {
            double sum = o.ProductList.Sum(p => p.Amt);
            lbSubtotal.Text = sum.ToString("N0");
            var amt = rbHasTax.Checked ? (int)((sum * 1.05) + 0.5) : sum;
            lbAmt.Text = amt.ToString("N0");
        }

        void ReflashProductList()
        {

            gvProducts.Rows.Clear();
            if (o.ProductList.Count > 0)
            {
                gvProducts.Rows.Add(o.ProductList.Count);
                for (int i = 0; i < o.ProductList.Count; i++)
                {
                    gvProducts.Rows[i].Cells["colNo"].Value = i + 1;
                    gvProducts.Rows[i].Cells["colProductNo"].Value = o.ProductList[i].Id;
                    gvProducts.Rows[i].Cells["colProductName"].Value = o.ProductList[i].Name;
                    gvProducts.Rows[i].Cells["colCount"].Value = o.ProductList[i].Count;
                    gvProducts.Rows[i].Cells["colUnit"].Value = o.ProductList[i].Unit;
                    gvProducts.Rows[i].Cells["colPrice"].Value = o.ProductList[i].Price;
                    gvProducts.Rows[i].Cells["colAmt"].Value = o.ProductList[i].Amt;
                    gvProducts.Rows[i].Cells["colStock"].Value = o.ProductList[i].Stock;

                    var ShortRemark = o.ProductList[i].Descript.Length > 10 ? 
                        o.ProductList[i].Descript.Substring(0, 10) + "..." :
                        o.ProductList[i].Descript;
                    gvProducts.Rows[i].Cells["colShortRemark"].Value = ShortRemark;
                    
                }
            }
        }

        void ReflashProductList(int rowindex)
        {
            ReflashProductList();
            gvProducts.ClearSelection();
            gvProducts.Rows[rowindex].Cells[0].Selected = true;
        }

        private void nudTax_ValueChanged(object sender, EventArgs e)
        {
            CalculateAmt();
            controlEdited(null, null);
        }

        private void cbContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTel.Text = "";
            cbFax.Text = "";
            cbPhone.Text = "";
            cbTel.DataSource = c.Contacts.Where(a => a.Name == cbContact.Text && a.Type == Customer.ContactPhone.PhoneType.室內).ToList();
            cbFax.DataSource = c.Contacts.Where(a => a.Name == cbContact.Text && a.Type == Customer.ContactPhone.PhoneType.傳真).ToList();
            cbPhone.DataSource = c.Contacts.Where(a => a.Name == cbContact.Text && a.Type == Customer.ContactPhone.PhoneType.行動).ToList();
            controlEdited(null, null);
        }

        /// <summary>
        /// 轉出貨單，暫時廢止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeliver11_Click(object sender, EventArgs e)
        {
            using (DealDate fm = new DealDate())
            {
                fm.ShowDialog();
                if (fm.IsDeal)
                {
                    o.Date = tOrderDate.Value;
                    o.CustID = tbCustmorID.Text;
                    o.CustName = tbCustmorName.Text;
                    o.Contact = cbContact.Text;

                    o.Phone = cbTel.Text;
                    o.Fax = cbFax.Text;
                    o.Mobile = cbPhone.Text;
                    o.Invoiceaddr = tbInvoiceaddr.Text;
                    o.Save();

                    tbOrderNo.Text = o.No;
                    btnNewOrder.Enabled = false;
                    btnPickingState.Enabled = true;
                    tOrderDate.Enabled = false;
                    btnPrint.Enabled = true;

                    MessageBox.Show(string.Format(@"儲存成功
表單編號：{0}", o.No));

                    using (PickingOrderForm pfm = new PickingOrderForm(o, fm.DeliverDate))
                    {
                        //pfm.ShowDialog();
                    }
                }
            }
        }

        private void btnLoadOrder_Click(object sender, EventArgs e)
        {
            using (LoadOrder fm = new LoadOrder(OrderType.Quote))
            {
                fm.ShowDialog();
                if (!string.IsNullOrEmpty(fm.OrderNo))
                    LoadOrder(fm.OrderNo);
            }
        }

        private void LoadOrder(string OrderNo)
        {
            using (JiuQinEntities db = new JiuQinEntities())
            {
                var Entity = db.QuoteOrderMain.FirstOrDefault(a => a.no == OrderNo);
                if (Entity != null)
                {
                    o = new QuoteOrder(Entity);
                    //DeliverState();

                    tbCustmorID.Text = o.CustID;
                    tbCustmorName.Text = o.CustName;
                    cbContact.Text = o.Contact;
                    cbTel.Text = o.Phone;
                    cbFax.Text = o.Fax;
                    cbPhone.Text = o.Mobile;
                    tbInvoiceaddr.Text = o.Invoiceaddr;
                    tOrderDate.Value = o.Date;
                    tbOrderNo.Text = o.No;
                    rbHasTax.Checked = o.TaxRate != 0;
                    rbNonTax.Checked = o.TaxRate == 0;
                    //lbSubtotal.Text = o.ProductList.TotalAmount.ToString();
                    //lbAmt.Text = o.TotalAmount.ToString();
                    lbBalance.Text = o.Balance.ToString();

                    btnBalance.Enabled = o.TotalAmount != o.Balance;

                    ReflashProductList();
                    CalculateAmt();
                    //gvProducts.DataSource = o.ProductList;
                    IsEdided = false;
                    tOrderDate.Enabled = false;

                }
            }
        }

        //private void DeliverState()
        //{
        //    JiuQinEntities db = new JiuQinEntities();
        //    btnNewOrder.Enabled = db.PrepareOrderMain.Count(a => a.quoteNo == o.No) == 0;
        //    btnPickingState.Enabled = !btnNewOrder.Enabled;
        //}

        private void btnPrint_Click(object sender, EventArgs e)
        {
            o.Date = tOrderDate.Value;
            o.CustID = tbCustmorID.Text;
            o.CustName = tbCustmorName.Text;
            o.Contact = cbContact.Text;

            o.Phone = cbTel.Text;
            o.Fax = cbFax.Text;
            o.Mobile = cbPhone.Text;
            o.Invoiceaddr = tbInvoiceaddr.Text;

            using (QuoteOrderCrystalReport fm = new QuoteOrderCrystalReport(o))
            {
                fm.ShowDialog();
            }
        }

        private void btnOrderRemark_Click(object sender, EventArgs e)
        {
            using (OrderRemark fm = new OrderRemark(o))
            {
                var remark = o.Remark;
                fm.ShowDialog();
                IsEdided = !o.Remark.Equals(remark);
            }
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            using (QuoteBalance fm = new QuoteBalance(o.Balance, int.Parse(lbAmt.Text.Replace(",", ""))))
            {
                fm.ShowDialog();
                o.Balance = fm.Balance;
                lbBalance.Text = o.Balance.ToString();
            }
        }

        private void tOrderDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) tbCustmorID.Focus();
        }

        private void tbCustmorName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) cbContact.Focus();
        }

        private void cbContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) tbInvoiceaddr.Focus();
        }

        private void tbInvoiceaddr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                gvProducts.Focus();
                gvProducts.CurrentCell = gvProducts.CurrentCell = gvProducts.Rows[0].Cells[1];
            }
        }

        private void btnPickingState_Click(object sender, EventArgs e)
        {
            using (PartPrepareOrderOrderForm fm = new PartPrepareOrderOrderForm(o.No))
            {
                fm.ShowDialog();
            }
        }

        public bool IsEdided { get; set; }

        private void controlEdited(object sender, EventArgs e)
        {
            IsEdided = true;
        }

        private void QuoteOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsEdided)
            {
                var resule = MessageBox.Show("本單已編輯，是否不儲存就關閉?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                e.Cancel = resule == System.Windows.Forms.DialogResult.No;
            }
        }

        private void btnLoadCust_Click(object sender, EventArgs e)
        {
            using (CustomerLoad fm = new CustomerLoad(true))
            {
                fm.ShowDialog();
                if (!string.IsNullOrEmpty(fm.SelectedCustID.Trim()))
                {
                    tbCustmorID.Text = fm.SelectedCustID.Trim();
                    FillCustInfo();
                }
            }
        }

        void FillCustInfo()
        {
            //if (tb.Name == "tbCustmorName")
            //c = new Customer(tbCustmorName.Text.Split(';')[1].Trim());
            //else
            c = new Customer(tbCustmorID.Text.Split(';')[0].Trim());
            tbCustmorID.Text = c.CustID;
            tbCustmorName.Text = c.CustName;
            tbInvoiceaddr.Text = c.Invoiceaddr;
            if (c.Contacts.Count > 0)
            {
                cbContact.DataSource = c.Contacts.GroupBy(g => g.Name).Select(s => s.First()).ToList();
            }
            else
            {
                cbContact.Text = "";
                cbTel.DataSource = null;
                cbTel.Text = "";
                cbFax.DataSource = null;
                cbFax.Text = "";
                cbPhone.DataSource = null;
                cbPhone.Text = "";
            }
            tbCustmorName.Focus();
            //gvProducts[1, 0].Selected = true;
        }

        private void gvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (o.ProductList.Count > e.RowIndex)
            {
                if (e.ColumnIndex == colDel.Index)
                {
                    DialogResult m = MessageBox.Show(string.Format("是否移除編號：{0}  \"{1}\"", o.ProductList[e.RowIndex].Id, o.ProductList[e.RowIndex].Name), "", MessageBoxButtons.YesNo);
                    if (m == System.Windows.Forms.DialogResult.Yes)
                    {
                        o.ProductList.RemoveAt(e.RowIndex);
                        ReflashProductList();
                        CalculateAmt();
                    }
                    gvProducts.CurrentCell = gvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }
                else if (e.ColumnIndex == colRemark.Index)
                {
                    using (MemoForm fm = new MemoForm(o.ProductList[e.RowIndex], false))
                    {
                        fm.ShowDialog();
                        gvProducts.CurrentCell = gvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                }
            }
        }

        void ReflashProductList(int columnIndex, int rowIndex)
        {
            gvProducts.BeginInvoke((MethodInvoker)delegate
            {
                ReflashProductList();
                gvProducts.ClearSelection();
                gvProducts.Rows[rowIndex].Cells[columnIndex].Selected = true;
                gvProducts.CurrentCell = gvProducts.Rows[rowIndex].Cells[columnIndex];
            });
        }

        private void gvProducts_MouseClick(object sender, MouseEventArgs e)
        {
            if (gvProducts.CurrentCell.ColumnIndex == colProductName.Index)
                gvProducts.ImeMode = System.Windows.Forms.ImeMode.On;
            else
                gvProducts.ImeMode = System.Windows.Forms.ImeMode.Disable;
        }

        private void gvProducts_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if (e.Cell.ColumnIndex == colProductName.Index)
                gvProducts.ImeMode = System.Windows.Forms.ImeMode.On;
            else
                gvProducts.ImeMode = System.Windows.Forms.ImeMode.Disable;
        }

        private void gvProducts_KeyDown(object sender, KeyEventArgs e)
        {
            var CurrCell = gvProducts.CurrentCell;
            if (e.KeyCode == Keys.Enter && CurrCell.RowIndex < gvProducts.RowCount && CurrCell.ColumnIndex <= colAmt.Index)
            {
                DataGridViewCell targetCell = null;
                if (CurrCell.ColumnIndex == colAmt.Index)
                {
                    if (CurrCell.RowIndex == gvProducts.RowCount - 1) return;
                    targetCell = gvProducts.Rows[CurrCell.RowIndex + 1].Cells[colProductNo.Index];
                }
                else
                    targetCell = gvProducts.Rows[CurrCell.RowIndex].Cells[CurrCell.ColumnIndex + 1];

                gvProducts.BeginInvoke((MethodInvoker)delegate
                {
                    targetCell.Selected = true;
                    gvProducts.CurrentCell = targetCell;
                    if (targetCell.ColumnIndex == colProductName.Index)
                        gvProducts.ImeMode = System.Windows.Forms.ImeMode.On;
                    else
                        gvProducts.ImeMode = System.Windows.Forms.ImeMode.Disable;
                });
            }

        }

        private bool _isRestart = false;
        public bool IsRestart { get { return _isRestart; } set { _isRestart = value; } }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            QuoteOrderForm fm = new QuoteOrderForm(User);
            Close();
            fm.Show();
            Dispose();
        }

        private void rbHasTax_CheckedChanged(object sender, EventArgs e)
        {
            rbNonTax.Checked = !rbHasTax.Checked;
            CalculateAmt();
            controlEdited(null, null);
        }

        private void rbNonTax_CheckedChanged(object sender, EventArgs e)
        {
            rbHasTax.Checked = !rbNonTax.Checked;
            CalculateAmt();
            controlEdited(null, null);
        }

        private void tbOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.KeyData == Keys.Enter)
            {
                using (JiuQinEntities db = new JiuQinEntities())
                {
                    var entity = db.QuoteOrderMain.FirstOrDefault(a => a.no == tb.Text.Trim());
                    if (entity == null)
                        MessageBox.Show("單號" + tb.Text.Trim() + "不存在", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        LoadOrder(new QuoteOrder(entity));
                }
            }

        }
    }
}
