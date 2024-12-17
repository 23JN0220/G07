using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace ClassLibrary
{
    public class GoodsTable
    {
        public DataTable GetGoods()
        {
            DataTable table = null;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                int cnt = adapter.Fill(dataTable);

                if (cnt > 0)
                {
                    table = new DataTable();
                    table = dataTable;
                }
            }
            return table;
        }

        public Goods GetGoodsByGoodsCode(string goods_code)
        {
            Goods goods = null;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];

                    goods = new Goods();
                    goods.goods_code = int.Parse(dr[0].ToString());
                    goods.goods_name = dr[1].ToString();
                    goods.maker_id = int.Parse(dr[2].ToString());
                    goods.price = int.Parse(dr[3].ToString());
                    goods.group_code = int.Parse(dr[4].ToString());
                    goods.power_consumption = int.Parse(dr[5].ToString());
                    goods.goods_image = dr[6].ToString();
                }
            }

            return goods;

        }


        public DataTable GetGoodsByName(string goods_name)
        {
            DataTable table = null;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods WHERE goods_name LIKE @goods_name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_name", "%" + goods_name + "%");

                int cnt = adapter.Fill(dataTable);

                if (cnt > 0)
                {
                    table = new DataTable();
                    table = dataTable;
                }
            }
            return table;

        }

        public DataTable GetGoodsByGroupCode(int group_code)
        {
            DataTable table = null;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods WHERE group_code = @group_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@group_code", group_code);

                int cnt = adapter.Fill(dataTable);

                if (cnt > 0)
                {
                    table = new DataTable();
                    table = dataTable;
                }
            }
            return table;
        }

        public DataTable GetGoodsByGroupCode_Name(int group_code, string goods_name)
        {
            DataTable table = null;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods WHERE group_code = @group_code AND goods_name LIKE @goods_name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@group_code", group_code);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_name", "%" + goods_name + "%");

                int cnt = adapter.Fill(dataTable);

                if (cnt > 0)
                {
                    table = new DataTable();
                    table = dataTable;
                }
            }
            return table;
        }

        public int Insert(Goods goods)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Goods(goods_name, maker_id, price, group_code, power_consumption) " +
                             "VALUES (@goods_name, @maker_id, @price, @group_code, @power_consumption)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_name", goods.goods_name);
                command.Parameters.AddWithValue("@maker_id", goods.maker_id);
                command.Parameters.AddWithValue("@price", goods.price);
                command.Parameters.AddWithValue("@group_code", goods.group_code);
                command.Parameters.AddWithValue("@power_consumption", goods.power_consumption);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public int Update(Goods goods)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Goods SET " +
                             "goods_name = @goods_name, " +
                             "maker_id = @maker_id, " +
                             "price = @price, " +
                             "power_consumption = @power_consumption " + 
                             "WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_name", goods.goods_name);
                command.Parameters.AddWithValue("@maker_id", goods.maker_id);
                command.Parameters.AddWithValue("@price", goods.price);
                command.Parameters.AddWithValue("@power_consumption", goods.power_consumption);
                command.Parameters.AddWithValue("@goods_code", goods.goods_code);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }


        public int UpdatePicture(Goods goods)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Goods SET goods_image = @goods_image WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_image", goods.goods_image);
                command.Parameters.AddWithValue("@goods_code", goods.goods_code);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }


        public int GetGoodsCodeByName(string goods_name)
        {
            int goods_code = 0;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT goods_code FROM Goods WHERE goods_name = @goods_name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_name", goods_name);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    goods_code = int.Parse(dr[0].ToString());
                }
            }
            return goods_code;
        }
    }
}
