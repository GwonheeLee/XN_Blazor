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
}
