using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsCase
    {
        public int goods_code { get; set; }
        public int bay_number { get; set; }
        public int shadowbay3_number { get; set; }
        public int shadowbay2_number { get; set; }
        public int gpu_size { get; set; }
        public int fan_size_id {  get; set; }
        public int fan_number { get; set; }
        public int slot_number { get; set; }
        public int power_size_id { get; set; }
        public int width {  get; set; }
        public int Depth { get; set; }
        public int height { get; set; }
        public string  color { get; set; }
        public int lowpro {  get; set; }
        public int water_cooling { get; set; }

    }
}
