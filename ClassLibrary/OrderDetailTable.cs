using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class OrderDetailTable
    {
        public DataTable GetGoodsOrderDetailByOrderId(int order_id)
        {
            DataTable table = null;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Order_Detail WHERE order_id = @order_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@order_id", order_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt > 0)
                {
                    table = new DataTable();
                    table = dataTable;
                }
            }
            return table;
        }

        public int DeleteByOrderId(string order_id)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Order_Detail WHERE order_id = @order_id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@order_id", order_id);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }
    }
}
