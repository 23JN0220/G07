using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CoolerTypeTable
    {
        public DataTable GetCoolerType()
        {
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Cooler_Type";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.Fill(table);
            }
            return table;
        }

        public string GetCoolerTypeNameById(int cooler_type_id)
        {
            string cooler_type_name = null;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT cooler_type_name FROM Cooler_Type WHERE cooler_type_id = @cooler_type_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@cooler_type_id", cooler_type_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    cooler_type_name = dr[0].ToString();
                }
            }
            return cooler_type_name;
        }

        public int GetCoolerTypeIdByName(string cooler_type_name)
        {
            int cooler_type_id = 0;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT cooler_type_id FROM Cooler_Type WHERE cooler_type_name = @cooler_type_name";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@cooler_type_name", cooler_type_name);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    cooler_type_id = int.Parse(dr[0].ToString());
                }
            }
            return cooler_type_id;
        }
        public int Insert(string cooler_type_name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Cooler_Type(cooler_type_name) VALUES (@cooler_type_name)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@cooler_type_name", cooler_type_name);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public int Update(string cooler_type_name, string cooler_type_name_old)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Cooler_Type SET  cooler_type_name = @cooler_type_name WHERE  cooler_type_name = @cooler_type_name_old";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@cooler_type_name",cooler_type_name);
                command.Parameters.AddWithValue("@cooler_type_name_old",cooler_type_name_old);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }
    }
}
