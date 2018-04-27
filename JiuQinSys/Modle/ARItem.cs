using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiuQinSys.Modle
{
    public class ARItem
    {
        public Nullable<DateTime> date { get; set; }
        public string no { get; set; }
        public Nullable<int> total { get; set; }
        public Nullable<byte> taxRate { get; set; }
        public Nullable<int> balance { get; set; }

        public double tax
        {
            get
            {
                if (total != null && taxRate != null)
                    return (double)total * (double)taxRate / 100;
                return 0;
            }
        }

        public int totalAmt
        {
            get
            {
                if (total != null) return (int)((double)total + tax + 0.5);
                return 0;
            }
        }

        public int antiBalance
        {
            get
            {
                if (balance != null) return totalAmt - balance.Value;
                return totalAmt;
            }
        }
    }
}
