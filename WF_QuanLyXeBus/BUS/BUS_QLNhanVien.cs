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
    class BUS_QLNhanVien
    {
        private DAL_QLNhanVien dal_QLNhanVien;
        public BUS_QLNhanVien()
        {
            dal_QLNhanVien = new DAL_QLNhanVien();
        }
        public DataTable layTatCaThongTinTaiKhoan()
        {
            return dal_QLNhanVien.layTatCaThongTinTaiKhoanInDB();
        }

        public bool themTaiKhoan(DTO_TaiKhoan dto_TaiKhoan)
        {
            return dal_QLNhanVien.themTaiKhoanInDB(dto_TaiKhoan);
        }
        public DataTable layThongTinTaiKhoanBangCode(String maTaiKhoan)
        {
            return dal_QLNhanVien.layThongTinTaiKhoanInDBByCode(maTaiKhoan);
        }
        public bool capNhatThongTinTaiKhoan(DTO_TaiKhoan dto_TaiKhoan)
        {
            return dal_QLNhanVien.capNhatThongTinTaiKhoanInDB(dto_TaiKhoan);
        }
        public bool xoaTaiKhoan(String maTaiKhoan)
        {
            return dal_QLNhanVien.xoaTaiKhoanInDB(maTaiKhoan);
        }
        public DataTable timKiemNhanVien(String keyWord)
        {
            return dal_QLNhanVien.timKiemNhanVienInDB(keyWord);
        }
    }
}
