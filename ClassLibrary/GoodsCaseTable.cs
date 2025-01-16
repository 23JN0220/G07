using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsCaseTable
    {
        public GoodsCase GetGoodsCaseById(int goods_code)
        {
            GoodsCase goodsCase = null;
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods_Case WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int cnt = adapter.Fill(table);
                if (cnt == 1)
                {
                    goodsCase = new GoodsCase();
                    DataRow dr = table.Rows[0];

                    goodsCase.goods_code = int.Parse(dr[0].ToString());
                    goodsCase.bay_number = int.Parse(dr[1].ToString());
                    goodsCase.shadowbay3_number = int.Parse(dr[2].ToString());
                    goodsCase.shadowbay2_number = int.Parse(dr[3].ToString());
                    goodsCase.gpu_size = int.Parse(dr[4].ToString());
                    goodsCase.fan_size_id = int.Parse(dr[5].ToString());
                    goodsCase.fan_number = int.Parse(dr[6].ToString());
                    goodsCase.slot_number = int.Parse(dr[7].ToString());
                    goodsCase.power_size_id = int.Parse(dr[8].ToString());
                    goodsCase.width = int.Parse(dr[9].ToString());
                    goodsCase.Depth = int.Parse(dr[10].ToString());
                    goodsCase.height = int.Parse(dr[11].ToString());
                    goodsCase.color = dr[12].ToString();
                    goodsCase.lowpro = bool.Parse(dr[13].ToString());
                    goodsCase.water_cooling = bool.Parse(dr[14].ToString());
                }
            }

            return goodsCase;
        }
        public int Insert(GoodsCase goodsCase)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Goods_Case VALUES(@goods_code, @bay_number, @shadowbay3_number,@shadowbay2_number,@gpu_size,@fan_size_id,@fan_number,@slot_number,@power_size_id,@width,@Depth,@height,@color,@lowpro,@water_cooling)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsCase.goods_code);
                command.Parameters.AddWithValue("@bay_number", goodsCase.bay_number);

                connection.Open();
                ret = command.ExecuteNonQuery();
            }

            return ret;
        }
    }
}
