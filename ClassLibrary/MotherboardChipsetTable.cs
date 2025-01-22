using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MotherboardChipsetTable
    {
        public DataTable GetMotherboardChipset()
        {
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Motherboard_Chipset";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.Fill(table);
            }
            return table;
        }

        public string GetMotherboardChipsetNameById(int chipset_id)
        {
            string chipset_name = null;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT chipset_name FROM Motherboard_Chipset WHERE chipset_id = @chipset_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@chipset_id", chipset_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    chipset_name = dr[0].ToString();
                }
            }
            return chipset_name;
        }

        public int GetMotherboardChipsetIdByName(string chipset_name)
        {
            int chipset_id = 0;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT chipset_id FROM Motherboard_Chipset WHERE chipset_name = @chipset_name";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@chipset_name", chipset_name);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    chipset_id = int.Parse(dr[0].ToString());
                }
            }
            return chipset_id;
        }

        public int Insert(string chipset_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Motherboard_Chipset(chipset_name) VALUES (@chipset_name)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@chipset_name", chipset_name);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public int Update(string chipset_name, string chipset_name_old)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Motherboard_Chipset SET chipset_name = @chipset_name WHERE chipset_name = @chipset_name_old";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@chipset_name", chipset_name);
                command.Parameters.AddWithValue("@chipset_name_old", chipset_name_old);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public int Delete(string chipset_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Motherboard_Chipset WHERE chipset_name = @chipset_name";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@chipset_name", chipset_name);

                connection.Open();
                ret = command.ExecuteNonQuery();
            }
            return ret;
        }
    }
}
