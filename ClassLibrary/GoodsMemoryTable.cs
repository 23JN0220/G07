using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsMemoryTable
    {
        public GoodsMemory GetGoodsMemoryById(int goods_code)
        {
            GoodsMemory goodsMemory = null;
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods_Memory WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int cnt = adapter.Fill(table);

                if (cnt == 1)
                {
                    goodsMemory = new GoodsMemory();
                    DataRow dr = table.Rows[0];

                    goodsMemory.goods_code = int.Parse(dr[0].ToString());
                    goodsMemory.standard_id = int.Parse(dr[1].ToString());
                    goodsMemory.module_id = int.Parse(dr[2].ToString());
                    goodsMemory.capacity = int.Parse(dr[3].ToString());
                    goodsMemory.number = int.Parse(dr[4].ToString());
                    goodsMemory.ecc = bool.Parse(dr[5].ToString());
                }
            }
            return goodsMemory;
        }

        public int Insert(GoodsMemory goodsMemory)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Goods_Memory VALUES (@goods_code, @standard_id, @module_id, @capacity, @number, @ecc)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsMemory.goods_code);
                command.Parameters.AddWithValue("@standard_id", goodsMemory.standard_id);
                command.Parameters.AddWithValue("@module_id", goodsMemory.module_id);
                command.Parameters.AddWithValue("@capacity", goodsMemory.capacity);
                command.Parameters.AddWithValue("@number", goodsMemory.number);
                if (goodsMemory.ecc)
                {
                    command.Parameters.AddWithValue("@ecc", 1);
                }
                else
                {
                    command.Parameters.AddWithValue("@ecc", 0);
                }

                connection.Open();
                ret = command.ExecuteNonQuery();
            }

            return ret;
        }

        public int Update(GoodsMemory goodsMemory)
        {
            int ret = 0;
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Goods_Memory SET " +
                             "standard_id = @standard_id, " +
                             "module_id = @module_id, " +
                             "capacity = @capacity, " +
                             "number = @number, " +
                             "ecc = @ecc " +
                             "WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsMemory.goods_code);
                command.Parameters.AddWithValue("@standard_id", goodsMemory.standard_id);
                command.Parameters.AddWithValue("@module_id", goodsMemory.module_id);
                command.Parameters.AddWithValue("@capacity", goodsMemory.capacity);
                command.Parameters.AddWithValue("@number", goodsMemory.number);
                if (goodsMemory.ecc)
                {
                    command.Parameters.AddWithValue("@ecc", 1);
                }
                else
                {
                    command.Parameters.AddWithValue("@ecc", 0);
                }

                connection.Open();
                ret = command.ExecuteNonQuery();
            }
            return ret;
        }
    }
}
