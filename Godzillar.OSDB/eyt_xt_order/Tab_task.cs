using Godzillar.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.DAO.eyt_xt_order
{
    public class Tab_task
    {
        public DataTable GetIsOrderId(string orderId)
        {
            string sql = "SELECT id FROM tab_task WHERE orderid = '" + orderId + "'";
            return DB.OrderDB.ExecuteDataTable(sql);
        }

        public int InsertTabTask(string taskId, string orderId)
        {
            string sql = "INSERT tab_task(taskid, orderid, cn, createtime, createuser, formid) VALUES(" + taskId + ", '" + orderId + "', '" + Constants.ExcelName + "', NOW(), " + Constants.UserId + ", " + Constants.FormId + ")";
            return DB.OrderDB.ExecuteNonQuery(sql);
        }
    }
}
