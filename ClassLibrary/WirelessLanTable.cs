using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class WirelessLanTable
    {
        public DataTable GetWirelessLan()
        {
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Wireless_LAN";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.Fill(table);
            }
            return table;
        }

        public string GetWirelessLanNameById(int lan_id)
        {
            string lan_name = null;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT lan_name FROM Wireless_LAN WHERE lan_id = @lan_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@lan_id", lan_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    lan_name = dr[0].ToString();
                }
            }
            return lan_name;
        }

        public int GetWirelessLanIdByName(string lan_name)
        {
            int lan_id = 0;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT lan_id FROM Wireless_LAN WHERE lan_name = @lan_name";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@lan_name", lan_name);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    lan_id = int.Parse(dr[0].ToString());
                }
            }
            return lan_id;
        }

        public int Insert(string lan_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Wireless_LAN(lan_name) VALUES (@lan_name)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@lan_name", lan_name);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public int Update(string lan_name, string lan_name_old)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Wireless_LAN SET lan_name = @lan_name WHERE lan_name = @lan_name_old";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@lan_name", lan_name);
                command.Parameters.AddWithValue("@lan_name_old", lan_name_old);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }
    }
}
