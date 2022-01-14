using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataShared
{
    public class Item
    {
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public string Item_Type { get; set; }
        public string Item_Unit { get; set; }
        public decimal PrdQty_Per_Hour { get; set; }
        public int Cavity_qty { get; set; }
    }

    public class Bad_Good
	{
        public string Item_Code { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public int Bad_Qty { get; set; }
        public int Good_Qty { get; set; }
        public bool IsSuccess { get; set; }
	}

    public class ItemQty
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Item_Code { get; set; }
    }
}
