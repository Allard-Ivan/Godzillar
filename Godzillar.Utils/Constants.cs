using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Godzillar.Utils
{
    public static class Constants
    {
        /// <summary>
        /// user_xt table user id
        /// </summary>
        public static string UserId { get; set; }

        /// <summary>
        /// user_xt table user power
        /// </summary>
        public static string Power { get; set; }

        /// <summary>
        /// user_xt table user nickname
        /// </summary>
        public static string Nickname { get; set; }


        public static string Email { get; set; }

        public static string FormId { get; set; }

        public static Dictionary<string, string> SqlDictionary = new Dictionary<string, string>();

        public static int ExcelRows { get; set; }

        public static int ExcelCols { get; set; }

        public static string ExcelName { get; set; }

        public static List<string> ItemList = new List<string>();

        public static List<string> TaskList = new List<string>();

        public static string GetTimeStamp()
        {
            TimeSpan timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(timeSpan.TotalSeconds).ToString();
        }

        

    }
}
