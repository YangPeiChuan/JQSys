using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Data;

namespace JiuQinSys
{
    public class JiuQinHelper
    {
        public static SqlDb DB = new SqlDb("Data Source=172.18.101.202;Initial Catalog=JiuQin;User ID=sa;Password=missa");

        public static void TextBoxShowAutoComplete(TextBox tb, AutoCompleteItem type)
        {
            try
            {
                if (tb.Text.Length == 1)
                {
                    string query = "";

                    switch (type)
                    {
                        case AutoCompleteItem.CustomerName:
                            query = string.Format(@"select name,id,keyperson
from Customer
where name like '%{0}%'", tb.Text);
                            break;

                        case AutoCompleteItem.CustomerID:
                            query = string.Format(@"select id,name,keyperson
from Customer
where SUBSTRING(id,1,{0})='{1}'", tb.Text.Length, tb.Text);
                            break;

                        case AutoCompleteItem.ProductID:
                            query = string.Format(@"select RTRIM(id) as id
from Product
where SUBSTRING(id,1,{0})='{1}'", tb.Text.Length, tb.Text);
                            break;
                    }

                    using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
                    {
                        AutoCompleteStringCollection c = new AutoCompleteStringCollection();
                        if (type == AutoCompleteItem.ProductID)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                string cs = "";
                                foreach (object o in dr.ItemArray)
                                {
                                    cs += o.ToString();
                                }
                                c.Add(cs);
                            }
                        }
                        else
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                string cs = "";
                                foreach (object o in dr.ItemArray)
                                {
                                    cs += o.ToString() + ";";
                                }
                                c.Add(cs);
                            }
                        }
                        tb.AutoCompleteCustomSource = c;
                    }
                }
            }
            catch { }
        }

        public enum AutoCompleteItem
        {
            CustomerID,
            CustomerName,
            ProductID,
        }

        public static void InitClassByDataRow(DataRow dr, Object o)
        {
            for (int i = 0; i < dr.ItemArray.Count(); i++)
            {
                if (dr[i] != DBNull.Value)
                {
                    if (dr[i].GetType() == typeof(String))
                        dr[i] = dr[i].ToString().Trim();
                    FieldInfo f = o.GetType().GetField("_" + dr.Table.Columns[i].ColumnName, BindingFlags.NonPublic | BindingFlags.Instance);
                    if (f != null)
                        f.SetValue(o, dr[i]);
                    else
                        throw new Exception(string.Format(@"資料表格欄位「{0}」於物件「{1}」查無應對應的欄位「_{0}」",
dr.Table.Columns[i].ColumnName,
o.GetType().ToString()));
                }
            }
        }
    }

    public class User
    {
        string _iD = "";
        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string ID
        {
            get { return _iD; }
            set
            {
                _iD = value;
                _iniFile.IniWriteValue("User", "ID", _iD);
            }
        }

        string _password = "";
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get { return _password; } set { _password = value; } }

        string _name = "";

        public string Name { get { return _name; } }

        bool _autoLogin = false;

        IniFileAccess _iniFile = null;

        public bool Login()
        {
            if (_autoLogin)
            {
                InsertLoginLog();
                return true;
            }
            else
            {
                if (string.IsNullOrEmpty(_password))
                    return false;

                string query = string.Format(@"select name, password
from Users
where id = '{0}'", _iD);
                using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
                {
                    if (dt.Rows.Count == 1)
                    {
                        if (dt.Rows[0]["password"].ToString().Trim() == Password)
                        {
                            _iniFile.IniWriteValue("User", "AutoLogin",
                                ((DateTime.Now.Year * DateTime.Now.Month * DateTime.Now.Day * 1028) % 1987).ToString());
                            _name = dt.Rows[0]["name"].ToString().Trim();
                            InsertLoginLog();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("密碼錯誤");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("查無此帳號");
                        return false;
                    }
                }
            }
        }

        public void Logout()
        {
            string query = string.Format(@"insert LoginLog ( userseq,time,islogin )
select seq,GETDATE(),0
from Users
where id='{0}'", _iD);
            JiuQinHelper.DB.Execute(query);
        }

        private void InsertLoginLog()
        {
            string query = string.Format(@"insert LoginLog ( userseq,time,islogin )
select seq,GETDATE(),1
from Users
where id='{0}'

select name
from Users
where id='{0}'
", _iD);

            using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
            {
                _name = dt.Rows[0][0].ToString();
            }
        }

        public User()
        {
            _iniFile = new IniFileAccess(Application.StartupPath + "\\login.ini");
            _iD = _iniFile.IniReadValue("User", "ID");
            int AutoLoginCode = -1;
            if (int.TryParse(_iniFile.IniReadValue("User", "AutoLogin"), out AutoLoginCode))
                _autoLogin = (DateTime.Now.Year * DateTime.Now.Month * DateTime.Now.Day * 1028) % 1987 ==
                    AutoLoginCode;
        }
    }

    public class Customer
    {
        # region 欄位屬性

        string _id = "";
        /// <summary>
        /// 客戶編號
        /// </summary>
        public string ID { get { return _id.Trim(); } }

        byte _rank = 1;
        /// <summary>
        /// 客戶品質
        /// </summary>
        public byte Rank { get { return _rank; } set { _rank = value; } }

        string _name = "";
        /// <summary>
        /// 客戶名稱
        /// </summary>
        public string Name { get { return _name; } set { _name = value; } }

        string _sname = "";
        /// <summary>
        /// 簡名(帳單用)
        /// </summary>
        public string Sname { get { return _sname; } set { _sname = value; } }

        string _unicode = "";
        /// <summary>
        /// 統一編號
        /// </summary>
        public string Unicode { get { return _unicode; } set { _unicode = value; } }

        byte _staff = 1;
        /// <summary>
        /// 業務人員
        /// </summary>
        public byte Staff { get { return _staff; } set { _staff = value; } }

        string _invoiceaddr = "";
        /// <summary>
        /// 收件地址
        /// </summary>
        public string Invoiceaddr { get { return _invoiceaddr; } set { _invoiceaddr = value; } }

        string _paybilladdr = "";
        /// <summary>
        /// 帳單地址
        /// </summary>
        public string Paybilladdr { get { return _paybilladdr; } set { _paybilladdr = value; } }

        DateTime _modifydate = new DateTime();
        /// <summary>
        /// 最後訂貨時間
        /// </summary>
        public DateTime Modifydate { get { return _modifydate; } set { _modifydate = value; } }

        ContactPhoneCollection _contacts = null;
        /// <summary>
        /// 連絡電話集合
        /// </summary>
        public ContactPhoneCollection Contacts
        {
            get
            {
                if (_contacts == null)
                {
                    _contacts = new ContactPhoneCollection(ID);

                }
                return _contacts;
            }
        }

        #endregion

        #region 建構子

        public Customer(string ID)
        {
            string query = string.Format(@"select *
from Customer
where id = '{0}'", ID);

            using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
            {
                InitCustomerByDataRow(dt.Rows[0]);
            }
        }

        public Customer(DataRow dr)
        {
            InitCustomerByDataRow(dr);
        }

        private void InitCustomerByDataRow(DataRow dr)
        {
            JiuQinHelper.InitClassByDataRow(dr, this);
        }

        #endregion

        /// <summary>
        /// 連絡電話
        /// </summary>
        public class ContactPhone
        {
            #region 欄位屬性

            string _name = "";
            /// <summary>
            /// 聯絡人
            /// </summary>
            public string Name { get { return _name; } set { _name = value; } }

            string _number = "";
            /// <summary>
            /// 電話號碼
            /// </summary>
            public string Number { get { return _number; } set { _number = value; } }

            PhoneType _type;
            /// <summary>
            /// 類型
            /// </summary>
            public PhoneType Type
            {
                get { return _type; }
                set { _type = value; }
            }

            #endregion

            /// <summary>
            /// 通訊類別
            /// </summary>
            public enum PhoneType : byte
            {
                室內 = 1,
                行動 = 2,
                傳真 = 3,
            }

            public ContactPhone(DataRow dr)
            {
                JiuQinHelper.InitClassByDataRow(dr, this);
            }
        }

        /// <summary>
        /// 連絡電話集合
        /// </summary>
        public class ContactPhoneCollection : List<ContactPhone>
        {
            public ContactPhoneCollection(string CustomerID)
            {
                string query = string.Format(@"select name,number,type
from ContactPhone
where id = '{0}'
order by type,orderno", CustomerID);
                using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.Add(new ContactPhone(dr));
                    }
                }
            }
        }
    }

    /// <summary>
    /// 產品
    /// </summary>
    public class Product
    {
        #region 欄位屬性

        string _id = "";
        /// <summary>
        /// 編號
        /// </summary>
        public string Id { get { return _id; } }

        string _name = "";
        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get { return _name; } set { _name = value; } }

        string _brand = "";
        /// <summary>
        /// 商標
        /// </summary>
        public string Brand { get { return _brand; } set { _brand = value; } }

        string _type = "";
        /// <summary>
        /// 類別編號
        /// </summary>
        public string Type { get { return _type; } set { _type = value; } }

        string _unit = "";
        /// <summary>
        /// 單位
        /// </summary>
        public string Unit { get { return _unit; } set { _unit = value; } }

        int _price = -1;
        /// <summary>
        /// 單價
        /// </summary>
        public int Price { get { return _price; } set { _price = value; } }

        string _descript = "";
        /// <summary>
        /// 描述
        /// </summary>
        public string Descript { get { return _descript; } set { _descript = value; } }

        int _inventory = -1;
        /// <summary>
        /// 庫存
        /// </summary>
        public int Inventory { get { return _inventory; } set { _inventory = value; } }

        int _buypoint = -1;
        /// <summary>
        /// 採購點
        /// </summary>
        public int Buypoint { get { return _buypoint; } set { _buypoint = value; } }

        int _buyday = -1;
        /// <summary>
        /// 購買所需天數
        /// </summary>
        public int Buyday { get { return _buyday; } set { _buyday = value; } }

        #endregion

        #region 建構子

        public Product(string ID)
        {
            string query = string.Format(@"select *
from Product
where id = '{0}'", ID);

            using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
            {
                JiuQinHelper.InitClassByDataRow(dt.Rows[0], this);
            }
        }

        public Product(DataRow dr)
        {
            JiuQinHelper.InitClassByDataRow(dr, this);
        }

        #endregion


    }

    public class ProductCollection : List<Product>
    {

    }

    public abstract class OrderBase
    {
        string _no = "";

        public string No { get { return _no; } }

        DateTime _date = DateTime.Now;

        public DateTime Date { get { return _date; } set { _date = value; } }

        string _custName = "";

        public string CustName { get { return _custName; } set { _custName = value; } }

        string _custContact = "";

        public string CustContact { get { return _custContact; } set { _custContact = value; } }

        string _remark = "";

        public string Remark { get { return _remark; } set { _remark = value; } }

        ProductCollection productList = new ProductCollection();

        public ProductCollection ProductList { get { return productList; } }

        public OrderBase(DataRow dr)
        {
            JiuQinHelper.InitClassByDataRow(dr, this);
        }
    }


}
