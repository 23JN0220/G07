using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CpuGenerationTable
    {
        public DataTable GetCPUGeneration()
        {
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM CPU_Generation";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.Fill(table);
            }
            return table;
        }

        public string GetCPUGenerationNameById(int generation_id)
        {
            string generation_name = null;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT generation_name FROM CPU_Generation WHERE generation_id = @generation_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@generation_id", generation_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    generation_name = dr[0].ToString();
                }
            }
            return generation_name;
        }

        public int GetCPUGenerationIdByName(string generation_name)
        {
            int generation_id = 0;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT generation_id FROM CPU_Generation WHERE generation_name = @generation_name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@generation_name", generation_name);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    generation_id = int.Parse(dr[0].ToString());
                }
            }
            return generation_id;
        }

        public int Insert(string generation_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO CPU_Generation(generation_name) VALUES (@generation_name)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@generation_name", generation_name);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public int Update(string generation_name, string generation_name_old)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE CPU_Generation SET generation_name = @generation_name WHERE generation_name = @generation_name_old";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@generation_name", generation_name);
                command.Parameters.AddWithValue("@generation_name_old", generation_name_old);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public int Delete(string generation_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM CPU_Generation WHERE generation_name = @generation_name";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@generation_name", generation_name);

                connection.Open();
                ret = command.ExecuteNonQuery();
            }
            return ret;
        }
    }
}
