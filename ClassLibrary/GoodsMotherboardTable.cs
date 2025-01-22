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

        public int Insert(GoodsMotherboard goodsMotherboard)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Goods_MotherBoard VALUES " +
                             "(@goods_code, @size, @chipset_series_id, @chipset_id, @socket_id, @pci_number, @m2ssd_standard_id, @m2ssd_number, @sata_number, @lan_standerd_id, @max_number, @standerd_id)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsMotherboard.goods_code);
                command.Parameters.AddWithValue("@size", goodsMotherboard.size);
                command.Parameters.AddWithValue("@chipset_series_id", goodsMotherboard.chipset_series_id);
                command.Parameters.AddWithValue("@chipset_id", goodsMotherboard.chipset_id);
                command.Parameters.AddWithValue("@socket_id", goodsMotherboard.socket_id);
                command.Parameters.AddWithValue("@pci_number", goodsMotherboard.pci_number);
                command.Parameters.AddWithValue("@m2ssd_standard_id", goodsMotherboard.m2ssd_standard_id);
                command.Parameters.AddWithValue("@m2ssd_number", goodsMotherboard.m2ssd_number);
                command.Parameters.AddWithValue("@sata_number", goodsMotherboard.sata_number);
                command.Parameters.AddWithValue("@lan_standerd_id", goodsMotherboard.lan_standerd_id);
                command.Parameters.AddWithValue("@max_number", goodsMotherboard.max_number);
                command.Parameters.AddWithValue("@standerd_id", goodsMotherboard.standerd_id);

                connection.Open();
                ret = command.ExecuteNonQuery();
            }

            return ret;
        }

        public int Update(GoodsMotherboard goodsMotherboard)
        {
            int ret = 0;
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Goods_MotherBoard SET " +
                             "size = @size, " +
                             "chipset_series_id = chipset_series_id, " +
                             "chipset_id = @chipset_id, " +
                             "socket_id = @socket_id, " +
                             "pci_number = @pci_number, " +
                             "m2ssd_standard_id = @m2ssd_standard_id, " +
                             "m2ssd_number = @m2ssd_number, " +
                             "sata_number = @sata_number, " +
                             "lan_standerd_id = @lan_standerd_id, " +
                             "max_number = @max_number, " +
                             "standerd_id = @standerd_id " +
                             "WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goodsMotherboard.goods_code);
                command.Parameters.AddWithValue("@size", goodsMotherboard.size);
                command.Parameters.AddWithValue("@chipset_series_id", goodsMotherboard.chipset_series_id);
                command.Parameters.AddWithValue("@chipset_id", goodsMotherboard.chipset_id);
                command.Parameters.AddWithValue("@socket_id", goodsMotherboard.socket_id);
                command.Parameters.AddWithValue("@pci_number", goodsMotherboard.pci_number);
                command.Parameters.AddWithValue("@m2ssd_standard_id", goodsMotherboard.m2ssd_standard_id);
                command.Parameters.AddWithValue("@m2ssd_number", goodsMotherboard.m2ssd_number);
                command.Parameters.AddWithValue("@sata_number", goodsMotherboard.sata_number);
                command.Parameters.AddWithValue("@lan_standerd_id", goodsMotherboard.lan_standerd_id);
                command.Parameters.AddWithValue("@max_number", goodsMotherboard.max_number);
                command.Parameters.AddWithValue("@standerd_id", goodsMotherboard.standerd_id);

                connection.Open();
                ret = command.ExecuteNonQuery();
            }
            return ret;
        }

        public int Delete(int goods_code)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Goods_MotherBoard WHERE goods_code = @goods_code";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@goods_code", goods_code);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;
        }

        public DataTable GetGoodsMotherboardByChipsetSeriesId(int chipset_series_id)
        {
            DataTable table = new DataTable();

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Goods.goods_code, goods_name FROM Goods INNER JOIN Goods_MotherBoard ON Goods.goods_code = Goods_MotherBoard.goods_code WHERE chipset_series_id = @chipset_series_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.SelectCommand.Parameters.AddWithValue("@chipset_series_id", chipset_series_id);
                int cnt = adapter.Fill(table);

                if (cnt == 0)
                {
                    table = null;
                }
            }
            return table;
        }

        public DataTable GetGoodsMotherboardBySocketId(int socket_id)
        {
            DataTable table = new DataTable();

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT Goods.goods_code, goods_name FROM Goods INNER JOIN Goods_MotherBoard ON Goods.goods_code = Goods_MotherBoard.goods_code WHERE socket_id = @socket_id";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@socket_id", socket_id);

                int cnt = adapter.Fill(table);

                if (cnt == 0)
                {
                    table = null;
                }
            }
            return table;
        }
    }
}
