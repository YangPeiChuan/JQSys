using CrystalDecisions.CrystalReports.Engine;
using JiuQinSys.Modle;
using Microsoft.International.Formatters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiuQinSys
{
    public partial class AccountReciableCrystalReport : Form
    {
        DataTable dt = new DataTable();

        ReportClass r = new AccountReciableCrystalReportDesign();

        public AccountReciableCrystalReport(List<ARItem> ItemList, Customer Cust, string DateRange, string BeforeAntiBalance, string ThisTotal, string Tax, string ThisBalance, string ThisAntiBalance, string TotalAntiBalance)
        {
            InitializeComponent();

            crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;

            dt.Columns.Add("date", typeof(String));
            dt.Columns.Add("no", typeof(String));
            dt.Columns.Add("total", typeof(String));
            dt.Columns.Add("tax", typeof(double));
            dt.Columns.Add("totalAmt", typeof(String));
            dt.Columns.Add("balance", typeof(String));
            dt.Columns.Add("antiBalance", typeof(String));

            foreach (var o in ItemList)
            {
                dt.Rows.Add(o.date.Value.ToString("yyyy/MM/dd"), o.no, o.total.Value.ToString("N2"), o.tax, o.totalAmt.ToString("N2"), o.balance.Value.ToString("N2"), o.antiBalance.ToString("N2"));
            }

            crystalReportViewer1.PrintMode = CrystalDecisions.Windows.Forms.PrintMode.PrintOutputController;

            r.SetDataSource(dt);

            r.SetParameterValue("CustID", Cust == null ? "" : Cust.CustID);
            r.SetParameterValue("CustName", Cust == null ? "" : Cust.CustName);
            r.SetParameterValue("Phone", Cust == null ? "" : Cust.Contacts.FirstOrDefault(a => a.Type == Customer.ContactPhone.PhoneType.室內).Number);
            r.SetParameterValue("Fax", Cust == null ? "" : Cust.Contacts.FirstOrDefault(a => a.Type == Customer.ContactPhone.PhoneType.傳真).Number);
            r.SetParameterValue("Invoiceaddr", Cust == null ? "" : Cust.Invoiceaddr);
            r.SetParameterValue("DateRange", DateRange);
            r.SetParameterValue("PrintDate", DateTime.Now.ToString("yyyy/MM/dd"));
            r.SetParameterValue("BeforeAntiBalance", BeforeAntiBalance);
            r.SetParameterValue("ThisTotal", ThisTotal);
            r.SetParameterValue("Tax", Tax);
            r.SetParameterValue("ThisBalance", ThisBalance);
            r.SetParameterValue("ThisAntiBalance", ThisAntiBalance);
            r.SetParameterValue("TotalAntiBalance", TotalAntiBalance);

            crystalReportViewer1.ReportSource = r;
        }
    }
}
