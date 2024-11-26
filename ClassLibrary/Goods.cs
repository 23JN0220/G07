using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class Goods
    {
        public int goods_code { get; set; }
        public string goods_name { get; set; }
        public int maker_id { get; set; }
        public int price { get; set; }
        public int group_code { get; set; }
        public int power_consumption { get; set; }
        public string goods_image { get; set; }
    }
}
