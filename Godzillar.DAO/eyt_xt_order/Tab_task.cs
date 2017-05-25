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
        public DataTable SelectOrderTaskByFormId()
        {
            string sql = "SELECT taskid, orderid, createtime FROM tab_task WHERE formid = " + Constants.FormId + " order by id";
            return DB.OrderDB.ExecuteDataTable(sql);
        }
    }
}
