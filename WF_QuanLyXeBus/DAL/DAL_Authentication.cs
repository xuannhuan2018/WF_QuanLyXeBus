using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WF_QuanLyXeBus.DAL
{
    public class DAL_Authentication
    {
        private DAL_DBConnection conn;

        public DAL_Authentication()
        {
            conn = new DAL_DBConnection();
        }
        public bool checkLoginInforInDB(String username, String password)
        {
            String query = "SELECT COUNT(*) FROM TaiKhoan t WHERE t.TenTaiKhoan = @username and t.MatKhau = @password";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@username", SqlDbType.NVarChar);
            sqlParameters[0].Value = username;
            sqlParameters[1] = new SqlParameter("@password", SqlDbType.NVarChar);
            sqlParameters[1].Value = password;
            bool check = false;
            if(conn.executeFunctionQuery(query, sqlParameters) == 1)
            {
                check = true;
            }       
            return check;
        }

    }
}
