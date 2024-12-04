using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class ReviewTable
    {
        public DataTable GetReview()
        {
            DataTable table = null;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Review";
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

        public int Delete(string member_id, string goods_code)
        {

            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Review WHERE member_id = @member_id AND goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@member_id", member_id);
                command.Parameters.AddWithValue("@goods_code", goods_code);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }
    }
}
