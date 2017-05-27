using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.Service.User
{
    public interface IUserService
    {
        /// <summary>
        /// 验证登录用户
        /// </summary>
        /// <returns></returns>
        string ValidateUser(string username, string password);
    }
}
