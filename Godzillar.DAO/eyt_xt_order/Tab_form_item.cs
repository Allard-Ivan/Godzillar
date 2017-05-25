using Godzillar.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.DAO.eyt_xt_order
{
    public class Tab_form_item
    {
        public DataTable SelectItemByFormId()
        {
            string sql = "select id, item_cn, width from tab_form_item where formid = " + Constants.FormId + " order by id";
            return DB.OrderDB.ExecuteDataTable(sql);
        }

        public DataTable SelectValueByFormId()
        {
            string sql = "SELECT tfi.item_cn, tfv.formitemvalue, tfv.taskid, tfv.forecolor, tfv.backcolor FROM tab_task_form_value tfv RIGHT JOIN tab_form_item tfi ON tfv.formitemid = tfi.id WHERE tfv.formid = " + Constants.FormId + " ORDER BY tfv.id";
            return DB.OrderDB.ExecuteDataTable(sql);
        }
    }
}
