using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsCpu
    {
        public int goods_code { get; set; }
        public int series_id { get; set; }
        public int generation_id { get; set; }
        public int socket_id { get; set; }
        public int core { get; set; }
        public int thread { get; set; }
        public double clock { get; set; }

    }
}
