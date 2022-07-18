using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_QuanLyXeBus.DAL;
using WF_QuanLyXeBus.DTO;
using System.Data;

namespace WF_QuanLyXeBus.BUS
{
    class BUS_QLTuyenXe
    {
        private DAL_QLTuyenXe dal_QLTuyenXe;
        public BUS_QLTuyenXe()
        {
            dal_QLTuyenXe = new DAL_QLTuyenXe();
        }
        public DataTable layDanhSachMaTuyenXe()
        {
            return dal_QLTuyenXe.layMaTuyenXeInDB();
        }
        public DataTable layTatCaThongTinTuyenXe()
        {
            return dal_QLTuyenXe.layTatCaThongTinTuyenXeInDB();
        }

        public bool themTuyenXe(DTO_TuyenXe dto_TuyenXe)
        {
            return dal_QLTuyenXe.themTuyenXeInDB(dto_TuyenXe);
        }
        public DataTable layThongTinTuyenXeBangCode(String maTuyen)
        {
            return dal_QLTuyenXe.layThongTinTuyenXeInDBByCode(maTuyen);
        }
        public bool capNhatThongTinTuyenXe(DTO_TuyenXe dto_TuyenXe)
        {
            return dal_QLTuyenXe.capNhatTuyenXeInDB(dto_TuyenXe);
        }
        public bool xoaTuyenXe(String maTuyen)
        {
            return dal_QLTuyenXe.xoaTuyenXeInDB(maTuyen);
        }
        public DataTable timKiemTuyenXe(String keyWord)
        {
            return dal_QLTuyenXe.timKiemTuyenXeInDB(keyWord);
        }
    }
}
