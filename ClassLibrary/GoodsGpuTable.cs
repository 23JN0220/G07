using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsGpuTable
    {
        public GoodsGpu GetGoodsGpuById(int goods_code)
        {
            GoodsGpu goodsGpu = null;
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods_GPU WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int cnt = adapter.Fill(table);

                if (cnt == 1)
                {
                    goodsGpu = new GoodsGpu();
                    DataRow dr = table.Rows[0];

                    goodsGpu.goods_code = int.Parse(dr[0].ToString());
                    goodsGpu.series_id = int.Parse(dr[1].ToString());
                    goodsGpu.memory_size = int.Parse(dr[2].ToString());
                    goodsGpu.cuda = int.Parse(dr[3].ToString());
                    goodsGpu.width = int.Parse(dr[4].ToString());
                    goodsGpu.interface_id = int.Parse(dr[5].ToString());
                    goodsGpu.hdmi_port = int.Parse(dr[6].ToString());
                    goodsGpu.dp_port = int.Parse(dr[7].ToString());
                    goodsGpu.lowpro = bool.Parse(dr[8].ToString());
                    goodsGpu.max_output = int.Parse(dr[9].ToString());
                    goodsGpu.resolution_id = int.Parse(dr[10].ToString());
                    goodsGpu.auxiliary = bool.Parse(dr[11].ToString());
                    goodsGpu.slot = int.Parse(dr[12].ToString());
                }
            }
            return goodsGpu;
        }
    }
}
