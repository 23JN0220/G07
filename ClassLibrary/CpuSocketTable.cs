using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CpuSocketTable
    {
        public DataTable GetCPUSocket()
        {
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM CPU_Socket";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.Fill(table);
            }
            return table;
        }

        public string GetCPUSocketNameById(int socket_id)
        {
            string socket_name = null;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT socket_name FROM CPU_Socket WHERE socket_id = @socket_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@socket_id", socket_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    socket_name = dr[0].ToString();
                }
            }
            return socket_name;
        }

        public int GetCPUSocketIdByName(string socket_name)
        {
            int socket_id = 0;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT socket_id FROM CPU_Socket WHERE socket_name = @socket_name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@socket_name", socket_name);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    socket_id = int.Parse(dr[0].ToString());
                }
            }
            return socket_id;
        }

        public int Insert(string socket_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO CPU_Socket(socket_name) VALUES (@socket_name)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@socket_name", socket_name);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }
        public int Update(string socket_name, string socket_name_old)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE CPU_Socket SET socket_name = @socket_name WHERE socket_name = @socket_name_old";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@socket_name", socket_name);
                command.Parameters.AddWithValue("@socket_name_old", socket_name_old);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }
    }
}
