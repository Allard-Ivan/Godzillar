using Godzillar.DAO.eyt_user;
using Godzillar.Service.User;
using Godzillar.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.Service
{
    public class UserService : IUserService
    {
        private Tab_user_xt tab_user_xt = new Tab_user_xt();

        public string ValidateUser(string username, string password)
        {
            if (username.Equals("") || password.Equals(""))
                return "用户名或密码不能为空";

            DataTable dtbl = tab_user_xt.SelectUserByUP(username, password);
            if (dtbl.Rows.Count == 0)
                return "用户名或密码错误";

            if (Convert.ToString(dtbl.Rows[0]["isclose"]) != "0")
            {
                return "此帐户已关闭";
            }
            else if (Convert.ToString(dtbl.Rows[0]["isout"]) != "0")
            {
                return "此账号已离职";
            }
            else if (Convert.ToString(dtbl.Rows[0]["activetime"]) == ("1900-01-01 00:00:00"))
            {
                return "此帐号未激活";
            }

            Constants.UserId = Convert.ToString(dtbl.Rows[0]["id"]);
            Constants.Power = Convert.ToString(dtbl.Rows[0]["power"]);
            Constants.Nickname = Convert.ToString(dtbl.Rows[0]["nickname"]);
            Constants.Email = Convert.ToString(dtbl.Rows[0]["email"]);
            return "success";
        }
    }
}
