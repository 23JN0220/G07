﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace ClassLibrary
{
    public class MakerTable
    {
        public DataTable GetMaker()
        {
            DataTable table = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Maker ORDER BY 2 ASC";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                adapter.Fill(table);
            }
            return table;
        }

        public int GetMakerIdByName(string maker_name)
        {
            int maker_id = 0;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT maker_id FROM Maker WHERE maker_name = @maker_name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@maker_name", maker_name);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    maker_id = int.Parse(dr[0].ToString());
                }
            }
            return maker_id;
        }

        public string GetMakerNameById(int maker_id)
        {
            string maker_name = null;

            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT maker_name FROM Maker WHERE maker_id = @maker_id";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@maker_id", maker_id);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    maker_name = dr[0].ToString();
                }
            }
            return maker_name;
        }

        public DataTable GetMakerNameByName(string maker_name)
        {
            DataTable table = null;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Maker WHERE maker_name LIKE @maker_name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@maker_name", "%" + maker_name + "%");

                int cnt = adapter.Fill(dataTable);

                if (cnt > 0)
                {
                    table = new DataTable();
                    table = dataTable;
                }
            }
            return table;
        }

        public int GetMakerMicrosoftId()
        {
            int maker_id = 0;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT maker_id FROM Maker WHERE maker_name = 'Microsoft'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    DataRow dr = dataTable.Rows[0];
                    maker_id = int.Parse(dr[0].ToString());
                }
            }
            return maker_id;
        }

        public bool IsExistMaker(string maker_name)
        {
            bool ret = false;
            DataTable dataTable = new DataTable();
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Maker WHERE maker_name = @maker_name";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@maker_name", maker_name);

                int cnt = adapter.Fill(dataTable);

                if (cnt == 1)
                {
                    ret = true;
                }
            }
            return ret;
        }

        public int Insert(Maker maker)
        {
            int cnt = 0;
            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Maker(maker_name) VALUES(@maker_name)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@maker_name", maker.maker_name);
                connection.Open();
                cnt = command.ExecuteNonQuery();
            }
            return cnt;
        }
        public int Delete(string maker_Name)
        {
            int ret = 0;

            string connectionString = Properties.Settings.Default.DBConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Maker WHERE maker_Name = @maker_Name";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@maker_Name", maker_Name);

                connection.Open();
                ret = command.ExecuteNonQuery();

            }
            return ret;

        }
       

    }
}
