using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsSsdTable
    {
        public GoodsSsd GetGoodsSsdById(int goods_code)
        {
            GoodsSsd goodsSsd = null;
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods_SSD WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);
                int cnt = adapter.Fill(table);
                if (cnt == 1)
                {
                    goodsSsd = new GoodsSsd();
                    DataRow dr = table.Rows[0];
                    goodsSsd.goods_code = int.Parse(dr[0].ToString());
                    goodsSsd.standard_id = int.Parse(dr[1].ToString());
                    goodsSsd.connection_id = int.Parse(dr[2].ToString());
                    goodsSsd.type_id = int.Parse(dr[3].ToString());
                    goodsSsd.capacity = int.Parse(dr[4].ToString());
                }
            }
            return goodsSsd;
        }

        public int Insert(GoodsSsd goodsSsd)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Goods_SSD VALUES (@goods_code, @standard_id, @connection_id, @type_id, @capacity)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsSsd.goods_code);
                command.Parameters.AddWithValue("@standard_id", goodsSsd.standard_id);
                command.Parameters.AddWithValue("@connection_id", goodsSsd.connection_id);
                command.Parameters.AddWithValue("@type_id", goodsSsd.type_id);
                command.Parameters.AddWithValue("@capacity", goodsSsd.capacity);

                connection.Open();
                ret = command.ExecuteNonQuery();
            }
            return ret;
        }

        public int Update(GoodsSsd goodsSsd)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Goods_SSD SET " +
                             "standard_id = @standard_id, " +
                             "connection_id = @connection_id, " +
                             "type_id = @type_id, " +
                             "capacity = @capacity " +
                             "WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsSsd.goods_code);
                command.Parameters.AddWithValue("@standard_id", goodsSsd.standard_id);
                command.Parameters.AddWithValue("@connection_id", goodsSsd.connection_id);
                command.Parameters.AddWithValue("@type_id", goodsSsd.type_id);
                command.Parameters.AddWithValue("@capacity", goodsSsd.capacity);

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
                string sql = "DELETE FROM Goods_SSD WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goods_code);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public DataTable GetGoodsSsdByTypeId(int type_id)
        {
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Goods.goods_code, goods_name FROM Goods INNER JOIN Goods_SSD ON Goods.goods_code = Goods_SSD.goods_code WHERE type_id = @type_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@type_id", type_id);

                int cnt = adapter.Fill(table);

                if (cnt == 0)
                {
                    table = null;
                }
            }
            return table;
        }

        public DataTable GetGoodsSsdByStandardId(int standard_id)
        {
            DataTable table = new DataTable();

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Goods.goods_code, goods_name FROM Goods INNER JOIN Goods_SSD ON Goods.goods_code = Goods_SSD.goods_code WHERE standard_id = @standard_id";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@standard_id", standard_id);

                int cnt = adapter.Fill(table);

                if (cnt == 0)
                {
                    table = null;
                }
            }
            return table;
        }

        public DataTable GetGoodsSsdByConnectionId(int connection_id)
        {
            DataTable table = new DataTable();

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Goods.goods_code, goods_name FROM Goods INNER JOIN Goods_SSD ON Goods.goods_code = Goods_SSD.goods_code WHERE connection_id = @connection_id";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@connection_id", connection_id);

                int cnt = adapter.Fill(table);

                if (cnt == 0)
                {
                    table = null;
                }
            }
            return table;
        }
    }
}
