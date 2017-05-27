using Godzillar.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.DAO.eyt_xt_order
{
    public class Tab_order
    {
        public int InsertTabOrder(string orderId, string transportId, string isOrder)
        {
            string sql = "INSERT tab_order(orderid, createuser, createtime, cn, status, transport_type_id, start_city, end_city, bg_city, is_order, acceptance_status) VALUES('" + orderId + "', " + Constants.UserId + ", NOW(), '" + orderId + "', 1, " + transportId + ", 10543, 4526, 47524," + isOrder + ", 1)";
            return DB.OrderDB.ExecuteNonQuery(sql);
        }
    }
}
