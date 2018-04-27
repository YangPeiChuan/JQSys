using Microsoft.International.Formatters;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace JiuQinSys
{
    public partial class AssessmentCrystalReport : Form
    {
        public AssessmentCrystalReport(AssessmentOrder Order)
        {
            InitializeComponent();

            crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;

            Assessment r = new Assessment();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(String));
            dt.Columns.Add("AssessmentItemName", typeof(String));
            dt.Columns.Add("Count", typeof(short));
            dt.Columns.Add("Unit", typeof(String));
            dt.Columns.Add("Price", typeof(String));
            dt.Columns.Add("Amt", typeof(String));

            foreach (var o in Order.ProductList)
            {
                dt.Rows.Add(o.Id, o.AssessmentItemName, o.Count, o.Unit, o.Price.ToString("N2"), o.Amt.ToString("N2"));
            }

            r.SetDataSource(dt);

            r.SetParameterValue("CustName", Order.CustName);
            r.SetParameterValue("Date", Order.Date.ToString("yyyy-MM-dd"));
            r.SetParameterValue("CustID", Order.CustID);
            r.SetParameterValue("Phone", Order.Phone);
            r.SetParameterValue("Fax", Order.Fax);
            r.SetParameterValue("Contact", Order.Contact);
            r.SetParameterValue("No", Order.No);
            r.SetParameterValue("EffectDate", Order.EffectDate.ToString("yyyy-MM-dd"));
            r.SetParameterValue("User", Order.User.Name);
            r.SetParameterValue("BigNumber", EastAsiaNumericFormatter.FormatWithCulture("L", Order.TotalAmount, null, new CultureInfo("zh-TW")) + "元整");
            r.SetParameterValue("ProductCount", Order.ProductList.Sum(a => a.Count));
            r.SetParameterValue("SumAmount", Order.ProductList.TotalAmount.ToString("N2"));
            r.SetParameterValue("Tax", Order.Tax.ToString("N2"));
            r.SetParameterValue("TotalAmount", Order.TotalAmount.ToString("N2"));
            r.SetParameterValue("Remark", "備註：" + Order.Remark);

            crystalReportViewer1.ReportSource = r;
        }
    }
}
