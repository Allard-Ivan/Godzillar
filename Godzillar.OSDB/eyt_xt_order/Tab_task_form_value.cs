using Godzillar.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.DAO.eyt_xt_order
{
    public class Tab_task_form_value
    {
        public DataTable SelectExcelDataByFormId()
        {
            string sql = @"SELECT t.taskid, t.orderid, t.createtime, tfi.item_cn, tfv.formitemvalue
                            FROM tab_task_form_value tfv 
                            INNER JOIN tab_form_item tfi ON tfv.formitemid = tfi.id 
                            INNER JOIN tab_task t ON tfv.taskid = t.taskid
                            WHERE tfv.formid = " + Constants.FormId + " ORDER BY t.id desc";
            return DB.OrderDB.ExecuteDataTable(sql);
        }

        public int UpdateExcelData(string sql)
        {
            return DB.OrderDB.ExecuteNonQuery(sql);
        }

        public int InsertExcelValue(string taskId, string formItemId, string formItemValue)
        {
            string sql = "INSERT tab_task_form_value(taskid, formid, formitemid, formitemvalue) VALUES(" + taskId + ", " + Constants.FormId + ", " + formItemId + ", '" + formItemValue + "')";
            return DB.OrderDB.ExecuteNonQuery(sql);
        }

    }
}
