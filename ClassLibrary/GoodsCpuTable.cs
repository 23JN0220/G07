using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsCpuTable
    {
        public GoodsCpu GetGoodsCPUById(int goods_code)
        {
            GoodsCpu goodsCpu = null;
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods_CPU WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int cnt = adapter.Fill(table);

                if (cnt == 1)
                {
                    goodsCpu = new GoodsCpu();
                    DataRow dr = table.Rows[0];

                    goodsCpu.goods_code = int.Parse(dr[0].ToString());
                    goodsCpu.series_id = int.Parse(dr[1].ToString());
                    goodsCpu.generation_id = int.Parse(dr[2].ToString());
                    goodsCpu.socket_id = int.Parse(dr[3].ToString());
                    goodsCpu.core = int.Parse(dr[4].ToString());
                    goodsCpu.thread = int.Parse(dr[5].ToString());
                    goodsCpu.clock = double.Parse(dr[6].ToString());
                }
            }

            return goodsCpu;
        }

        public int Insert(GoodsCpu goodsCpu)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Goods_CPU VALUES (@goods_code, @series_id, @generation_id, @socket_id, @core, @thread, @clock)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsCpu.goods_code);
                command.Parameters.AddWithValue("@series_id", goodsCpu.series_id);
                command.Parameters.AddWithValue("@generation_id", goodsCpu.generation_id);
                command.Parameters.AddWithValue("@socket_id", goodsCpu.socket_id);
                command.Parameters.AddWithValue("@core", goodsCpu.core);
                command.Parameters.AddWithValue("@thread", goodsCpu.thread);
                command.Parameters.AddWithValue("@clock", goodsCpu.clock);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }
    }
}
