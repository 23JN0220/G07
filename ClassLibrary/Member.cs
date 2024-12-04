using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Member
    {
        public int member_id { get; set; }
        public string member_name { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string password { get; set; }
        public string zip_code { get; set; }
        public string address { get; set; }
        public int credit_card { get; set; }
        public DateTime credit_date { get; set; }
    }
}
