using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsHddTable
    {
        public GoodsHdd GetGoodsHddById(int goods_code)
        {
            GoodsHdd goodsHdd = null;
            DataTable table = new DataTable();

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods_Hdd WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int cnt = adapter.Fill(table);

                if (cnt == 1)
                {
                    goodsHdd = new GoodsHdd();
                    DataRow dr = table.Rows[0];

                    goodsHdd.goods_code = int.Parse(dr[0].ToString());
                    goodsHdd.capacity = int.Parse(dr[2].ToString());
                    if (dr[1].ToString() == "1")
                    {
                        goodsHdd.size = true;
                    }
                    else
                    {
                        goodsHdd.size = false;
                    }
                }
            }
            return goodsHdd;
        }
    }
}
