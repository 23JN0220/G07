using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class MemberTable
    {
        public DataTable GetMember()
        {
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Member";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.Fill(table);
            }
            return table;
        }

        public DataTable GetMemberbyMemberID(int member_id)
        {
            DataTable table = null;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Member WHERE member_id = @member_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@member_id", member_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt > 0)
                {
                    table = new DataTable();
                    table = dataTable;
                }
            }
            return table;
        }

        public int Delete(string member_id)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Member WHERE member_id = @member_id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@member_id", member_id);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;

        }

    }
}
