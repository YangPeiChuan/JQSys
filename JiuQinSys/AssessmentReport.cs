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
    public partial class AssessmentReport : Form
    {
        AssessmentOrder o = null;
        public AssessmentReport(AssessmentOrder o)
        {

            InitializeComponent();
            this.o = o;
        }


        private void QuoteReport_Load(object sender, EventArgs e)
        {
            QuoteOrderBindingSource.DataSource = o.ProductList;
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CustName", o.CustName + "　台 照"));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Date", o.Date.ToString("yyyy-MM-dd")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("CustID", o.CustID));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Contact", o.Contact));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("EffectDate", o.EffectDate.ToString("yyyy-MM-dd")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Phone", o.Phone));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("User", o.User.Name));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Fax", o.Fax));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("No", o.No));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Tax", o.Tax.ToString("N2")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("TotalAmount", o.TotalAmount.ToString("N2")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("SumAmount", o.ProductList.TotalAmount.ToString("N2")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("ProductCount", o.ProductList.Sum(a => a.Count).ToString("N2")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("BigNumber", EastAsiaNumericFormatter.FormatWithCulture("L", o.TotalAmount, null, new CultureInfo("zh-TW")) + " 元整"));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Remark", "備註 :" + o.Remark));
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
