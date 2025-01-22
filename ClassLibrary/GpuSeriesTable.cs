using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GpuSeriesTable
    {
        public DataTable GetGpuSeries()
        {
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM GPU_Series";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.Fill(table);
            }
            return table;
        }

        public string GetGpuSeriesNameById(int gpu_series_id)
        {
            string gpu_series_name = null;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT gpu_series_name FROM GPU_Series WHERE gpu_series_id = @gpu_series_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@gpu_series_id", gpu_series_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    gpu_series_name = dr[0].ToString();
                }
            }
            return gpu_series_name;
        }

        public int GetGpuSeriesIdByName(string gpu_series_name)
        {
            int gpu_series_id = 0;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT gpu_series_id FROM GPU_Series WHERE gpu_series_name = @gpu_series_name";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@gpu_series_name", gpu_series_name);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    gpu_series_id = int.Parse(dr[0].ToString());
                }
            }
            return gpu_series_id;
        }

        public int Insert(string gpu_series_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO GPU_Series(gpu_series_name) VALUES (@gpu_series_name)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@gpu_series_name", gpu_series_name);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public int Update(string gpu_series_name, string gpu_series_name_old)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE GPU_Series SET gpu_series_name = @gpu_series_name　WHERE gpu_series_name = @gpu_series_name_old";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@gpu_series_name", gpu_series_name);
                command.Parameters.AddWithValue("@gpu_series_name_old", gpu_series_name_old);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public int Delete(string gpu_series_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM GPU_Series WHERE gpu_series_name = @gpu_series_name";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@gpu_series_name", gpu_series_name);
                connection.Open();

                ret = command.ExecuteNonQuery();
            }

            return ret;
        }
    }
}
