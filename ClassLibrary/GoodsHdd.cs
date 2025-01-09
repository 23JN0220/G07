using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsHdd
    {
        public int goods_code { get; set; }
        //False = 3.5インチ, True = 2.5インチ
        public bool size { get; set; }
        public int capacity { get; set; }
    }
}
