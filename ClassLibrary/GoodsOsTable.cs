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

        public int Insert(GoodsOs goodsOs)
        {
            int cnt = 0;
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Goods_OS(goods_code, version_id) VALUES(@goods_code, @version_id)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsOs.goods_code);
                command.Parameters.AddWithValue("@version_id", goodsOs.version_id);
                connection.Open();
                cnt = command.ExecuteNonQuery();
            }
            return cnt;
        }

        public int Update(GoodsOs goodsOs)
        {
            int cnt = 0;
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Goods_OS SET version_id = @version_id WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsOs.goods_code);
                command.Parameters.AddWithValue("@version_id", goodsOs.version_id);

                connection.Open();
                cnt = command.ExecuteNonQuery();
            }
            return cnt;
        }

        public int Delete(int goods_code)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Goods_OS WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goods_code);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public DataTable GetGoodsOsByVersionId(int version_id)
        {
            DataTable table = new DataTable();

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Goods.goods_code, goods_name FROM Goods INNER JOIN Goods_OS ON Goods.goods_code = Goods_OS.goods_code WHERE version_id = @version_id";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@version_id", version_id);

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
