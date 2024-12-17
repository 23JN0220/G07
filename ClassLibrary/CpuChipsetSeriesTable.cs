using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CpuChipsetSeriesTable
    {
        public List<int> GetCpuChipsetSeriesById(int goods_code)
        {
            List<int> idList = new List<int>();
            DataTable table = new DataTable();

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT chipset_id FROM CPU_ChipsetSeries WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int ret = adapter.Fill(table);

                if (ret != 0)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        idList.Add(int.Parse(dr[0].ToString()));
                    }
                }
            }
            return idList;
        }
    }
}
