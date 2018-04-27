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
    public partial class AccountReciableForm : Form
    {
        public AccountReciableForm()
        {
            InitializeComponent();

            tbCustID.AutoCompleteCustomSource = JiuQinHelper.cidac;
            dataGridView1.AutoGenerateColumns = false;

            DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            dStart.Value = d;
            dEnd.Value = d.AddMonths(1).AddDays(-1);
            btnQuery_Click(null, null);
        }

        private void dStart_ValueChanged(object sender, EventArgs e)
        {
            dEnd.Value = new DateTime(dStart.Value.Year, dStart.Value.Month, new DateTime(dStart.Value.Year, dStart.Value.AddMonths(1).Month, 1).AddDays(-1).Day);
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (JiuQinHelper.GetKeyState(Keys.Enter) < 0 && tbCustID.Text.Length > 10 && tbCustID.Text.Contains(';'))
                {
                    var s = tbCustID.Text;
                    tbCustID.Text = s.Split(';')[0].Trim();
                    tbCustName.Text = s.Split(';')[1].Trim();
                    btnQuery.Focus();
                }
                else tbCustName.Text = "";
            }
        }

        JiuQinEntities db = new JiuQinEntities();
        List<ARItem> ARItemList = new List<ARItem>();
        string BeforeAntiBalance, ThisTotal, Tax, ThisBalance, ThisAntiBalance, TotalAntiBalance;

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string custID = "";
            if (string.IsNullOrEmpty(tbCustID.Text.Trim()))
                custID = string.Format("WHERE custID = '{0}'", tbCustID.Text.Trim());

            string query = string.Format(@"SELECT date,M.no,SUM(S.count * S.pice) AS total,M.taxRate,M.balance
FROM QuoteOrderMain AS M
LEFT JOIN QuoteOrderSub AS S ON M.no = S.no 
{0}
GROUP BY custID,date,M.no,M.taxRate,M.balance",
string.IsNullOrEmpty(tbCustID.Text.Trim()) ? "" : string.Format("WHERE custID = '{0}'", tbCustID.Text.Trim()));
            var queryList = db.Database.SqlQuery<ARItem>(query).ToList();
            ARItemList = queryList.Where(a => a.date >= dStart.Value && a.date <= dEnd.Value).ToList();
            dataGridView1.DataSource = ARItemList;

            BeforeAntiBalance = queryList.Where(a => a.date < dStart.Value).Sum(a => a.antiBalance).ToString("N2");
            ThisTotal = ARItemList.Where(a => a.total != null).Sum(a => a.total.Value).ToString("N2");
            Tax = ARItemList.Sum(a => a.tax).ToString("N2");
            ThisBalance = ARItemList.Where(a => a.balance != null).Sum(a => a.balance.Value).ToString("N2");
            ThisAntiBalance = ARItemList.Sum(a => a.antiBalance).ToString("N2");
            TotalAntiBalance = queryList.Where(a => a.date <= dEnd.Value).Sum(a => a.antiBalance).ToString("N2");

            lbBeforeAntiBalance.Text = BeforeAntiBalance;
            lbThisTotal.Text = ThisTotal;
            lbTax.Text = Tax;
            lbThisBalance.Text = ThisBalance;
            lbThisAntiBalance.Text = ThisAntiBalance;
            lbTotalAntiBalance.Text = TotalAntiBalance;

            btnPrint.Enabled = ARItemList.Count > 0;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Customer c = null;
            if (!string.IsNullOrEmpty(tbCustID.Text.Trim())) c = new Customer(tbCustID.Text.Trim());
            var DateRange = dStart.Value.ToString("yyyy/MM/dd") + " ~ " + dEnd.Value.ToString("yyyy/MM/dd");
            using (AccountReciableCrystalReport fm = new AccountReciableCrystalReport
                (ARItemList, c, DateRange, BeforeAntiBalance, ThisTotal, Tax, ThisBalance, ThisAntiBalance, TotalAntiBalance))
            {
                fm.ShowDialog();
            }
        }
    }
}
