using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SsdStandardTable
    {
        public DataTable GetSsdStandard()
        {
            DataTable table = null;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM SSD_Standard";
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
    }
}
