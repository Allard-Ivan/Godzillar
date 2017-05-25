using Godzillar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.DAO
{
    public class DB
    {
        private const string IP = "59.110.162.220";
        private const string USER = "root";
        private const string PASSWORD = "1234567890#a";

        public static MysqlHelper OrderDB = new MysqlHelper(IP, USER, PASSWORD, "eyt_xt_order");
        public static MysqlHelper UserDB = new MysqlHelper(IP, USER, PASSWORD, "eyt_user");
        public static MysqlHelper ErpDB = new MysqlHelper(IP, USER, PASSWORD, "eyt_erp");
    }
}
