using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsOsTable
    {
        public GoodsOs GetGoodsOSById(int goods_code)
        {
            GoodsOs goodsOs = null;
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods_OS WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int cnt = adapter.Fill(table);

                if (cnt == 1)
                {
                    goodsOs = new GoodsOs();
                    DataRow dr = table.Rows[0];

                    goodsOs.goods_code = int.Parse(dr[0].ToString());
                    goodsOs.version_id = int.Parse(dr[1].ToString());
                }
            }

            return goodsOs;
        }
    }
}
