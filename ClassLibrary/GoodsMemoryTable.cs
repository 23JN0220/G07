using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsMemoryTable
    {
        public GoodsMemory GetGoodsMemoryById(int goods_code)
        {
            GoodsMemory goodsMemory = null;
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods_Memory WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int cnt = adapter.Fill(table);

                if (cnt == 1)
                {
                    goodsMemory = new GoodsMemory();
                    DataRow dr = table.Rows[0];

                    goodsMemory.goods_code = int.Parse(dr[0].ToString());
                    goodsMemory.standard_id = int.Parse(dr[1].ToString());
                    goodsMemory.module_id = int.Parse(dr[2].ToString());
                    goodsMemory.capacity = int.Parse(dr[3].ToString());
                    goodsMemory.number = int.Parse(dr[4].ToString());
                    goodsMemory.ecc = bool.Parse(dr[5].ToString());
                }
            }
            return goodsMemory;
        }
    }
}
