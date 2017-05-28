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
            string sql = "select id, item_cn, width from tab_form_item where formid = " + Constants.FormId + " order by id asc";
            return DB.OrderDB.ExecuteDataTable(sql);
        }

        public int UpdateItemWidth(string id, string width)
        {
            string sql = "update tab_form_item set width=" + width + " where id=" + id;
            return DB.OrderDB.ExecuteNonQuery(sql);
        }

    }
}
