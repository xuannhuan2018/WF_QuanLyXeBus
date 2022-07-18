using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_QuanLyXeBus.DAL;
using System.Data;
using System.Data.SqlClient;
using WF_QuanLyXeBus.DTO;

namespace WF_QuanLyXeBus.DAL
{
    class DAL_QLNhanVien
    {
        private const String SELECT_ALL_QUERY = "Select * from TaiKhoan";
        private const String INSERT_QUERY = "Insert into TaiKhoan(MaTaiKhoan, TenTaiKhoan, MatKhau, TenDayDu, NgayThangNamSinh, Email, SoDienThoai, ChucVu)" +
            " values(@MaTaiKhoan, @TenTaiKhoan, @MatKhau, @TenDayDu, @NgayThangNamSinh, @Email, @SoDienThoai, @ChucVu)";
        private const String SELECT_BY_CODE_QUERY = "Select * from TaiKhoan where MaTaiKhoan = @MaTaiKhoan";
        private const String UPDATE_QUERY = "Update TaiKhoan SET TenTaiKhoan = @TenTaiKhoan, MatKhau = @MatKhau, TenDayDu = @TenDayDu, NgayThangNamSinh = @NgayThangNamSinh, Email = @Email," +
            "SoDienThoai = @SoDienThoai, ChucVu = @ChucVu where MaTaiKhoan = @MaTaiKhoan";
        private const String DELETE_QUERY = "Delete from TaiKhoan where MaTaiKhoan = @MaTaiKhoan";
        private const String SEARCH_QUERY = " Select * from TaiKhoan where MaTaiKhoan like @KeyWord or TenTaiKhoan like  @KeyWord or TenDayDu like @KeyWord or NgayThangNamSinh like  @KeyWord or Email like  @KeyWord or SoDienThoai like @KeyWord or ChucVu like @KeyWord or MatKhau like @KeyWord";
        private DAL_DBConnection conn;

        public DAL_QLNhanVien()
        {
            conn = new DAL_DBConnection();
        }
        public DataTable layTatCaThongTinTaiKhoanInDB()
        {
            return conn.executeSelectQuery(SELECT_ALL_QUERY);
        }
        public DataTable layThongTinTaiKhoanInDBByCode(String maTaiKhoan)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTaiKhoan", SqlDbType.VarChar);
            sqlParameters[0].Value = maTaiKhoan;
            return conn.executeSelectQueryWithParams(SELECT_BY_CODE_QUERY, sqlParameters);
        }
        public bool themTaiKhoanInDB(DTO_TaiKhoan dto_TaiKhoan)
        {
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[0] = new SqlParameter("@MaTaiKhoan", SqlDbType.VarChar);
            sqlParameters[0].Value = dto_TaiKhoan.MaTaiKhoan;

            sqlParameters[1] = new SqlParameter("@TenTaiKhoan", SqlDbType.NVarChar);
            sqlParameters[1].Value = dto_TaiKhoan.TenTaiKhoan;

            sqlParameters[2] = new SqlParameter("@MatKhau", SqlDbType.NVarChar);
            sqlParameters[2].Value = dto_TaiKhoan.Matkhau;

            sqlParameters[3] = new SqlParameter("@TenDayDu", SqlDbType.NVarChar);
            sqlParameters[3].Value = dto_TaiKhoan.TenDayDu;

            sqlParameters[4] = new SqlParameter("@NgayThangNamSinh", SqlDbType.DateTime);
            sqlParameters[4].Value = dto_TaiKhoan.NgayThangNamSinh;

            sqlParameters[5] = new SqlParameter("@Email", SqlDbType.NVarChar);
            sqlParameters[5].Value = dto_TaiKhoan.Email;

            sqlParameters[6] = new SqlParameter("@SoDienThoai", SqlDbType.VarChar);
            sqlParameters[6].Value = dto_TaiKhoan.SoDienThoai;

            sqlParameters[7] = new SqlParameter("@ChucVu", SqlDbType.NVarChar);
            sqlParameters[7].Value = dto_TaiKhoan.ChucVu;



            return conn.executeInsertQuery(INSERT_QUERY, sqlParameters);
        }
        public bool capNhatThongTinTaiKhoanInDB(DTO_TaiKhoan dto_TaiKhoan)
        {
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[7] = new SqlParameter("@MaTaiKhoan", SqlDbType.VarChar);
            sqlParameters[7].Value = dto_TaiKhoan.MaTaiKhoan;

            sqlParameters[0] = new SqlParameter("@TenTaiKhoan", SqlDbType.NVarChar);
            sqlParameters[0].Value = dto_TaiKhoan.TenTaiKhoan;

            sqlParameters[1] = new SqlParameter("@MatKhau", SqlDbType.NVarChar);
            sqlParameters[1].Value = dto_TaiKhoan.Matkhau;

            sqlParameters[2] = new SqlParameter("@TenDayDu", SqlDbType.NVarChar);
            sqlParameters[2].Value = dto_TaiKhoan.TenDayDu;

            sqlParameters[3] = new SqlParameter("@NgayThangNamSinh", SqlDbType.DateTime);
            sqlParameters[3].Value = dto_TaiKhoan.NgayThangNamSinh;

            sqlParameters[4] = new SqlParameter("@Email", SqlDbType.NVarChar);
            sqlParameters[4].Value = dto_TaiKhoan.Email;

            sqlParameters[5] = new SqlParameter("@SoDienThoai", SqlDbType.VarChar);
            sqlParameters[5].Value = dto_TaiKhoan.SoDienThoai;

            sqlParameters[6] = new SqlParameter("@ChucVu", SqlDbType.NVarChar);
            sqlParameters[6].Value = dto_TaiKhoan.ChucVu;

            return conn.executeUpdateQuery(UPDATE_QUERY, sqlParameters);
        }
        public bool xoaTaiKhoanInDB(String maTaiKhoan)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTaiKhoan", SqlDbType.VarChar);
            sqlParameters[0].Value = maTaiKhoan;
            return conn.executeUpdateQuery(DELETE_QUERY, sqlParameters);
        }
        public DataTable timKiemNhanVienInDB(String keyWord)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@KeyWord", SqlDbType.NVarChar);
            sqlParameters[0].Value = "%" + keyWord + "%";
            return conn.executeSelectQueryWithParams(SEARCH_QUERY, sqlParameters);
        }
    }
}
