using CrystalDecisions.CrystalReports.Engine;
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
    public partial class PickingCrystalReport : Form
    {
        public PickingCrystalReport(PrepareOrder Order)
        {
            InitializeComponent();

            crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(String));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Count", typeof(short));
            dt.Columns.Add("Unit", typeof(String));
            dt.Columns.Add("Price", typeof(String));
            dt.Columns.Add("Descript", typeof(String));
            dt.Columns.Add("Status", typeof(String));
            dt.Columns.Add("Refill", typeof(String));


            foreach (var o in Order.ProductList)
            {
                dt.Rows.Add(o.Id, o.Name, o.Count, o.Unit, o.Price.ToString("N2"), o.Descript, "□OK □缺 數量:", "□OK □缺 數量:");
            }

            crystalReportViewer1.PrintMode = CrystalDecisions.Windows.Forms.PrintMode.PrintOutputController;

            PickingCrystalReportDesign r = new PickingCrystalReportDesign();
            r.SetDataSource(dt);

            r.SetParameterValue("Date", Order.Date.ToString("yyyy/MM/dd"));
            r.SetParameterValue("CustID", Order.CustID);
            r.SetParameterValue("CustName", Order.CustName);
            r.SetParameterValue("No", Order.No);
            r.SetParameterValue("Contact", Order.Contact);
            r.SetParameterValue("Mobile", Order.Mobile);
            r.SetParameterValue("TotalCount", Order.ProductList.Sum(a => a.Count).ToString("N0"));
            r.SetParameterValue("User", Order.User.Name);
            r.SetParameterValue("QuoteNo", Order.QuoteNo);
            r.SetParameterValue("DeliverDate", Order.DeliverDate.ToString("yyyy/MM/dd"));
            r.SetParameterValue("Phone", Order.Phone);
            r.SetParameterValue("Invoiceaddr", Order.Invoiceaddr);

            crystalReportViewer1.ReportSource = r;
        }
    }
}
