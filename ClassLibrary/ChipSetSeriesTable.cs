using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ChipSetSeriesTable
    {

        public DataTable GetChipsetSeries()
        {
            DataTable table = null;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM ChipsetSeries";
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

        public int GetChipSetIdByName(string series_name)
        {
            int series_id = 0;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT series_id FROM ChipsetSeries WHERE series_name = @series_name";
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

        public string GetChipSetNameById(int series_id)
        {
            string series_name = null;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT series_name FROM ChipsetSeries WHERE series_id = @series_id";

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
        public int Insert(string series_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO ChipsetSeries(series_name) VALUES (@series_name)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@series_name", series_name);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }
      
        public int Update(string series_name, string series_name_old)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE ChipsetSeries SET series_name = @series_name WHERE series_name = @series_name_old";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@series_name", series_name);
                command.Parameters.AddWithValue("@series_name_old", series_name_old);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }
    }
}
