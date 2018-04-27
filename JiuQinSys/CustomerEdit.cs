using JiuQinSys.Modle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiuQinSys
{
    public partial class CustomerEdit : CustForm
    {
        Modle.Customer c = new Modle.Customer();
        Modle.Customer existCust = null;
        List<ContactPhone> ContactPhoneList = new List<ContactPhone>();
        string custIDFlag { get; set; }

        JiuQinEntities db = new JiuQinEntities();

        //ContactPhone tel1, tel2, fax, mobile;
        bool isNewCust = false, isChangePhoneNumber = false;

        public CustomerEdit(string CustID)
        {
            InitializeComponent();
            SyncTextBoxEnterIndexToTabIndex();
            tbSaveConfirm_TextChanged(null, null);
            isNewCust = string.IsNullOrEmpty(CustID);

            if (!isNewCust)
            {
                existCust = db.Customer.Where(a => a.custid == CustID).First();
                c.custid = existCust.custid;
                c.custName = existCust.custName;
                c.email = existCust.email;
                c.invoiceaddr = existCust.invoiceaddr;
                c.modifydate = existCust.modifydate;
                c.paybilladdr = existCust.paybilladdr;
                c.rank = existCust.rank;
                c.sname = existCust.sname;
                c.staff = existCust.staff;
                c.unicode = existCust.unicode;

                custIDFlag = c.custid.Trim();

                ContactPhoneList = db.ContactPhone.Where(a => a.id == c.custid).OrderBy(a => a.orderno).ToList();
                //ContactPhoneOrderNo = ContactPhoneList.Max(a => a.orderno);

                if (ContactPhoneList.Count > 0)
                {
                    tbContactName.DataBindings.Add("Text", ContactPhoneList.First(), "name");

                    var tel1 = ContactPhoneList.FirstOrDefault(a => a.type == 1);
                    if (tel1 != null)
                    {
                        tbTele1.DataBindings.Add("Text", tel1, "number");
                        var tel2 = ContactPhoneList.FirstOrDefault(a => a.type == 1 && a.orderno != tel1.orderno);
                        if (tel2 != null) tbTele2.DataBindings.Add("Text", tel2, "number");
                    }
                    var mobile = ContactPhoneList.FirstOrDefault(a => a.type == 2);
                    if (mobile != null) tbMobile.DataBindings.Add("Text", mobile, "number");
                    var fax = ContactPhoneList.FirstOrDefault(a => a.type == 3);
                    if (fax != null) tbFax.DataBindings.Add("Text", fax, "number");
                }
            }

            tbCustID.DataBindings.Add("Text", c, "custid");
            tbCustName.DataBindings.Add("Text", c, "custName");
            tbSname.DataBindings.Add("Text", c, "sname");
            tbStaffNo.DataBindings.Add("Text", c, "staff");
            tbUnicode.DataBindings.Add("Text", c, "unicode");
            tbMail.DataBindings.Add("Text", c, "email");
            tbInvoiceaddr.DataBindings.Add("Text", c, "invoiceaddr");
            tbPaybilladdr.DataBindings.Add("Text", c, "paybilladdr");

            isChangePhoneNumber = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isNewCust || !custIDFlag.Equals(c.custid.Trim()))
            {
                if (!checkIdConflict()) return;
            }

            if (!isNewCust)
            {
                if (custIDFlag.Equals(c.custid.Trim()))
                {
                    existCust.custName = c.custName;
                    existCust.email = c.email;
                    existCust.invoiceaddr = c.invoiceaddr;
                    existCust.modifydate = c.modifydate;
                    existCust.paybilladdr = c.paybilladdr;
                    existCust.rank = c.rank;
                    existCust.sname = c.sname;
                    existCust.staff = c.staff;
                    existCust.unicode = c.unicode;
                }
                else
                {
                    db.Customer.Remove(existCust);
                }
            }

            if (isNewCust || isChangePhoneNumber || !custIDFlag.Equals(c.custid.Trim())) InsertNewPhoneNumbers();

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            { }
            Task t = Task.Run(() =>
            {
                (Owner as CustomerLoad).Init();
                JiuQinHelper.cidac.Reflash();
                JiuQinHelper.cname.Reflash();
            });

            MessageBox.Show("儲存成功");
            this.Close();
            Task.WaitAll(t);
            Owner.Show();
        }

        private bool checkIdConflict()
        {
            var cust = db.Customer.FirstOrDefault(a => a.custid == c.custid);
            if (cust != null)
            {
                var ContactPhoneList = db.ContactPhone.Where(a => a.id == c.custid).OrderBy(a => a.orderno).ToList();
                string contactName = "", tel1 = "", tel2 = "", fax = "", mobile = "";
                if (ContactPhoneList.Count > 0)
                {
                    contactName = ContactPhoneList.First().name;
                    if (ContactPhoneList.FirstOrDefault(a => a.type == 1) != null)
                    {
                        var tel1Item = ContactPhoneList.FirstOrDefault(a => a.type == 1);
                        tel1 = tel1Item.number;
                        if (ContactPhoneList.FirstOrDefault(a => a.type == 1 && a.orderno != tel1Item.orderno) != null)
                            tel2 = ContactPhoneList.FirstOrDefault(a => a.type == 1 && a.orderno != tel1Item.orderno).number;
                    }
                    fax = ContactPhoneList.FirstOrDefault(a => a.type == 3).number;
                    mobile = ContactPhoneList.FirstOrDefault(a => a.type == 2).number;
                }

                DialogResult resule = System.Windows.Forms.DialogResult.No;
                using (CustConfirmation fm = new CustConfirmation(cust, contactName, tel1, tel2, fax, mobile))
                {
                    fm.ShowDialog();
                    resule = fm.Resule;
                }
                if (resule == DialogResult.Yes)
                {
                    cust.custName = c.custName;
                    cust.email = c.email;
                    cust.invoiceaddr = c.invoiceaddr;
                    cust.modifydate = c.modifydate;
                    cust.paybilladdr = c.paybilladdr;
                    cust.rank = c.rank;
                    cust.sname = c.sname;
                    cust.staff = c.staff;
                    cust.unicode = c.unicode;

                    db.ContactPhone.RemoveRange(db.ContactPhone.Where(a => a.id.Trim() == custIDFlag));
                }
                else return false;
            }
            else
            {
                db.Customer.Add(c);
            }
            return true;
        }

        private void InsertNewPhoneNumbers()
        {
            //string deleteQuery = "delete ContactPhone where id = '" + c.custid.Trim() + "'";
            //db.Database.ExecuteSqlCommand(deleteQuery);
            db.ContactPhone.RemoveRange(db.ContactPhone.Where(a => a.id == c.custid.Trim()));

            byte ContactPhoneOrderNo = 0;
            if (!string.IsNullOrEmpty(tbTele1.Text))
                db.ContactPhone.Add(new ContactPhone() { id = c.custid, name = tbContactName.Text, number = tbTele1.Text, type = 1, orderno = 0 });
            if (!string.IsNullOrEmpty(tbTele2.Text))
                db.ContactPhone.Add(new ContactPhone() { id = c.custid, name = tbContactName.Text, number = tbTele2.Text, type = 1, orderno = ++ContactPhoneOrderNo });
            if (!string.IsNullOrEmpty(tbMobile.Text))
                db.ContactPhone.Add(new ContactPhone() { id = c.custid, name = tbContactName.Text, number = tbMobile.Text, type = 2, orderno = ++ContactPhoneOrderNo });
            if (!string.IsNullOrEmpty(tbFax.Text))
                db.ContactPhone.Add(new ContactPhone() { id = c.custid, name = tbContactName.Text, number = tbFax.Text, type = 3, orderno = ++ContactPhoneOrderNo });
        }

        void updateContactPhone(string Custid, ContactPhone edited, ContactPhone newData)
        {
            if (edited != null) db.ContactPhone.Remove(edited);

            if (edited == null)
            {
                if (newData == null) return;
                edited = new ContactPhone() { id = Custid };
                db.ContactPhone.Add(edited);
            }

            edited.name = newData.name;
            edited.number = newData.number;
            edited.orderno = newData.orderno;
            edited.type = newData.type;
        }

        private void CustomerEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void phoneNumberTextChanged(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (!isChangePhoneNumber)
                {
                    var tb = sender as TextBox;
                    ContactPhone cp = null;
                    switch (tb.Name)
                    {
                        case "tbTele1":
                            cp = ContactPhoneList.FirstOrDefault(a => a.type == 1);
                            break;
                        case "tbTele2":
                            var telList = ContactPhoneList.Where(a => a.type == 1).ToList();
                            if (telList.Count > 1) cp = telList[1];
                            break;
                        case "tbMobile":
                            cp = ContactPhoneList.FirstOrDefault(a => a.type == 2);
                            break;
                        case "tbFax":
                            cp = ContactPhoneList.FirstOrDefault(a => a.type == 3);
                            break;
                    }
                    if (cp == null)
                        isChangePhoneNumber = !string.IsNullOrEmpty(tb.Text);
                    else
                        isChangePhoneNumber = !tb.Text.Equals(cp.number);
                }
            });
        }

        private void tbPaybilladdr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) btnSave.Focus();
        }

        private void tbSaveConfirm_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !string.IsNullOrEmpty(tbCustID.Text) && !string.IsNullOrEmpty(tbCustName.Text) && !string.IsNullOrEmpty(tbSname.Text);
        }
    }
}
