using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_QuanLyXeBus.DAL;
using System.Data;
using WF_QuanLyXeBus.DTO;

namespace WF_QuanLyXeBus.BUS
{
    class BUS_QLDonVi
    {
        private DAL_QLDonVi dal_QLDonVi;
        public BUS_QLDonVi()
        {
            dal_QLDonVi = new DAL_QLDonVi();
        }

        public DataTable layDanhSachMaDonVi()
        {
            return dal_QLDonVi.layMaDonViInDB();
        }
        public DataTable layTatCaThongTinDonVi()
        {
            return dal_QLDonVi.layTatCaThongTinDonViInDB();
        }

        public bool themDonVi(DTO_DonViXe dto_DonVi)
        {
            return dal_QLDonVi.themDonViInDB(dto_DonVi);
        }
        public DataTable layThongTinDonViByCode(String maDonVi)
        {
            return dal_QLDonVi.layThongTinDonViInDBByCode(maDonVi);
        }
        public bool capNhatThongTinDonVi(DTO_DonViXe dto_DonVi)
        {
            return dal_QLDonVi.capNhatThongTinDonViInDB(dto_DonVi);
        }
        public bool xoaDonVi(String maDonVi)
        {
            return dal_QLDonVi.xoaDonViInDB(maDonVi);
        }
        public DataTable timKiemDonVi(String keyWord)
        {
            return dal_QLDonVi.timKiemDonViInDB(keyWord);
        }
    }
}

