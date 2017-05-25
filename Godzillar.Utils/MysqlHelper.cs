using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.Utils
{
    public class MysqlHelper
    {
        private readonly string ConnectStr = "";

        public MysqlHelper(string ip, string user, string password, string database)
        {
            ConnectStr = "server=" + ip + ";user id=" + user + ";password=" + password + ";database=" + database;
        }

        public int ExecuteNonQuery(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectStr))
            {
                MySqlCommand cmd = new MySqlCommand(SQLString, connection);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (Exception e)
                {
                    connection.Close();
                    throw e;
                }
            }
        }

        public DataTable ExecuteDataTable(string SqlString)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectStr))
            {
                DataSet dataSet = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter dataAdaper = new MySqlDataAdapter(SqlString, connection);
                    dataAdaper.Fill(dataSet, "dataSet");
                    return dataSet.Tables[0];
                }
                catch (MySqlException e)
                {
                    connection.Close();
                    throw new Exception(e.Message);
                }
            }
        }

    }
}
