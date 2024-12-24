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
    }
}
