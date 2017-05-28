using Godzillar.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.DAO.eyt_xt_order
{
    public class Tab_dic_transport_type
    {
        public DataTable SelectTransport()
        {
            string sql = "SELECT id FROM tab_dic_transport_type WHERE name = '" + Constants.ExcelName + "'";
            return DB.OrderDB.ExecuteDataTable(sql);
        }
    }
}
