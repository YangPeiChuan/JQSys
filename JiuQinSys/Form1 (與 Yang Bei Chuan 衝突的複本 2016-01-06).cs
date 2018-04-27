using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace JiuQinSys
{
    public partial class Form1 : Form
    {
        User User = null;
        int gvEditRow = 0;

        DataTable dtProducts = null;

        public Form1(User User)
        {
            InitializeComponent();
            this.User = User;
            lbUserName.Text = User.Name;

            tbCustmorID.TextChanged += (control, even) => TextChange(tbCustmorID, JiuQinHelper.AutoCompleteItem.CustomerID);
            tbCustmorName.TextChanged += (control, even) => TextChange(tbCustmorID, JiuQinHelper.AutoCompleteItem.CustomerName);
        }

        private void gvProducts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (gvProducts.CurrentCell.ColumnIndex == colProductNo.Index)
            {
                TextBox tb = e.Control as TextBox;
                tb.AutoCompleteMode = AutoCompleteMode.Suggest;
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                gvEditRow = gvProducts.CurrentCell.RowIndex;

                tb.TextChanged += (control, even) => TextChange(tb, JiuQinHelper.AutoCompleteItem.ProductID);
            }
        }

        void TextChange(TextBox tb, JiuQinHelper.AutoCompleteItem type)
        {
            if (tb.Text.Length == 1)
            {
                tb.KeyDown += new KeyEventHandler(tb_KeyDown);
                JiuQinHelper.TextBoxShowAutoComplete(tb, type);
            }
        }

        void tb_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (e.KeyData == Keys.Enter && GetKeyState(Keys.Enter) < 0 && tb.Text.Length > 10)
            {
                Customer c = null;
                if (tb.Name == "tbCustmorName")
                    c = new Customer(tbCustmorName.Text.Split(';')[1]);
                else
                    c = new Customer(tbCustmorID.Text.Substring(0, tbCustmorID.Text.IndexOf(';')));
                tbCustmorID.Text = c.ID;
                tbCustmorName.Text = c.Name;
                tbCustmorAddress.Text = c.Invoiceaddr;
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(Keys key);

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            gvProducts.Refresh();

            Product p = new Product("900A");

            Customer c = new Customer("A001");
            object o = c.Contacts;
        }

        private void gvProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colProductNo.Index)
            {
                string query = string.Format(@"SELECT 1 as no,RTRIM(id) as id,RTRIM(name) as name,1 as count,RTRIM(unit) as unit,price,price as amt,RTRIM(descript) as descript
FROM JiuQin.dbo.Product
where id = '{0}'", gvProducts[colProductNo.Index, gvEditRow].Value);

                if (dtProducts == null)
                {
                    dtProducts = JiuQinHelper.DB.ReadDataTable(query);
                }
                else
                {
                    using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
                    {
                        DataRow dr = dt.Rows[0];
                        if (dtProducts.Rows.Count > gvEditRow)
                        {
                            dr["no"] = gvEditRow + 1;
                            dtProducts.Rows[gvEditRow].ItemArray = dr.ItemArray;
                        }
                        else
                        {
                            dr["no"] = dtProducts.Rows.Count + 1;
                            dtProducts.ImportRow(dr);
                        }
                    }
                }
            }
            else if (e.ColumnIndex == colCount.Index || e.ColumnIndex == colPrice.Index)
            {
                dtProducts.Rows[gvEditRow][e.ColumnIndex] = gvProducts[e.ColumnIndex, gvEditRow].Value;
                dtProducts.Rows[gvEditRow]["amt"] = (int)dtProducts.Rows[gvEditRow]["count"] * (int)dtProducts.Rows[gvEditRow]["price"];
            }
            else
                dtProducts.Rows[gvEditRow][e.ColumnIndex] = gvProducts[e.ColumnIndex, gvEditRow].Value;

            gvProducts.Rows.Clear();

            for (int r = 0; r < dtProducts.Rows.Count; r++)
            {
                gvProducts.Rows.Add(dtProducts.Rows[r].ItemArray);
                gvProducts.Rows[r].Tag = dtProducts.Rows[r][dtProducts.Columns.Count - 1].ToString();
            }
        }

        private void gvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colDel.Index)
            {
                dtProducts.Rows.RemoveAt(e.RowIndex);
                gvProducts.Rows.Clear();
                for (int r = 0; r < dtProducts.Rows.Count; r++)
                {
                    gvProducts.Rows.Add(dtProducts.Rows[r].ItemArray);
                }
            }
            else if (e.ColumnIndex == colRemark.Index)
            {
                string Memo = gvProducts.Rows[e.RowIndex].Tag.ToString();
                using (MemoForm fm = new MemoForm(string.IsNullOrEmpty(Memo) ? "" : Memo))
                {
                    fm.ShowDialog();
                }
            }
        }

        private void tbCustmorID_Leave(object sender, EventArgs e)
        {

        }
    }
}
