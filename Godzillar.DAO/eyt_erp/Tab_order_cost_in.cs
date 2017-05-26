using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.DAO.eyt_erp
{
    public class Tab_order_cost_in
    {
        public int InsertIn(string orderId)
        {
            string sql = "insert into tab_order_cost_in set orderid= '" + orderId + "'";
            return DB.ErpDB.ExecuteNonQuery(sql);
        }
    }
}
