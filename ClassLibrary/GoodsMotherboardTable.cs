using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class GoodsMotherboardTable
    {
        public GoodsMotherboard GetGoodsMotherboardById(int goods_code)
        {
            GoodsMotherboard goodsMotherBoard = null;
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Goods_MotherBoard WHERE goods_code = @goods_code";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@goods_code", goods_code);

                int cnt = adapter.Fill(table);

                if (cnt == 1)
                {
                    goodsMotherBoard = new GoodsMotherboard();
                    DataRow dr = table.Rows[0];

                    goodsMotherBoard.goods_code = int.Parse(dr[0].ToString());
                    goodsMotherBoard.size = int.Parse(dr[1].ToString());
                    goodsMotherBoard.chipset_series_id = int.Parse(dr[2].ToString());
                    goodsMotherBoard.chipset_id = int.Parse(dr[3].ToString());
                    goodsMotherBoard.socket_id = int.Parse(dr[4].ToString());
                    goodsMotherBoard.pci_number = int.Parse(dr[5].ToString());
                    goodsMotherBoard.m2ssd_standard_id = int.Parse(dr[6].ToString());
                    goodsMotherBoard.m2ssd_number = int.Parse(dr[7].ToString());
                    goodsMotherBoard.sata_number = int.Parse(dr[8].ToString());
                    goodsMotherBoard.lan_standerd_id = int.Parse(dr[9].ToString());
                    goodsMotherBoard.max_number = int.Parse(dr[10].ToString());
                    goodsMotherBoard.standerd_id = int.Parse(dr[11].ToString());

                }
            }
            return goodsMotherBoard;
        }
    }
}
