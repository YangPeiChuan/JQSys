using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuQinSys.Modle
{
    public class LoadOrderModel
    {
        public string no { get; set; }
        public DateTime date { get; set; }
        public string custName { get; set; }
        public string contact { get; set; }

        public LoadOrderModel() { }
        public LoadOrderModel(DataRow dr)
        {
            no = dr["no"].ToString();
            date = (DateTime)dr["date"];
            custName = dr["custName"].ToString();
            contact = dr["contact"].ToString();
        }
    }
    public class LoadAssessment : LoadOrderModel
    {
        public string status
        {
            get
            {
                if (string.IsNullOrEmpty(quoteno)) return "--未轉單--";
                else return quoteno;
            }
        }
        public string quoteno { get; set; }
        public LoadAssessment() { }
        public LoadAssessment(DataRow dr)
            : base(dr)
        {
            quoteno = dr["quoteno"].ToString();
        }
    }
    public class LoadPrepare : LoadOrderModel
    {
        public int WaitTypeCount { get; set; }

        public DateTime DeliverDate { get; set; }
        public string Status
        {
            get
            {
                if (Done) return "--已出貨--";
                else return WaitTypeCount == 0 ? "可出貨" : string.Format("尚缺{0}種貨物", WaitTypeCount);
            }
        }

        public bool Done { get; set; }

        public LoadPrepare() : base() { }
        public LoadPrepare(DataRow dr)
            : base(dr)
        {
            Done = (bool)dr["done"];
            DeliverDate = (DateTime)dr["deliverDate"];
        }
    }
    public class LoadQuote : LoadOrderModel
    {
        public string prepareOrderNo { get; set; }
        public LoadQuote() { }
        public LoadQuote(DataRow dr)
            : base(dr)
        {
            prepareOrderNo = dr["prepareOrderNo"].ToString();
        }
    }
    public class LoadPrepareStatus
    {
        public string No { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public short QCount { get; set; }
        public short PCount { get; set; }
        public short Stock { get; set; }
    }

    public class LoadPrepareItem
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public short Count { get; set; }
        public short Stock { get; set; }
    }

    public class PrepareItem
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
