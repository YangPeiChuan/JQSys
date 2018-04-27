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
    public partial class CustConfirmation : Form
    {
        public CustConfirmation(Modle.Customer cust, string contactName, string tel1, string tel2, string fax, string mobile)
        {
            InitializeComponent();

            lbTitle.Text = string.Format(@"編號「{0}」已存在，請確認此編號現有客戶內容，覆蓋現有資料？",cust.custid);
            lbCustID.Text = "編號：" + cust.custid;
            lbCustName.Text = "公司簡稱：" + cust.custName;
            lbSName.Text = "公司全稱：" + cust.sname;
            lbContactName.Text = "聯絡人：" + contactName;
            lbStaff.Text = "業務員：" + cust.staff.ToString();
            lbTel1.Text = "電話號碼1：" + tel1;
            lbTel2.Text = "電話號碼2：" + tel2;
            lbFax.Text = "傳真：" + fax;
            lbMobile.Text = "行動電話：" + mobile;
            lbEmail.Text = "電子郵件：" + cust.email;
            lbInvoiceaddr.Text = "收件地址：" + cust.invoiceaddr;
            lbPaybilladdr.Text = "帳單地址：" + cust.paybilladdr;
        }

        private DialogResult _resule = DialogResult.Cancel;
        public DialogResult Resule { get { return _resule; } }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var resule = MessageBox.Show("確定覆蓋?", "確認", MessageBoxButtons.YesNo);
            if (resule == System.Windows.Forms.DialogResult.Yes)
            {
                _resule = System.Windows.Forms.DialogResult.Yes;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
