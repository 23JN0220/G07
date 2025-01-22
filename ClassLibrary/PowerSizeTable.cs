using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class PowerSizeTable
    {
        public DataTable GetPowerSize()
        {
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Power_Size";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.Fill(table);
            }
            return table;
        }

        public string GetPowerSizeNameById(int size_id)
        {
            string size_name = null;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT size_name FROM Power_Size WHERE size_id = @size_id";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@size_id", size_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    size_name = dr[0].ToString();
                }
            }
            return size_name;
        }

        public int GetPowerSizeIdByName(string size_name)
        {
            int size_id = 0;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT size_id FROM Power_Size WHERE size_name = @size_name";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@size_name", size_name);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    size_id = int.Parse(dr[0].ToString());
                }
            }
            return size_id;
        }

        public int Insert(string size_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO  Power_Size(size_name) VALUES (@size_name)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@size_name", size_name);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public int Update(string size_name, string size_name_old)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE  Power_Size SET size_name = @size_name WHERE size_name = @size_name_old";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@size_name", size_name);
                command.Parameters.AddWithValue("@size_name_old", size_name_old);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }
        public int Delete(string series_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM CPU_Series WHERE series_name = @series_name";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@series_name", series_name);
                connection.Open();
                ret = command.ExecuteNonQuery();
            }
            return ret;
        }
    }
}
