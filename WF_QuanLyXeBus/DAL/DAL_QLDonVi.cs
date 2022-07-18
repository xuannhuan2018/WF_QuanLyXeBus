using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WF_QuanLyXeBus.DTO;

namespace WF_QuanLyXeBus.DAL
{
    class DAL_QLDonVi
    {
        private const String SELECT_ALL_QUERY = "Select * from DonViQLXe";
        private const String SELECT_MDV_QUERY = "Select MaDonVi from DonViQLXe";
        private const String INSERT_QUERY = "Insert into DonViQLXe(MaDonVi, TenDonVi, DiaChi, SoDienThoai, Email)" +
    " values(@MaDonVi, @TenDonVi, @DiaChi, @SoDienThoai, @Email)";
        private const String SELECT_BY_CODE_QUERY = "Select * from DonViQLXe where MaDonVi = @MaDonVi";
        private const String UPDATE_QUERY = "Update DonViQLXe SET TenDonVi = @TenDonVi, DiaChi = @DiaChi, SoDienThoai = @SoDienThoai, Email = @Email " +
            " where MaDonVi = @MaDonVi";
        private const String DELETE_QUERY = "Delete from DonViQLXe where MaDonVi = @MaDonVi";
        private const String SEARCH_QUERY = " Select * from DonViQLXe where MaDonVi like @KeyWord or TenDonVi like  @KeyWord or DiaChi like @KeyWord or SoDienThoai like  @KeyWord or Email like  @KeyWord";
        private DAL_DBConnection conn;
        public DAL_QLDonVi()
        {
            conn = new DAL_DBConnection();
        }

        public DataTable layMaDonViInDB()
        {
            return conn.executeSelectQuery(SELECT_MDV_QUERY);
        }
        public DataTable layTatCaThongTinDonViInDB()
        {
            return conn.executeSelectQuery(SELECT_ALL_QUERY);
        }
        public DataTable layThongTinDonViInDBByCode(String maDonVi)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaDonVi", SqlDbType.VarChar);
            sqlParameters[0].Value = maDonVi;
            return conn.executeSelectQueryWithParams(SELECT_BY_CODE_QUERY, sqlParameters);
        }
        public bool themDonViInDB(DTO_DonViXe dto_DonVi)
        {
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@MaDonVi", SqlDbType.VarChar);
            sqlParameters[0].Value = dto_DonVi.MaDonVi;

            sqlParameters[1] = new SqlParameter("@TenDonVi", SqlDbType.NVarChar);
            sqlParameters[1].Value = dto_DonVi.TenDonVi;

            sqlParameters[2] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            sqlParameters[2].Value = dto_DonVi.DiaChi;

            sqlParameters[3] = new SqlParameter("@SoDienThoai", SqlDbType.VarChar);
            sqlParameters[3].Value = dto_DonVi.SoDienThoai;

            sqlParameters[4] = new SqlParameter("@Email", SqlDbType.NVarChar);
            sqlParameters[4].Value = dto_DonVi.Email;


            return conn.executeInsertQuery(INSERT_QUERY, sqlParameters);
        }
        public bool capNhatThongTinDonViInDB(DTO_DonViXe dto_DonVi)
        {
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[4] = new SqlParameter("@MaDonVi", SqlDbType.VarChar);
            sqlParameters[4].Value = dto_DonVi.MaDonVi;

            sqlParameters[0] = new SqlParameter("@TenDonVi", SqlDbType.NVarChar);
            sqlParameters[0].Value = dto_DonVi.TenDonVi;

            sqlParameters[1] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            sqlParameters[1].Value = dto_DonVi.DiaChi;

            sqlParameters[2] = new SqlParameter("@SoDienThoai", SqlDbType.VarChar);
            sqlParameters[2].Value = dto_DonVi.SoDienThoai;

            sqlParameters[3] = new SqlParameter("@Email", SqlDbType.NVarChar);
            sqlParameters[3].Value = dto_DonVi.Email;

            return conn.executeUpdateQuery(UPDATE_QUERY, sqlParameters);
        }
        public bool xoaDonViInDB(String maDonVi)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaDonVi", SqlDbType.VarChar);
            sqlParameters[0].Value = maDonVi;
            return conn.executeUpdateQuery(DELETE_QUERY, sqlParameters);
        }
        public DataTable timKiemDonViInDB(String keyWord)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@KeyWord", SqlDbType.NVarChar);
            sqlParameters[0].Value = "%" + keyWord + "%";
            return conn.executeSelectQueryWithParams(SEARCH_QUERY, sqlParameters);
        }

    }
}
