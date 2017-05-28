using Godzillar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.DAO.eyt_xt_order
{
    public class Tab_task_confirm
    {
        public int InsertConfirm(string taskId)
        {
            string sql = "insert into tab_task_confirm(taskid, confirmuser, confirm) VALUES(" + taskId + ", " + Constants.UserId + ",0)";
            return DB.OrderDB.ExecuteNonQuery(sql);
        }
    }
}
