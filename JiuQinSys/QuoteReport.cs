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
    public partial class QuoteReport : Form
    {
        QuoteOrder o = null;
        public QuoteReport(QuoteOrder o)
        {

            InitializeComponent();
            this.o = o;

            if (o.ProductList.Count == 12)
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "JiuQinSys.Quote9.rdlc";
            else
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "JiuQinSys.Quote12.rdlc";
        }


        private void QuoteReport_Load(object sender, EventArgs e)
        {
            //var page = new System.Drawing.Printing.PageSettings() { Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0) };
            //page.PaperSize = new System.Drawing.Printing.PaperSize("中一刀", 850, 550);
            //this.reportViewer1.SetPageSettings(page);
            //this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            //var defsize = new System.Drawing.Printing.PaperSize("中一刀", 850, 550);
            //this.reportViewer1.PrinterSettings.DefaultPageSettings.PaperSize = defsize;
            QuoteOrderBindingSource.DataSource = o.ProductList;

            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Date", o.Date.ToString("yyyy-MM-dd")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("No", o.No));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CustID", o.CustID));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CustName", o.CustName));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Phone", o.Phone));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Invoiceaddr", o.Invoiceaddr));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Contact", o.Contact));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Fax", o.Fax));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Mobile", string.IsNullOrEmpty(o.Mobile) ? " " : o.Mobile));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Tax", o.Tax.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TotalAmount", o.TotalAmount.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("User", o.User.Name));
            //this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("SubTotalAmount", o.ProductList.TotalAmount.ToString()));
            //this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Balance", o.Balance.ToString()));
            //this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("AntBalance", (o.TotalAmount - o.Balance).ToString()));
            //this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Remark", "備註：" + o.Remark));
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
