using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsPowerTable
    {
        public GoodsPower GetGoodsPowerById(int goods_code)
        {
            GoodsPower goodsPower = null;
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods_Power WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int cnt = adapter.Fill(table);

                if (cnt == 1)
                {
                    goodsPower = new GoodsPower();
                    DataRow dr = table.Rows[0];

                    goodsPower.goods_code = int.Parse(dr[0].ToString());
                    goodsPower.size_id = int.Parse(dr[1].ToString());
                    goodsPower.power_capacity = int.Parse(dr[2].ToString());
                    goodsPower.plus = dr[3].ToString();
                    goodsPower.pciConnector = int.Parse(dr[4].ToString());
                    goodsPower.sataConnector = int.Parse(dr[5].ToString());
                }
            }
            return goodsPower;
        }

        public int Insert(GoodsPower goodsPower)
        {
            int cnt = 0;
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Goods_Power VALUES(@goods_code, @size_id, @power_capacity, @plus, @pciConnector, @sataConnector)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsPower.goods_code);
                command.Parameters.AddWithValue("@size_id", goodsPower.size_id);
                command.Parameters.AddWithValue("@power_capacity", goodsPower.power_capacity);
                command.Parameters.AddWithValue("@plus", goodsPower.plus);
                command.Parameters.AddWithValue("@pciConnector", goodsPower.pciConnector);
                command.Parameters.AddWithValue("@sataConnector", goodsPower.sataConnector);

                connection.Open();
                cnt = command.ExecuteNonQuery();
            }
            return cnt;
        }

        public int Update(GoodsPower goodsPower)
        {
            int cnt = 0;
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Goods_Power SET " +
                             "size_id = @size_id, " +
                             "power_capacity = @power_capacity, " +
                             "plus = @plus, " +
                             "pciConnector = @pciConnector, " +
                             "sataConnector = @sataConnector " +
                             "WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsPower.goods_code);
                command.Parameters.AddWithValue("@size_id", goodsPower.size_id);
                command.Parameters.AddWithValue("@power_capacity", goodsPower.power_capacity);
                command.Parameters.AddWithValue("@plus", goodsPower.plus);
                command.Parameters.AddWithValue("@pciConnector", goodsPower.pciConnector);
                command.Parameters.AddWithValue("@sataConnector", goodsPower.sataConnector);

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
                string sql = "DELETE FROM Goods_Power WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goods_code);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public DataTable GetGoodsPowerBySizeId(int size_id)
        {
            DataTable table = new DataTable();

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Goods.goods_code, goods_name FROM Goods INNER JOIN Goods_Power ON Goods.goods_code = Goods_Power.goods_code WHERE size_id = @size_id";

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
