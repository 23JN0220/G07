using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MemoryModuleTable
    {
        public DataTable GetMemoryModule()
        {
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Memory_Module";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.Fill(table);
            }
            return table;
        }

        public string GetMemoryModuleById(int module_id)
        {
            string module_name = null;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT module_name FROM Memory_Module WHERE module_id = @module_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@module_id", module_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    module_name = dr[0].ToString();
                }
            }
            return module_name;
        }
    }
}
