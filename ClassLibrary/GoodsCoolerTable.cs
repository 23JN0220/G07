using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsCoolerTable
    {
        public GoodsCooler GetGoodsCoolerById(int goods_code)
        {
            GoodsCooler goodsCooler = null;
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods_Cooler WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int cnt = adapter.Fill(table);
                if (cnt == 1)
                {
                    goodsCooler = new GoodsCooler();
                    DataRow dr = table.Rows[0];

                    goodsCooler.goods_code = int.Parse(dr[0].ToString());
                    goodsCooler.cooler_type_id = int.Parse(dr[1].ToString());
                    goodsCooler.height = int.Parse(dr[2].ToString());
                }
            }

            return goodsCooler;
        }

        public int Insert(GoodsCooler goodsCooler)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Goods_Cooler VALUES(@goods_code, @cooler_type_id, @height)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsCooler.goods_code);
                command.Parameters.AddWithValue("@cooler_type_id", goodsCooler.cooler_type_id);
                command.Parameters.AddWithValue("@height", goodsCooler.height);

                connection.Open();
                ret = command.ExecuteNonQuery();
            }

            return ret;
        }

        public int Update(GoodsCooler goodsCooler)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Goods_Cooler SET cooler_type_id = @cooler_type_id, height = @height WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsCooler.goods_code);
                command.Parameters.AddWithValue("@cooler_type_id", goodsCooler.cooler_type_id);
                command.Parameters.AddWithValue("@height", goodsCooler.height);

                connection.Open();
                ret = command.ExecuteNonQuery();
            }
            return ret;
        }
    }
}
