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
        private const String CHECK_LOGIN_QUERY = "Select * from TaiKhoan t where t.TenTaiKhoan = @username and t.MatKhau = @password";
        private DAL_DBConnection conn;    

        public DAL_Authentication()
        {
            conn = new DAL_DBConnection();
        }
        public String checkLoginAndGetRoleInDB(String username, String password)
        {
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@username", SqlDbType.NVarChar);
            sqlParameters[0].Value = username;
            sqlParameters[1] = new SqlParameter("@password", SqlDbType.NVarChar);
            sqlParameters[1].Value = password;
            DataTable result = conn.executeSelectQueryWithParams(CHECK_LOGIN_QUERY, sqlParameters);
            if (result.Rows.Count != 0)
            {
                return result.Rows[0].Field<String>("ChucVu");
            }
            return null;
        }    
    }
}
