using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.DAO.eyt_user
{
    public class Tab_user_xt
    {
        public DataTable SelectUserByUP(string username, string password)
        {
            string sql = "SELECT id, isclose , isout ,DATE_FORMAT(activetime,'%Y-%m-%d %H:%i:%s') AS activetime  , qiye , id ,email , phone ,nickname, power FROM tab_user_xt WHERE `password`=MD5('" + password + "') AND (email='" + username + "' or phone='" + username + "')";
            return DB.UserDB.ExecuteDataTable(sql);
        }
    }
}
