using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using JiuQinSys.Modle;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace JiuQinSys
{
    public class JiuQinHelper
    {
        public static SqlDb DB = new SqlDb("Data Source=vmserver;Initial Catalog=JiuQin;User ID=sa;Password=missa");

        internal static void InitClassByDataRow(DataRow dr, Object o)
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

        /// <summary>
        /// 產品ID自動完成項目
        /// </summary>
        public static PIDAC pidac;

        /// <summary>
        /// 客戶ID自動完成項目
        /// </summary>
        public static CIDAC cidac;

        /// <summary>
        /// 客戶名稱自動完成項目
        /// </summary>
        public static CNameAC cname;

        /// <summary>
        /// 產品名稱自動完成項目
        /// </summary>
        public static PNameAC pname;

        public static List<ProductNameAndId> ProductList = null;

        public static void Initialization()
        {
            Task.Run(() =>
            {
                pidac = new PIDAC();
                cidac = new CIDAC();
                cname = new CNameAC();
                pname = new PNameAC();

                JiuQinEntities db = new JiuQinEntities();
                string query = string.Format(@"select RTRIM(id) id,RTRIM(name) name
from Product");
                ProductList = db.Database.SqlQuery<ProductNameAndId>(query).ToList();
            });
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern short GetKeyState(Keys key);

        internal static Staff _user = null;
        public static Staff User { get { return _user; } }
    }

    public abstract class MyAutoCompleteStringCollection : AutoCompleteStringCollection
    {
        public abstract string QuerySource { get; }

        public MyAutoCompleteStringCollection()
        {
            Reflash();
        }

        public void Reflash()
        {
            this.Clear();
            using (DataTable dt = JiuQinHelper.DB.ReadDataTable(QuerySource))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    List<string> cs = new List<string>();
                    foreach (object o in dr.ItemArray)
                    {
                        cs.Add(o.ToString());
                    }
                    this.Add(string.Join(" ; ", cs.ToArray()));
                }
            }
        }
    }

    public class PIDAC : MyAutoCompleteStringCollection
    {
        public override string QuerySource
        {
            get
            {
                return string.Format(@"select RTRIM(id) as id
from Product");
            }
        }
    }

    public class CIDAC : MyAutoCompleteStringCollection
    {
        public override string QuerySource
        {
            get
            {
                return string.Format(@"select custid,custName
from Customer");
            }
        }
    }

    public class CNameAC : MyAutoCompleteStringCollection
    {
        public override string QuerySource
        {
            get
            {
                return string.Format(@"select custName,custid
from Customer");
            }
        }
    }

    public class PNameAC : MyAutoCompleteStringCollection
    {
        public override string QuerySource
        {
            get
            {
                return string.Format(@"SELECT name
FROM Product");
            }
        }
    }

    /// <summary>
    /// 人員物件
    /// </summary>
    public class Staff
    {
        #region 欄位屬性

        byte _seq = 0;
        /// <summary>
        /// 使用者代號
        /// </summary>
        public byte Seq { get { return _seq; } }

        string _id = "";
        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
                _iniFile.IniWriteValue("User", "ID", _id);
            }
        }

        string _password = "";
        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get { return _password; } set { _password = value; } }

        string _name = "";
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string Name { get { return _name; } }

        bool _autoLogin = false;

        IniFileAccess _iniFile = null;

        byte _position = byte.MaxValue;
        /// <summary>
        /// 職位等級
        /// </summary>
        public byte Position { get { return _position; } set { _position = value; } }

        #endregion

        #region 建構子

        /// <summary>
        /// 新建登入人員
        /// </summary>
        public Staff()
        {
            _iniFile = new IniFileAccess(Application.StartupPath + "\\login.ini");
            _id = _iniFile.IniReadValue("User", "ID");
            int AutoLoginCode = -1;
            if (int.TryParse(_iniFile.IniReadValue("User", "AutoLogin"), out AutoLoginCode))
                _autoLogin = (DateTime.Now.Year * DateTime.Now.Month * DateTime.Now.Day * 1028) % 1987 ==
                    AutoLoginCode;
        }

        /// <summary>
        /// 建置人員物件
        /// </summary>
        /// <param name="Seq">人員編號</param>
        public Staff(byte Seq)
        {
            _seq = Seq;
            string query = string.Format(@"select id,password,name,position
from Users
where seq = {0}", Seq);
            using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
            {
                JiuQinHelper.InitClassByDataRow(dt.Rows[0], this);
            }
        }

        #endregion

        private void InsertLoginLog()
        {
            string query = string.Format(@"insert LoginLog ( userseq,time,islogin )
select seq,GETDATE(),1
from Users
where id='{0}'

select seq,name,position
from Users
where id='{0}'", _id);

            using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
            {
                _seq = (byte)dt.Rows[0][0];
                _name = dt.Rows[0][1].ToString();
                _position = (byte)dt.Rows[0][2];
            }

            JiuQinHelper._user = this;
        }

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
where id = '{0}'", _id);
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
where id='{0}'", _id);
            //JiuQinHelper.DB.Execute(query);
        }
    }

    /// <summary>
    /// 顧客類別
    /// </summary>
    public class Customer
    {
        # region 欄位屬性

        string _custid = "";
        /// <summary>
        /// 客戶編號
        /// </summary>
        public string CustID { get { return _custid.Trim(); } }

        byte _rank = 1;
        /// <summary>
        /// 客戶品質
        /// </summary>
        public byte Rank { get { return _rank; } set { _rank = value; } }

        string _custName = "";
        /// <summary>
        /// 客戶名稱
        /// </summary>
        public string CustName { get { return _custName; } set { _custName = value; } }

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
                    _contacts = new ContactPhoneCollection(CustID);

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
where custid = '{0}'", ID);

            int connectCount = 0;
            while (true)
            {
                try
                {
                    using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
                    {
                        InitCustomerByDataRow(dt.Rows[0]);
                    }
                    break;
                }
                catch { if (connectCount++ == 10) throw; }
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

        internal string _id = "";
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

        private bool _isDisplayNameAndDescript = false;

        public bool IsDisplayNameAndDescript { get { return _isDisplayNameAndDescript; } set { _isDisplayNameAndDescript = value; } }

        public string AssessmentItemName
        {
            get
            {
                if (IsDisplayNameAndDescript)
                    return string.Format(@"{0}
　{1}", Name, Descript.Replace("\r\n", "\r\n　"));
                return Name;
            }
        }

        #endregion

        #region 建構子

        public Product() { }

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

    public class OrderFormProduct : Product
    {
        short _count = 1;
        /// <summary>
        /// 數量
        /// </summary>
        public short Count { get { return _count; } set { _count = value; } }

        short _stock = 0;
        /// <summary>
        /// 庫存
        /// </summary>
        public short Stock { get { return _stock; } set { _stock = value; } }

        /// <summary>
        /// 金額
        /// </summary>
        public int Amt { get { return Count * Price; } }
        public OrderFormProduct() { }
        public OrderFormProduct(DataRow dr)
        {
            if (dr.Table.Columns.Contains("count")) _count = (short)dr["count"];
            if (dr.Table.Columns.Contains("stock")) _stock = (short)dr["stock"];
            for (int i = 0; i < dr.ItemArray.Count(); i++)
            {
                if (dr[i] != DBNull.Value)
                {
                    if (dr[i].GetType() == typeof(String))
                        dr[i] = dr[i].ToString().Trim();
                    FieldInfo f = this.GetType().BaseType.GetField("_" + dr.Table.Columns[i].ColumnName, BindingFlags.NonPublic | BindingFlags.Instance);
                    if (f != null)
                        f.SetValue(this, dr[i]);
                    else
                        continue;
                    //                        throw new Exception(string.Format(@"資料表格欄位「{0}」於物件「{1}」查無應對應的欄位「_{0}」",
                    //dr.Table.Columns[i].ColumnName,
                    //this.GetType().ToString()));
                }
            }
        }
    }

    public class ProductCollection : List<OrderFormProduct>
    {
        public enum Tables
        {
            QuoteOrderSub,
            AssessmentOrderSub
        }
        public ProductCollection() { }

        public ProductCollection(string No, Tables Name)
        {
            string query = string.Format(@"SELECT p.id,q.productName as name,p.brand,p.type,p.unit,q.descript,p.inventory,p.buypoint,p.buyday,q.count,q.pice price,q.isDisplayNameAndDescript,p.stock
from {0} as q
left join Product as p on q.productID=p.id
where q.no = '{1}'
order by q.orderno", Name.ToString(), No);
            using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    this.Add(new OrderFormProduct(dr));
                }
            }
        }
        public int TotalAmount { get { return this.Sum(x => x.Amt); } }

        internal void Save(string No, string TableName)
        {
            List<string> values = new List<string>();
            for (int i = 0; i < this.Count; i++)
            {
                values.Add(string.Format(@"('{0}',{1},'{2}','{3}',{4},{5},'{6}',{7})", No, i, this[i].Id, this[i].Name, this[i].Count, this[i].Price, this[i].Descript, this[i].IsDisplayNameAndDescript ? 1 : 0));
            }

            if (this.Count == 0)
                return;
            string query = string.Format(@"delete {0}
where no = '{1}'

insert {0}
values
{2}", TableName, No, string.Join(",\r\n", values.ToArray()));
            JiuQinHelper.DB.Execute(query);
        }
    }

    /// <summary>
    /// 單據基底
    /// </summary>
    public abstract class OrderBase
    {
        #region 欄位屬性

        protected string _no = "";
        /// <summary>
        /// 單據編號
        /// </summary>
        public string No { get { return _no; } }

        protected DateTime _date = DateTime.Now;
        /// <summary>
        /// 單據日期
        /// </summary>
        public DateTime Date { get { return _date; } set { _date = value; } }

        protected string _custName = string.Empty;
        /// <summary>
        /// 顧客名稱
        /// </summary>
        public string CustName { get { return _custName; } set { _custName = value; } }

        protected string _contact = string.Empty;
        /// <summary>
        /// 聯絡人
        /// </summary>
        public string Contact { get { return _contact; } set { _contact = value; } }

        protected string _invoiceaddr = "";
        /// <summary>
        /// 送貨地址
        /// </summary>
        public string Invoiceaddr { get { return _invoiceaddr; } set { _invoiceaddr = value; } }

        protected string _remark = string.Empty;
        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get { return _remark; } set { _remark = value; } }

        protected ProductCollection productList = new ProductCollection();
        /// <summary>
        /// 產品列表
        /// </summary>
        public ProductCollection ProductList { get { return productList; } set { productList = value; } }

        protected byte userSeq { get; set; }

        protected Staff _user = null;
        /// <summary>
        /// 承辦人員
        /// </summary>
        public Staff User
        {
            get
            {
                if (_user == null)
                {
                    _user = new Staff(userSeq);
                    userSeq = _user.Seq;
                }
                return _user;
            }
        }
        #endregion

        #region 建構子

        public OrderBase() { }
        /// <summary>
        /// 新增單據
        /// </summary>
        /// <param name="user">承辦人員</param>
        public OrderBase(Staff user)
        {
            _user = user;
        }

        /// <summary>
        /// 開啟單據
        /// </summary>
        /// <param name="dr">初始資料</param>
        public OrderBase(DataRow dr)
        {
            JiuQinHelper.InitClassByDataRow(dr, this);
        }

        #endregion

        /// <summary>
        /// 移除表單
        /// </summary>
        public abstract void Delete();

        /// <summary>
        /// 儲存表單
        /// </summary>
        /// <returns>回傳表單之單號(No)</returns>
        public abstract void Save();

        public string GetMaxOrderNo(MainTable Table)
        {
            byte retry = 0;
            while (true)
            {
                try
                {
                    string query = string.Format(@"SELECT MAX(no)
from {1}
where SUBSTRING(no,1,8)='{0}'", Date.ToString("yyyyMMdd"), Table.ToString());
                    using (DataTable dt = JiuQinHelper.DB.ReadDataTable(query))
                    {
                        if (string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                            return Date.ToString("yyyyMMdd") + "001";
                        else
                            return (ulong.Parse(dt.Rows[0][0].ToString()) + 1).ToString();
                    }
                }
                catch
                {
                    if (retry < 10) retry++;
                    throw;
                }
            }
        }

        public enum MainTable
        {
            AssessmentOrderMain,
            QuoteOrderMain
        }
    }

    /// <summary>
    /// 報價單物件
    /// </summary>
    public class QuoteOrder : OrderBase
    {
        #region 欄位屬性

        string _custID = string.Empty;
        /// <summary>
        /// 客戶代碼
        /// </summary>
        public string CustID { get { return _custID; } set { _custID = value; } }

        /// <summary>
        /// 總計
        /// </summary>
        public int TotalAmount { get { return ProductList.TotalAmount + (int)(Tax + (float)0.5); } }

        byte _taxRate = 0;
        /// <summary>
        /// 稅率
        /// </summary>
        public byte TaxRate { get { return _taxRate; } set { _taxRate = value; } }

        /// <summary>
        /// 稅額
        /// </summary>
        public float Tax { get { return (float)Math.Round(((float)ProductList.TotalAmount * (float)_taxRate / (float)100)); } }

        string _phone = "";
        /// <summary>
        /// 聯絡電話
        /// </summary>
        public string Phone { get { return _phone; } set { _phone = value; } }

        string _fax = "";
        /// <summary>
        /// 傳真號碼
        /// </summary>
        public string Fax { get { return _fax; } set { _fax = value; } }

        string _mobile = "";
        /// <summary>
        /// 行動電話
        /// </summary>
        public string Mobile { get { return _mobile; } set { _mobile = value; } }

        //bool _done = false;
        ///// <summary>
        ///// 是否成交
        ///// </summary>
        //public bool Deal { get { return _done; } set { _done = value; } }

        int _balance = 0;
        /// <summary>
        /// 沖帳
        /// </summary>
        public int Balance { get { return _balance; } set { _balance = value; } }
        #endregion

        public QuoteOrder() { }
        public QuoteOrder(DataRow dr)
            : base(dr)
        {

        }

        public QuoteOrder(Staff user)
            : base(user) { }

        public QuoteOrder(QuoteOrderMain Entity)
        {
            _custID = Entity.custID;
            _custName = Entity.custName;
            _contact = Entity.contact;
            _date = Entity.date.Value;
            _fax = Entity.fax;
            _mobile = Entity.mobile;
            _no = Entity.no;
            _phone = Entity.phone;
            _taxRate = Entity.taxRate.Value;
            _invoiceaddr = Entity.invoiceaddr;
            userSeq = Entity.userSeq.Value;
            _remark = Entity.remark;
            _balance = Entity.balance.Value;

            productList = new ProductCollection(_no, ProductCollection.Tables.QuoteOrderSub);
        }

        public QuoteOrder(AssessmentOrder Assessment)
        {
            Contact = Assessment.Contact;
            CustID = Assessment.CustID;
            CustName = Assessment.CustName;
            Date = Assessment.Date > DateTime.Now ? Assessment.Date : DateTime.Now;
            Fax = Assessment.Fax;
            Invoiceaddr = Assessment.Invoiceaddr;
            Mobile = Assessment.Mobile;
            Phone = Assessment.Phone;
            _user = Assessment.User;
            TaxRate = Assessment.TaxRate;

            for (byte i = 0; i < Assessment.ProductList.Count; i++)
            {
                var o = Assessment.ProductList[i];
                productList.Add(new OrderFormProduct()
                {
                    _id = o.Id,
                    Count = o.Count,
                    Name = o.Name,
                    Unit = o.Unit,
                    Price = o.Price
                });
            }
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 儲存表單
        /// </summary>
        /// <returns>回傳表單之單號(No)</returns>
        public override void Save()
        {
            if (string.IsNullOrEmpty(_no))
            {
                bool success = true;
                do
                {
                    _no = GetMaxOrderNo(MainTable.QuoteOrderMain);

                    string query = string.Format(@"insert QuoteOrderMain(no,date,custID,custName,contact,phone,fax,mobile,invoiceaddr,taxRate,remark,userSeq,balance)
values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},{12}) ",
No,//0
Date.ToString("yyyy-MM-dd"),//1
CustID,//2
CustName,//3
Contact,//4
Phone,//5
Fax,//6
Mobile,//7
Invoiceaddr,//8
TaxRate,//9
Remark,//10
User.Seq,//11
Balance//12
);
                    try
                    {
                        JiuQinHelper.DB.Execute(query);
                        success = true;
                    }
                    catch { success = false; }
                } while (!success);
            }
            else
            {
                bool success = true;
                do
                {
                    string query = string.Format(@"update QuoteOrderMain
set
date = '{0}',
custID='{1}',
custName='{2}',
contact='{3}',
phone='{4}',
fax='{5}',
mobile='{6}',
invoiceaddr='{7}',
taxRate='{8}',
remark='{9}',
userSeq={10},
balance={12}
where no = '{11}'",
Date.ToString("yyyy-MM-dd"),//0
CustID,//1
CustName,//2
Contact,//3
Phone,//4
Fax,//5
Mobile,//6
Invoiceaddr,//7
TaxRate,//8
Remark,//9
User.Seq,//10
No,//11
Balance//12
);
                    try { JiuQinHelper.DB.Execute(query); }
                    catch { success = false; }
                } while (!success);
            }
            productList.Save(No, "QuoteOrderSub");
        }

        public void StatisticStock()
        {
            string updateQuery = "";
            foreach (var i in ProductList)
            {
                updateQuery +=string.Format(@"
update ".Stock
            }

        }
    }

    public class AssessmentOrder : QuoteOrder
    {
        DateTime _effectDate = DateTime.Now.AddDays(30);
        /// <summary>
        /// 有效日期
        /// </summary>
        public DateTime EffectDate { get { return _effectDate; } set { _effectDate = value; } }

        private string _quoteno = "";
        /// <summary>
        /// 訂單編號
        /// </summary>
        public string Quoteno { get { return _quoteno; } set { _quoteno = value; } }

        public AssessmentOrder(Staff user)
            : base(user) { }

        public AssessmentOrder(AssessmentOrderMain AssessmentOrder)
        {
            CustID = AssessmentOrder.custID;
            _custName = AssessmentOrder.custName;
            _contact = AssessmentOrder.contact;
            _date = AssessmentOrder.date.Value;
            _effectDate = AssessmentOrder.effectDate.Value;
            Fax = AssessmentOrder.fax;
            Mobile = AssessmentOrder.mobile;
            _no = AssessmentOrder.no;
            Phone = AssessmentOrder.phone;
            TaxRate = AssessmentOrder.taxRate.Value;
            _invoiceaddr = AssessmentOrder.invoiceaddr;
            userSeq = AssessmentOrder.userSeq.Value;
            _quoteno = AssessmentOrder.quoteno;
            _remark = AssessmentOrder.remark;

            productList = new ProductCollection(_no, ProductCollection.Tables.AssessmentOrderSub);
        }

        public override void Save()
        {
            bool success = true;
            if (string.IsNullOrEmpty(_no))
            {
                do
                {
                    _no = GetMaxOrderNo(MainTable.AssessmentOrderMain);

                    string query = string.Format(@"insert AssessmentOrderMain(no,date,custID,custName,contact,phone,fax,mobile,invoiceaddr,taxRate,remark,userSeq,effectDate)
values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},'{12}') ",
_no,//0
Date.ToString("yyyy-MM-dd"),//1
CustID,//2
CustName,//3
Contact,//4
Phone,//5
Fax,//6
Mobile,//7
Invoiceaddr,//8
TaxRate,//9
Remark,//10
User.Seq,//11
EffectDate.ToString("yyyy-MM-dd")//12
);
                    try { JiuQinHelper.DB.Execute(query); }
                    catch { success = false; }
                } while (!success);
            }
            else
            {
                string query = "";
                query = string.Format(@"
update AssessmentOrderMain
set
date = '{0}',
custID='{1}',
custName='{2}',
contact='{3}',
phone='{4}',
fax='{5}',
mobile='{6}',
invoiceaddr='{7}',
taxRate='{8}',
remark='{9}',
userSeq={10},
effectDate='{12}'
where no = '{11}'",
Date.ToString("yyyy-MM-dd"),//0
CustID,//1
CustName,//2
Contact,//3
Phone,//4
Fax,//5
Mobile,//6
Invoiceaddr,//7
TaxRate,//8
Remark,//9
User.Seq,//10
No,//11
EffectDate.ToString("yyyy-MM-dd")//12
);
                do
                {
                    try { JiuQinHelper.DB.Execute(query); }
                    catch { success = false; }
                } while (!success);
            }
            productList.Save(No, "AssessmentOrderSub");
        }
    }

    public class PrepareOrder : QuoteOrder
    {
        public class PrepareProduct
        {
            /// <summary>
            /// 產品編號
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            /// 產品名稱
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 訂購數量
            /// </summary>
            public short Count { get; set; }

            /// <summary>
            /// 單位
            /// </summary>
            public string Unit { get; set; }

            /// <summary>
            /// 檢貨數量
            /// </summary>
            public short Available { get; set; }

            /// <summary>
            /// 檢貨單上產品順序
            /// </summary>
            public byte OrderNo { get; set; }

            /// <summary>
            /// 價格
            /// </summary>
            public int Price { get; set; }

            /// <summary>
            /// 總價
            /// </summary>
            public int Amt { get { return Count * Price; } }

            /// <summary>
            /// 敘述
            /// </summary>
            public string Descript { get; set; }

            /// <summary>
            /// 庫存
            /// </summary>
            public short Stock { get; set; }
        }

        /// <summary>
        /// 出貨日期
        /// </summary>
        public DateTime DeliverDate { get; set; }

        List<PrepareProduct> _productList = new List<PrepareProduct>();
        /// <summary>
        /// 產品列表
        /// </summary>
        new public List<PrepareProduct> ProductList { get { return _productList; } }

        /// <summary>
        /// 訂單編號
        /// </summary>
        public string QuoteNo { get; set; }

        JiuQinEntities db = new JiuQinEntities();

        public PrepareOrder(QuoteOrder q, DateTime DeliverDate)
        {
            Contact = q.Contact;
            CustID = q.CustID;
            CustName = q.CustName;
            Date = DateTime.Now;
            Fax = q.Fax;
            Invoiceaddr = q.Invoiceaddr;
            Mobile = q.Mobile;
            QuoteNo = q.No;
            Phone = q.Phone;
            _user = q.User;
            this.DeliverDate = DeliverDate;
            _remark = q.Remark;

            for (byte i = 0; i < q.ProductList.Count; i++)
            {
                var o = q.ProductList[i];
                _productList.Add(new PrepareProduct()
                {
                    OrderNo = i,
                    Id = o.Id,
                    Count = o.Count,
                    Name = o.Name,
                    Unit = o.Unit,
                    Price = o.Price,
                    Descript = o.Descript
                });
            }
        }

        public PrepareOrder() { }

        public PrepareOrder(string OrderNo)
        {
            this._no = OrderNo;
            string query = string.Format(@"select p.deliverDate,p.date,q.contact,q.custID,q.custName,q.done,q.fax,q.invoiceaddr,q.mobile,q.no QuoteNo,q.phone,q.remark,q.taxRate,q.userSeq,q.remark
from PrepareOrderMain as p
left join QuoteOrderMain as q on p.quoteNo=q.no
where p.no = '{0}'", OrderNo);
            var q = db.Database.SqlQuery<PrepareOrder>(query).First();

            Contact = q.Contact;
            CustID = q.CustID;
            CustName = q.CustName;
            Date = q.Date;
            Fax = q.Fax;
            Invoiceaddr = q.Invoiceaddr;
            Mobile = q.Mobile;
            QuoteNo = q.QuoteNo;
            Phone = q.Phone;
            _user = q.User;
            DeliverDate = q.DeliverDate;
            _remark = q.Remark;

            query = string.Format(@"SELECT p.orderno,q.pice as Price,q.descript,q.productID Id, q.productName Name, q.count Count, pr.unit, p.count Available, pr.Stock
FROM PrepareOrderSub as p
left join QuoteOrderSub as q on  q.no=p.quoteNo and q.orderno=p.orderno
left join Product pr on q.productID = pr.id 
where p.no = '{0}'", OrderNo);

            foreach (var o in db.Database.SqlQuery<PrepareProduct>(query))
            {
                _productList.Add(o);
            }
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            if (string.IsNullOrEmpty(_no))
            {
                var today = DateTime.Now.Date;
                var MaxNo = db.PrepareOrderMain.Where(a => a.date == today).Max(a => a.no);

                if (string.IsNullOrEmpty(MaxNo))
                    _no = today.ToString("yyyyMMdd") + "001";
                else
                    _no = (ulong.Parse(MaxNo) + 1).ToString();

                db.PrepareOrderMain.Add(new PrepareOrderMain()
                {
                    no = No,
                    date = DateTime.Now.Date,
                    deliverDate = DeliverDate,
                    quoteNo = QuoteNo
                });

                for (byte i = 0; i < ProductList.Count; i++)
                {
                    var o = ProductList[i];
                    db.PrepareOrderSub.Add(new PrepareOrderSub()
                    {
                        no = No,
                        quoteNo = QuoteNo,
                        orderno = i,
                        count = o.Available
                    });
                }
            }
            else
            {
                foreach (var o in db.PrepareOrderSub.Where(a => a.no == _no))
                {
                    o.count = this.ProductList.FirstOrDefault(a => a.OrderNo == o.orderno).Available;
                    db.Entry(o).State = System.Data.Entity.EntityState.Modified;
                }
            }
            db.SaveChanges();
        }

        internal void UpdateStock(string Id, short Stock)
        {
            Task.Run(() =>
            {
                var product = db.Product.FirstOrDefault(a => a.id == Id);
                db.Product.Attach(product); product.stock = Stock;
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            });
        }
    }

    public enum OrderType
    {
        /// <summary>
        /// 訂單
        /// </summary>
        Quote,
        /// <summary>
        /// 揀貨單
        /// </summary>
        Prepare,
        /// <summary>
        /// 估價單
        /// </summary>
        Assessment
    }

    public class CustForm : Form
    {
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        SortedList<int, Control> tbDictionary = new SortedList<int, Control>();
        public void SyncTextBoxEnterIndexToTabIndex()
        {
            Task.Run(() =>
            {
                var tbList = GetAll(this, typeof(TextBox)).OrderBy(a => a.TabIndex).ToArray();
                for (int i = 0; i < tbList.Count() - 1; i++)
                {
                    tbDictionary.Add(tbList[i].TabIndex, tbList[i + 1]);
                    tbList[i].KeyDown += CustomerEdit_KeyDown;
                }
            });
        }
        public virtual void CustomerEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) tbDictionary[((Control)sender).TabIndex].Focus();
        }
    }
}