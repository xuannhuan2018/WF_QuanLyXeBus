using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_QuanLyXeBus.DTO
{
    public class DTO_TuyenXe
    {
        private String maTuyen;
        private String maDonVi;
        private String tenTuyen;
        private String thoiGianBatDau;
        private String thoiGianKetThuc;
        private int thoiGianGianCach;
        private String loTrinhLuotDi;
        private String loTrinhLuotVe;
        private String loaiTuyen;

        public string MaTuyen { get => maTuyen; set => maTuyen = value; }
        public string MaDonVi { get => maDonVi; set => maDonVi = value; }
        public string TenTuyen { get => tenTuyen; set => tenTuyen = value; }
        public string ThoiGianBatDau { get => thoiGianBatDau; set => thoiGianBatDau = value; }
        public string ThoiGianKetThuc { get => thoiGianKetThuc; set => thoiGianKetThuc = value; }
        public int ThoiGianGianCach { get => thoiGianGianCach; set => thoiGianGianCach = value; }
        public string LoTrinhLuotDi { get => loTrinhLuotDi; set => loTrinhLuotDi = value; }
        public string LoTrinhLuotVe { get => loTrinhLuotVe; set => loTrinhLuotVe = value; }
        public string LoaiTuyen { get => loaiTuyen; set => loaiTuyen = value; }
    }
}
