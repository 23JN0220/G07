using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CpuSeriesTable
    {
        public DataTable GetCpuSeries()
        {
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM CPU_Series";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.Fill(table);
            }
            return table;
        }

        public string GetCpuSeriesNameById(int series_id)
        {
            string series_name = null;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT series_name FROM CPU_Series WHERE series_id = @series_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@series_id", series_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    series_name = dr[0].ToString();
                }
            }
            return series_name;
        }

        public int GetCpuSeriesIdByName(string series_name)
        {
            int series_id = 0;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT series_id FROM CPU_Series WHERE series_name = @series_name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@series_name", series_name);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    series_id = int.Parse(dr[0].ToString());
                }
            }
            return series_id;
        }
        public int Insert(string series_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO CPU_Series(series_name) VALUES (@series_name)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@series_name", series_name);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public bool ExistSeriesName(string series_name)
        {
            int cnt;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM CPU_Series WHERE series_name = @series_name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@series_name", series_name);

                cnt = adapter.Fill(dataTable);

                
            }
            if (cnt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public int Update(string series_name,string series_name_old)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE CPU_Series SET series_name = @series_name WHERE series_name = @series_name_old";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@series_name", series_name);
                command.Parameters.AddWithValue("@series_name_old", series_name_old);

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
