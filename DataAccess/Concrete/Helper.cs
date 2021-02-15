using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete {
    public static class Helper {

        public static int ConInt(this object param) {
            return Convert.ToInt32(param);
        }

        public static bool ConBool(this object param) {
            return Convert.ToBoolean(param);
        }

        public static DateTime ConDate(this object param) {
            return Convert.ToDateTime(param);
        }
    }
}
