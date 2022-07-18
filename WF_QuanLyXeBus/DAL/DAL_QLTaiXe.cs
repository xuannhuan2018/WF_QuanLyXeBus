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
    class DAL_QLTaiXe
    {
        private const String SELECT_ALL_QUERY = "Select * from TaiXe";
        private const String INSERT_QUERY = "Insert into TaiXe(MaTX, HoVaTen, NgaySinh, GioiTinh, DiaChi, QueQuan, NgayBDHopDong, Luong, BangLai, MaXe)" +
            " values(@MaTX, @HoVaTen, @NgaySinh, @GioiTinh, @DiaChi, @QueQuan, @NgayBDHopDong, @Luong, @BangLai, @MaXe)";
        private const String SELECT_BY_CODE_QUERY = "Select * from TaiXe where MaTX = @MaTX";
        private const String UPDATE_QUERY = "Update TaiXe SET HoVaTen = @HoVaTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, QueQuan = @QueQuan," +
            "NgayBDHopDong = @NgayBDHopDong, Luong = @Luong, BangLai = @BangLai, MaXe = @MaXe where MaTX = @MaTX";
        private const String DELETE_QUERY = "Delete from TaiXe where MaTX = @MaTX";
        private const String SEARCH_QUERY = " Select * from TaiXe where MaTX like @KeyWord or HoVaTen like  @KeyWord or NgaySinh like @KeyWord or GioiTinh like  @KeyWord or DiaChi like  @KeyWord or QueQuan like @KeyWord or NgayBDHopDong like @KeyWord or Luong like @KeyWord or BangLai like @KeyWord or MaXe like @KeyWord";

        private DAL_DBConnection conn;

        public DAL_QLTaiXe()
        {
            conn = new DAL_DBConnection();
        }
        public DataTable layTatCaThongTinTaiXeInDB()
        {
            return conn.executeSelectQuery(SELECT_ALL_QUERY);
        }
        public DataTable layThongTinTaiXeInDBByCode(String maTaiXe)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTX", SqlDbType.VarChar);
            sqlParameters[0].Value = maTaiXe;
            return conn.executeSelectQueryWithParams(SELECT_BY_CODE_QUERY, sqlParameters);
        }
        public bool themTaiXeInDB(DTO_TaiXe dto_TaiXe)
        {
            SqlParameter[] sqlParameters = new SqlParameter[10];
            sqlParameters[0] = new SqlParameter("@MaTX", SqlDbType.VarChar);
            sqlParameters[0].Value = dto_TaiXe.MaTaiXe;

            sqlParameters[1] = new SqlParameter("@HoVaTen", SqlDbType.NVarChar);
            sqlParameters[1].Value = dto_TaiXe.HoVaTen;

            sqlParameters[2] = new SqlParameter("@NgaySinh", SqlDbType.DateTime);
            sqlParameters[2].Value = dto_TaiXe.NgaySinh;

            sqlParameters[3] = new SqlParameter("@GioiTinh", SqlDbType.NVarChar);
            sqlParameters[3].Value = dto_TaiXe.GioiTinh;

            sqlParameters[4] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            sqlParameters[4].Value = dto_TaiXe.DiaChi;

            sqlParameters[5] = new SqlParameter("@QueQuan", SqlDbType.NVarChar);
            sqlParameters[5].Value = dto_TaiXe.QueQuan;

            sqlParameters[6] = new SqlParameter("@NgayBDHopDong", SqlDbType.DateTime);
            sqlParameters[6].Value = dto_TaiXe.NgayBDHopDong;

            sqlParameters[7] = new SqlParameter("@Luong", SqlDbType.Int);
            sqlParameters[7].Value = dto_TaiXe.Luong;

            sqlParameters[8] = new SqlParameter("@BangLai", SqlDbType.NVarChar);
            sqlParameters[8].Value = dto_TaiXe.BangLai;

            sqlParameters[9] = new SqlParameter("@MaXe", SqlDbType.VarChar);
            sqlParameters[9].Value = dto_TaiXe.MaXe;
        
            return conn.executeInsertQuery(INSERT_QUERY, sqlParameters);
        }
        public bool capNhatTaiXeInDB(DTO_TaiXe dto_TaiXe)
        {
            SqlParameter[] sqlParameters = new SqlParameter[10];
            sqlParameters[9] = new SqlParameter("@MaTX", SqlDbType.VarChar);
            sqlParameters[9].Value = dto_TaiXe.MaTaiXe;

            sqlParameters[0] = new SqlParameter("@HoVaTen", SqlDbType.NVarChar);
            sqlParameters[0].Value = dto_TaiXe.HoVaTen;

            sqlParameters[1] = new SqlParameter("@NgaySinh", SqlDbType.DateTime);
            sqlParameters[1].Value = dto_TaiXe.NgaySinh;

            sqlParameters[2] = new SqlParameter("@GioiTinh", SqlDbType.NVarChar);
            sqlParameters[2].Value = dto_TaiXe.GioiTinh;

            sqlParameters[3] = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            sqlParameters[3].Value = dto_TaiXe.DiaChi;

            sqlParameters[4] = new SqlParameter("@QueQuan", SqlDbType.NVarChar);
            sqlParameters[4].Value = dto_TaiXe.QueQuan;

            sqlParameters[5] = new SqlParameter("@NgayBDHopDong", SqlDbType.DateTime);
            sqlParameters[5].Value = dto_TaiXe.NgayBDHopDong;

            sqlParameters[6] = new SqlParameter("@Luong", SqlDbType.Int);
            sqlParameters[6].Value = dto_TaiXe.Luong;

            sqlParameters[7] = new SqlParameter("@BangLai", SqlDbType.NVarChar);
            sqlParameters[7].Value = dto_TaiXe.BangLai;

            sqlParameters[8] = new SqlParameter("@MaXe", SqlDbType.VarChar);
            sqlParameters[8].Value = dto_TaiXe.MaXe;

            return conn.executeUpdateQuery(UPDATE_QUERY, sqlParameters);
        }
        public bool xoaTaiXeInDB(String maTaiXe)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTX", SqlDbType.VarChar);
            sqlParameters[0].Value = maTaiXe;
            return conn.executeUpdateQuery(DELETE_QUERY, sqlParameters);
        }
        public DataTable timKiemTaiXeInDB(String keyWord)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@KeyWord", SqlDbType.NVarChar);
            sqlParameters[0].Value = "%" + keyWord + "%";
            return conn.executeSelectQueryWithParams(SEARCH_QUERY, sqlParameters);
        }
    }
}
