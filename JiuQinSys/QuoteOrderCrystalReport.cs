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
    public partial class QuoteOrderCrystalReport : Form
    {
        DataTable dt = new DataTable();

        ReportClass r = null;

        public QuoteOrderCrystalReport(QuoteOrder Order)
        {
            InitializeComponent();

            crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;

            dt.Columns.Add("Id", typeof(String));
            dt.Columns.Add("Name", typeof(String));
            dt.Columns.Add("Count", typeof(short));
            dt.Columns.Add("Unit", typeof(String));
            dt.Columns.Add("Price", typeof(String));
            dt.Columns.Add("Amt", typeof(String));
            dt.Columns.Add("Descript", typeof(String));

            foreach (var o in Order.ProductList)
            {
                dt.Rows.Add(o.Id, o.Name, o.Count, o.Unit, o.Price.ToString("N2"), o.Amt.ToString("N2"), o.Descript);
            }

            crystalReportViewer1.PrintMode = CrystalDecisions.Windows.Forms.PrintMode.PrintOutputController;
            if ((Order.ProductList.Count() % 12) == 0)
                r = new QuoteOrderCrystalReportDesignFont9();
            else
                r = new QuoteOrderCrystalReportDesign();
            r.PrintOptions.PrinterName = "EPSON LQ-690C ESC/P2";

            r.SetDataSource(dt);

            r.SetParameterValue("Date", DateTime.Now.ToString("yyyy/MM/dd"));
            r.SetParameterValue("No", Order.No);
            r.SetParameterValue("CustID", Order.CustID);
            r.SetParameterValue("CustName", Order.CustName);
            r.SetParameterValue("Contact", Order.Contact);
            r.SetParameterValue("Phone", Order.Phone);
            r.SetParameterValue("Fax", Order.Fax);
            r.SetParameterValue("Mobile", Order.Mobile);
            r.SetParameterValue("Invoiceaddr", Order.Invoiceaddr);
            r.SetParameterValue("Remark", "備註：" + Order.Remark);
            r.SetParameterValue("Balance", Order.Balance.ToString("N2"));
            r.SetParameterValue("Tax", Order.Tax.ToString("N2"));
            r.SetParameterValue("User", Order.User.Name);
            r.SetParameterValue("AntBalance", (Order.TotalAmount - Order.Balance).ToString("N2")); //.ToString("N2"));
            r.SetParameterValue("OrderAmt", Order.ProductList.TotalAmount.ToString("N2")); //.ToString("N2"));
            r.SetParameterValue("TotalAmount", Order.TotalAmount.ToString("N2")); //
            r.SetParameterValue("Title", "出貨憑單");

            crystalReportViewer1.ReportSource = r;
        }

        public QuoteOrderCrystalReport(QuoteOrder Order, int PartNo)
            : this(Order)
        {
            r.SetParameterValue("Title", "部分出貨憑單" + PartNo);
            r.SetParameterValue("AntBalance", "--");
            r.SetParameterValue("Balance", "--");
        }
    }
}
