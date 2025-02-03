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

        public DataTable GetMemberbyMemberId(int member_id)
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
                string sql1 = "DELETE FROM Cart WHERE member_id = @member_id";

                SqlCommand command1 = new SqlCommand(sql1, connection);
                command1.Parameters.AddWithValue("@member_id", member_id);
                connection.Open();
                command1.ExecuteNonQuery();

                string sql2 = "DELETE FROM Review WHERE member_id = @member_id";

                SqlCommand command2 = new SqlCommand(sql2, connection);
                command2.Parameters.AddWithValue("@member_id", member_id);
               
                command2.ExecuteNonQuery();

                string sql3 = "DELETE FROM Bookmark WHERE member_id = @member_id";

                SqlCommand command3 = new SqlCommand(sql3, connection);
                command3.Parameters.AddWithValue("@member_id", member_id);
               
                command3.ExecuteNonQuery();

                string sql4 = "DELETE FROM Composition WHERE member_id = @member_id";

                SqlCommand command4 = new SqlCommand(sql4, connection);
                command4.Parameters.AddWithValue("@member_id", member_id);
              
                command4.ExecuteNonQuery();

                string sql5 = "DELETE FROM Order_Detail WHERE order_id IN (SELECT order_id FROM Goods_Order  WHERE member_id = @member_id)";

                SqlCommand command5 = new SqlCommand(sql5, connection);
                command5.Parameters.AddWithValue("@member_id", member_id);
                
                command5.ExecuteNonQuery();

                string sql6 = "DELETE FROM Goods_Order WHERE member_id = @member_id";

                SqlCommand command6 = new SqlCommand(sql6, connection);
                command6.Parameters.AddWithValue("@member_id", member_id);
              
                command6.ExecuteNonQuery();

                string sql7 = "DELETE FROM Member WHERE member_id = @member_id";
                
                SqlCommand command7 = new SqlCommand(sql7, connection);
                command7.Parameters.AddWithValue("@member_id", member_id);
               
                ret = command7.ExecuteNonQuery();

            }
            return ret;

        }

    }
}
