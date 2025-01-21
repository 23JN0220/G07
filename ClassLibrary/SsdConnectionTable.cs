using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class SsdConnectionTable
    {
        public DataTable GetSsdConnection()
        {
            DataTable table = null;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM SSD_Connection";
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

        public string GetSsdConnectionNameById(int standard_id)
        {
            string standard_name = null;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT standard_name FROM SSD_Connection WHERE standard_id = @standard_id";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@standard_id", standard_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    standard_name = dr[0].ToString();
                }
            }
            return standard_name;
        }

        public int GetSsdConnectionIdByName(string standard_name)
        {
            int standard_id = 0;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT standard_id FROM SSD_Connection WHERE standard_name = @standard_name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@standard_name", standard_name);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    standard_id = int.Parse(dr[0].ToString());
                }
            }
            return standard_id;
        }

        public int Insert(string standard_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO SSD_Connection(@standard_name) VALUES (@standard_name)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@standard_name", standard_name);

                connection.Open();
                ret = command.ExecuteNonQuery();
            }
            return ret;
        }

        public int Update(string standard_name, string standard_name_old)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE SSD_Type SET standard_name = @standard_name WHERE standard_name = @standard_name_old";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@standard_name", standard_name);
                command.Parameters.AddWithValue("@standard_name_old", standard_name_old);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }
    }
}
