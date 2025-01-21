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

        public int Insert(GoodsGpu goodsGpu)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Goods_Gpu VALUES " +
                             "(@goods_code, @series_id, @memory_size, @cuda, @width, @interface_id, @hdmi_port, " +
                             "@dp_port, @lowpro, @max_output, @resolution_id, @auxiliary, @slot)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsGpu.goods_code);
                command.Parameters.AddWithValue("@series_id", goodsGpu.series_id);
                command.Parameters.AddWithValue("@memory_size", goodsGpu.memory_size);
                command.Parameters.AddWithValue("@cuda", goodsGpu.cuda);
                command.Parameters.AddWithValue("@width", goodsGpu.width);
                command.Parameters.AddWithValue("@interface_id", goodsGpu.interface_id);
                command.Parameters.AddWithValue("@hdmi_port", goodsGpu.hdmi_port);
                command.Parameters.AddWithValue("@dp_port", goodsGpu.dp_port);
                command.Parameters.AddWithValue("@max_output", goodsGpu.max_output);
                command.Parameters.AddWithValue("@resolution_id", goodsGpu.resolution_id);
                command.Parameters.AddWithValue("@slot", goodsGpu.slot);

                if (goodsGpu.lowpro)
                {
                    command.Parameters.AddWithValue("@lowpro", 1);
                }
                else
                {
                    command.Parameters.AddWithValue("@lowpro", 0);
                }

                if (goodsGpu.auxiliary)
                {
                    command.Parameters.AddWithValue("@auxiliary", 1);
                }
                else
                {
                    command.Parameters.AddWithValue("@auxiliary", 0);
                }


                connection.Open();
                ret = command.ExecuteNonQuery();
            }

            return ret;
        }

        public int Update(GoodsGpu goodsGpu)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Goods_Gpu SET " +
                             "series_id = @series_id, " +
                             "memory_size = @memory_size, " +
                             "cuda = @cuda, " +
                             "width = @width, " +
                             "interface_id = @interface_id, " +
                             "hdmi_port = @hdmi_port, " +
                             "dp_port = @dp_port, " +
                             "lowpro = @lowpro, " +
                             "max_output = @max_output, " +
                             "resolution_id = @resolution_id, " +
                             "auxiliary = @auxiliary, " +
                             "slot = @slot " +
                             "WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsGpu.goods_code);
                command.Parameters.AddWithValue("@series_id", goodsGpu.series_id);
                command.Parameters.AddWithValue("@memory_size", goodsGpu.memory_size);
                command.Parameters.AddWithValue("@cuda", goodsGpu.cuda);
                command.Parameters.AddWithValue("@width", goodsGpu.width);
                command.Parameters.AddWithValue("@interface_id", goodsGpu.interface_id);
                command.Parameters.AddWithValue("@hdmi_port", goodsGpu.hdmi_port);
                command.Parameters.AddWithValue("@dp_port", goodsGpu.dp_port);
                command.Parameters.AddWithValue("@max_output", goodsGpu.max_output);
                command.Parameters.AddWithValue("@resolution_id", goodsGpu.resolution_id);
                command.Parameters.AddWithValue("@slot", goodsGpu.slot);
                if (goodsGpu.lowpro)
                {
                    command.Parameters.AddWithValue("@lowpro", 1);
                }
                else
                {
                    command.Parameters.AddWithValue("@lowpro", 0);
                }

                if (goodsGpu.auxiliary)
                {
                    command.Parameters.AddWithValue("@auxiliary", 1);
                }
                else
                {
                    command.Parameters.AddWithValue("@auxiliary", 0);
                }

                connection.Open();
                ret = command.ExecuteNonQuery();
            }

            return ret;
        }

        public int Delete(int goods_code)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Goods_Gpu WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goods_code);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }
    }
}
