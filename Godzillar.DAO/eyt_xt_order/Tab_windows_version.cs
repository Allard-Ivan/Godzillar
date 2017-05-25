using Godzillar.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.DAO.eyt_xt_order
{
    public class Tab_windows_version
    {
        public DataTable SelectFormItem_Admin()
        {
            string sql = "SELECT class_cn, cn FROM tab_windows_version WHERE eyt LIKE '%" + Constants.Email + "%'";
            return DB.OrderDB.ExecuteDataTable(sql);
        }
    }
}
