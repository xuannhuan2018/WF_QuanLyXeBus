using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_QuanLyXeBus.DTO;
using System.Data;
using System.Data.SqlClient;

namespace WF_QuanLyXeBus.DAL
{
    class DAL_QLTuyenXe
    {
        private const String SELECT_ALL_QUERY = "Select * from TuyenXe";
        private const String SELECT_MTX_QUERY = "Select MaTuyen from TuyenXe";
        private const String INSERT_QUERY = "Insert into TuyenXe(MaTuyen, MaDonVi, TenTuyen, ThoigianBatDau, ThoigianKetThuc, ThoigianGianCach, LoTrinhluotDi, LoTrinhLuotVe, LoaiTuyen)" +
            " values(@MaTuyen, @MaDonVi, @TenTuyen, @ThoigianBatDau, @ThoigianKetThuc, @ThoigianGianCach, @LoTrinhLuotDi, @LoTrinhLuotVe, @Loaituyen)";
        private const String SELECT_BY_CODE_QUERY = "Select * from TuyenXe where MaTuyen = @MaTuyen";
        private const String UPDATE_QUERY = "Update TuyenXe SET MaDonVi = @MaDonVi, TenTuyen = @TenTuyen, ThoigianBatDau = @ThoigianBatDau, ThoigianKetThuc = @ThoigianKetThuc, ThoigianGianCach = @ThoigianGianCach," +
            "LoTrinhLuotDi = @LoTrinhLuotDi, LoTrinhLuotVe = @LoTrinhLuotVe, LoaiTuyen = @LoaiTuyen where MaTuyen = @MaTuyen";
        private const String DELETE_QUERY = "Delete from TuyenXe where MaTuyen = @MaTuyen";
        private const String SEARCH_QUERY = " Select * from TuyenXe where MaTuyen like @KeyWord or MaDonVi like  @KeyWord or TenTuyen like @KeyWord or ThoigianBatDau like  @KeyWord or ThoigianKetThuc like  @KeyWord or ThoigianGianCach like @KeyWord or LoTrinhluotDi like @KeyWord or LoTrinhLuotVe like @KeyWord or LoaiTuyen like @KeyWord";


        private DAL_DBConnection conn;
        public DAL_QLTuyenXe()
        {
            conn = new DAL_DBConnection();
        }
        public DataTable layTatCaThongTinTuyenXeInDB()
        {
            return conn.executeSelectQuery(SELECT_ALL_QUERY);
        }
        public DataTable layMaTuyenXeInDB()
        {
            return conn.executeSelectQuery(SELECT_MTX_QUERY);
        }
        public DataTable layThongTinTuyenXeInDBByCode(String maTuyen)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTuyen", SqlDbType.VarChar);
            sqlParameters[0].Value = maTuyen;
            return conn.executeSelectQueryWithParams(SELECT_BY_CODE_QUERY, sqlParameters);
        }
        public bool themTuyenXeInDB(DTO_TuyenXe dto_TuyenXe)
        {
            SqlParameter[] sqlParameters = new SqlParameter[9];
            sqlParameters[0] = new SqlParameter("@MaTuyen", SqlDbType.VarChar);
            sqlParameters[0].Value = dto_TuyenXe.MaTuyen;

            sqlParameters[1] = new SqlParameter("@MaDonVi", SqlDbType.VarChar);
            sqlParameters[1].Value = dto_TuyenXe.MaDonVi;

            sqlParameters[2] = new SqlParameter("@TenTuyen", SqlDbType.NVarChar);
            sqlParameters[2].Value = dto_TuyenXe.TenTuyen;

            sqlParameters[3] = new SqlParameter("@ThoigianBatDau", SqlDbType.DateTime);
            sqlParameters[3].Value = dto_TuyenXe.ThoiGianBatDau;

            sqlParameters[4] = new SqlParameter("@ThoigianKetThuc", SqlDbType.DateTime);
            sqlParameters[4].Value = dto_TuyenXe.ThoiGianKetThuc;

            sqlParameters[5] = new SqlParameter("@ThoigianGianCach", SqlDbType.Int);
            sqlParameters[5].Value = dto_TuyenXe.ThoiGianGianCach;

            sqlParameters[6] = new SqlParameter("@LoTrinhLuotDi", SqlDbType.NVarChar);
            sqlParameters[6].Value = dto_TuyenXe.LoTrinhLuotDi;

            sqlParameters[7] = new SqlParameter("@LoTrinhLuotVe", SqlDbType.NVarChar);
            sqlParameters[7].Value = dto_TuyenXe.LoTrinhLuotVe;

            sqlParameters[8] = new SqlParameter("@LoaiTuyen", SqlDbType.NVarChar);
            sqlParameters[8].Value = dto_TuyenXe.LoaiTuyen;

            return conn.executeInsertQuery(INSERT_QUERY, sqlParameters);
        }
        public bool capNhatTuyenXeInDB(DTO_TuyenXe dto_TuyenXe)
        {
            SqlParameter[] sqlParameters = new SqlParameter[9];
            sqlParameters[8] = new SqlParameter("@MaTuyen", SqlDbType.VarChar);
            sqlParameters[8].Value = dto_TuyenXe.MaTuyen;

            sqlParameters[0] = new SqlParameter("@MaDonVi", SqlDbType.NVarChar);
            sqlParameters[0].Value = dto_TuyenXe.MaDonVi;

            sqlParameters[1] = new SqlParameter("@TenTuyen", SqlDbType.NVarChar);
            sqlParameters[1].Value = dto_TuyenXe.TenTuyen;

            sqlParameters[2] = new SqlParameter("@ThoigianBatDau", SqlDbType.DateTime);
            sqlParameters[2].Value = dto_TuyenXe.ThoiGianBatDau;

            sqlParameters[3] = new SqlParameter("@ThoigianKetThuc", SqlDbType.DateTime);
            sqlParameters[3].Value = dto_TuyenXe.ThoiGianKetThuc;

            sqlParameters[4] = new SqlParameter("@ThoigianGianCach", SqlDbType.Int);
            sqlParameters[4].Value = dto_TuyenXe.ThoiGianGianCach;

            sqlParameters[5] = new SqlParameter("@LoTrinhLuotDi", SqlDbType.NVarChar);
            sqlParameters[5].Value = dto_TuyenXe.LoTrinhLuotDi;

            sqlParameters[6] = new SqlParameter("@LoTrinhLuotVe", SqlDbType.NVarChar);
            sqlParameters[6].Value = dto_TuyenXe.LoTrinhLuotVe;

            sqlParameters[7] = new SqlParameter("@LoaiTuyen", SqlDbType.NVarChar);
            sqlParameters[7].Value = dto_TuyenXe.LoaiTuyen;

            return conn.executeUpdateQuery(UPDATE_QUERY, sqlParameters);
        }
        public bool xoaTuyenXeInDB(String maTuyen)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@MaTuyen", SqlDbType.VarChar);
            sqlParameters[0].Value = maTuyen;
            return conn.executeUpdateQuery(DELETE_QUERY, sqlParameters);
        }
        public DataTable timKiemTuyenXeInDB(String keyWord)
        {
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@KeyWord", SqlDbType.NVarChar);
            sqlParameters[0].Value = "%" + keyWord + "%";
            return conn.executeSelectQueryWithParams(SEARCH_QUERY, sqlParameters);
        }
    }
}
