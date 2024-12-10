using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsOrder
    {
        public int order_id { get; set; }
        public DateTime order_date { get; set; }

        public int member_id { get; set; }

        public int price { get; set; }

        public string creditcard_number { get; set; }

        public string convenience_store { get; set; }

        public bool paymented { get; set; }

    }
}
