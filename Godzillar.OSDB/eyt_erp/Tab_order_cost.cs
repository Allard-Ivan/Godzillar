using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.DAO.eyt_erp
{
    public class Tab_order_cost
    {
        public int InsertPay(string orderId)
        {
            string sql = "insert into tab_order_cost set orderid= '" + orderId + "'";
            return DB.ErpDB.ExecuteNonQuery(sql);
        }
    }
}
