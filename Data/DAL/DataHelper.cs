using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace QuanlySinhVienApp.Data.DAL
{
    public class DataHelper
    {
        private MySqlConnection con;
        private string connectionString;

        public DataHelper()
        {
            this.connectionString = "server=127.0.0.1;Database=qlsv;user id=root;password=24110912;Port=3306;Charset=utf8;";
            con = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public int ExecuteNonQuery(string sql)
        {
            try
            {
                OpenConnection();
                using (MySqlCommand command = new MySqlCommand(sql, con))
                {
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi lệnh SQL: " + ex.Message, ex);
            }
            finally
            {
                CloseConnection();
            }
        }

        public int ExcuteNonQuery(string sql) => ExecuteNonQuery(sql);
        public int ExcuteQuery(string sql) => ExecuteNonQuery(sql);

        public MySqlDataReader ExcuteReader(string sqlSelect)
        {
            try
            {
                OpenConnection();
                MySqlCommand command = new MySqlCommand(sqlSelect, con);
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw new Exception("Lỗi đọc dữ liệu: " + ex.Message, ex);
            }
        }

        public MySqlDataReader ExecuteReader(string sqlSelect) => ExcuteReader(sqlSelect);

        public DataTable GetDataTable(string sqlSelect)
        {
            try
            {
                OpenConnection();
                using (MySqlDataAdapter da = new MySqlDataAdapter(sqlSelect, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy vấn dữ liệu vào DataTable: " + ex.Message, ex);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
