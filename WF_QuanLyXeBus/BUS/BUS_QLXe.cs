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
    class BUS_QLXe
    {
        private DAL_QLXe dal_QLXe;
        public BUS_QLXe()
        {
            dal_QLXe = new DAL_QLXe();
        }
        public DataTable layDanhSachMaXe()
        {
            return dal_QLXe.layMaXeInDB();
        }
        public DataTable layTatCaThongTinXe()
        {
            return dal_QLXe.layTatCaThongTinXeInDB();
        }

        public bool themXe(DTO_Xe dto_Xe)
        {
            return dal_QLXe.themXeInDB(dto_Xe);
        }
        public DataTable layThongTinXeBangCode(String maXe)
        {
            return dal_QLXe.layThongTinXeInDBByCode(maXe);
        }
        public bool capNhatThongTinXe(DTO_Xe dto_Xe)
        {
            return dal_QLXe.capNhatXeInDB(dto_Xe);
        }
        public bool xoaXe(String maXe)
        {
            return dal_QLXe.xoaXeInDB(maXe);
        }
        public DataTable timKiemXe(String keyWord)
        {
            return dal_QLXe.timKiemXeInDB(keyWord);
        }
    }
}
