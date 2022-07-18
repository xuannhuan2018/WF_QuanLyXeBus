using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using WF_QuanLyXeBus.DTO;

namespace WF_QuanLyXeBus.DAL
{
    class DAL_QLXe
    {
        private const String SELECT_ALL_QUERY = "Select * from Xe";
        private const String SELECT_MX_QUERY = "Select MaXe from Xe";
        private const String INSERT_QUERY = "Insert into Xe(MaXe, BienSo, LoaiXe, SoGhe, CongSuat, NgaySX, ChuKiBaoHanh, MaTuyen)" +
            " values(@MaXe, @BienSo, @LoaiXe, @SoGhe, @CongSuat, @NgaySX, @ChuKiBaoHanh, @MaTuyen)";
        private const String SELECT_BY_CODE_QUERY = "Select * from Xe where MaXe = @MaXe";
        private const String UPDATE_QUERY = "Update Xe SET BienSo = @BienSo, LoaiXe = @LoaiXe, SoGhe = @SoGhe, CongSuat = @CongSuat," +
            "NgaySX = @NgaySX, ChuKiBaoHanh = @ChuKiBaoHanh, MaTuyen = @MaTuyen where MaXe = @MaXe";
        private const String DELETE_QUERY = "Delete from Xe where MaXe = @MaXe";
        private const String SEARCH_QUERY = " Select * from Xe where MaXe like @KeyWord or BienSo like  @KeyWord or LoaiXe like @KeyWord or SoGhe like  @KeyWord or CongSuat like  @KeyWord or NgaySX like @KeyWord or ChuKiBaoHanh like @KeyWord or MaTuyen like @KeyWord";

        private DAL_DBConnection conn;
        public DAL_QLXe()
        {
            conn = new DAL_DBConnection();
        }
        public DataTable layTatCaThongTinXeInDB()
        {
            return conn.executeSelectQuery(SELECT_ALL_QUERY);
        }
        public DataTable layMaXeInDB()
        {
            return conn.executeSelectQuery(SELECT_MX_QUERY);
        }
        public DataTable layThongTinXeInDBByCode(String maXe)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaXe", SqlDbType.VarChar);
            sqlParameters[0].Value = maXe;
            return conn.executeSelectQueryWithParams(SELECT_BY_CODE_QUERY, sqlParameters);
        }
        public bool themXeInDB(DTO_Xe dto_Xe)
        {
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[0] = new SqlParameter("@MaXe", SqlDbType.VarChar);
            sqlParameters[0].Value = dto_Xe.MaXe;

            sqlParameters[1] = new SqlParameter("@BienSo", SqlDbType.NVarChar);
            sqlParameters[1].Value = dto_Xe.BienSo;

            sqlParameters[2] = new SqlParameter("@LoaiXe", SqlDbType.NVarChar);
            sqlParameters[2].Value = dto_Xe.LoaiXe;

            sqlParameters[3] = new SqlParameter("@SoGhe", SqlDbType.Int);
            sqlParameters[3].Value = dto_Xe.SoGhe;

            sqlParameters[4] = new SqlParameter("@CongSuat", SqlDbType.Int);
            sqlParameters[4].Value = dto_Xe.CongSuat;

            sqlParameters[5] = new SqlParameter("@NgaySX", SqlDbType.DateTime);
            sqlParameters[5].Value = dto_Xe.NgaySanXuat;

            sqlParameters[6] = new SqlParameter("@ChuKiBaoHanh", SqlDbType.Int);
            sqlParameters[6].Value = dto_Xe.ChuKiBaoHanh;

            sqlParameters[7] = new SqlParameter("@MaTuyen", SqlDbType.VarChar);
            sqlParameters[7].Value = dto_Xe.MaTuyen;


            return conn.executeInsertQuery(INSERT_QUERY, sqlParameters);
        }
        public bool capNhatXeInDB(DTO_Xe dto_Xe)
        {
            SqlParameter[] sqlParameters = new SqlParameter[8];
            sqlParameters[7] = new SqlParameter("@MaXe", SqlDbType.VarChar);
            sqlParameters[7].Value = dto_Xe.MaXe;

            sqlParameters[0] = new SqlParameter("@BienSo", SqlDbType.NVarChar);
            sqlParameters[0].Value = dto_Xe.BienSo;

            sqlParameters[1] = new SqlParameter("@LoaiXe", SqlDbType.NVarChar);
            sqlParameters[1].Value = dto_Xe.LoaiXe;

            sqlParameters[2] = new SqlParameter("@SoGhe", SqlDbType.Int);
            sqlParameters[2].Value = dto_Xe.SoGhe;

            sqlParameters[3] = new SqlParameter("@CongSuat", SqlDbType.Int);
            sqlParameters[3].Value = dto_Xe.CongSuat;

            sqlParameters[4] = new SqlParameter("@NgaySX", SqlDbType.DateTime);
            sqlParameters[4].Value = dto_Xe.NgaySanXuat;

            sqlParameters[5] = new SqlParameter("@ChuKiBaoHanh", SqlDbType.Int);
            sqlParameters[5].Value = dto_Xe.ChuKiBaoHanh;

            sqlParameters[6] = new SqlParameter("@MaTuyen", SqlDbType.VarChar);
            sqlParameters[6].Value = dto_Xe.MaTuyen;

            return conn.executeUpdateQuery(UPDATE_QUERY, sqlParameters);
        }
        public bool xoaXeInDB(String maXe)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaXe", SqlDbType.VarChar);
            sqlParameters[0].Value = maXe;
            return conn.executeUpdateQuery(DELETE_QUERY, sqlParameters);
        }
        public DataTable timKiemXeInDB(String keyWord)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@KeyWord", SqlDbType.NVarChar);
            sqlParameters[0].Value = "%" + keyWord + "%";
            return conn.executeSelectQueryWithParams(SEARCH_QUERY, sqlParameters);
        }
    }
}
