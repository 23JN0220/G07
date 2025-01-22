using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsFanTable
    {
        public GoodsFan GetGoodsFanById(int goods_code)
        {
            GoodsFan goodsFan = null;
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods_Fan WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int cnt = adapter.Fill(table);

                if (cnt == 1)
                {
                    goodsFan = new GoodsFan();
                    DataRow dr = table.Rows[0];

                    goodsFan.goods_code = int.Parse(dr[0].ToString());
                    goodsFan.size_id = int.Parse(dr[1].ToString());
                    goodsFan.quantity = int.Parse(dr[2].ToString());
                }
            }
            return goodsFan;
        }

        public int Insert(GoodsFan goodsFan)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Goods_Fan VALUES (@goods_code, @size_id, @quantity)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsFan.goods_code);
                command.Parameters.AddWithValue("@size_id", goodsFan.size_id);
                command.Parameters.AddWithValue("@quantity", goodsFan.quantity);

                connection.Open();
                ret = command.ExecuteNonQuery();
            }

            return ret;
        }

        public int Update(GoodsFan goodsFan)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Goods_Fan SET size_id = @size_id, quantity = @quantity WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsFan.goods_code);
                command.Parameters.AddWithValue("@size_id", goodsFan.size_id);
                command.Parameters.AddWithValue("@quantity", goodsFan.quantity);

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
                string sql = "DELETE FROM Goods_Fan WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goods_code);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public DataTable GetGoodsFanBySizeId(int size_id)
        {
            DataTable table = new DataTable();

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Goods.goods_code, goods_name FROM Goods INNER JOIN Goods_Fan ON Goods.goods_code = Goods_Fan.goods_code WHERE size_id = @size_id";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@size_id", size_id);

                adapter.Fill(table);

                if (table.Rows.Count == 0)
                {
                    table = null;
                }
            }
            return table;
        }
    }
}
