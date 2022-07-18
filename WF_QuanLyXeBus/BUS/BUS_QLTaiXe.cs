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
    class BUS_QLTaiXe
    {
        private DAL_QLTaiXe dal_QLTaiXe;
        public BUS_QLTaiXe()
        {
            dal_QLTaiXe = new DAL_QLTaiXe();
        }
        public DataTable layTatCaThongTinTaiXe()
        {
            return dal_QLTaiXe.layTatCaThongTinTaiXeInDB();
        }

        public bool themTaiXe(DTO_TaiXe dto_TaiXe)
        {
            return dal_QLTaiXe.themTaiXeInDB(dto_TaiXe);
        }
        public DataTable layThongTinTaiXeBangCode(String maTaiXe)
        {
            return dal_QLTaiXe.layThongTinTaiXeInDBByCode(maTaiXe);
        }
        public bool capNhatThongTinTaiXe(DTO_TaiXe dto_TaiXe)
        {
            return dal_QLTaiXe.capNhatTaiXeInDB(dto_TaiXe);
        }
        public bool xoaTaiXe(String maTaiXe)
        {
            return dal_QLTaiXe.xoaTaiXeInDB(maTaiXe);
        }
        public DataTable timKiemTaiXe(String keyWord)
        {
            return dal_QLTaiXe.timKiemTaiXeInDB(keyWord);
        }
    }
}
