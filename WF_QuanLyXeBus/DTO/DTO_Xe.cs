using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_QuanLyXeBus.DTO
{
    public class DTO_Xe
    {
        private String maXe;
        private String bienSo;
        private String loaiXe;
        private int soGhe;
        private int congSuat;
        private DateTime ngaySanXuat;
        private int chuKiBaoHanh;
        private String maTuyen;

        public string MaXe { get => maXe; set => maXe = value; }
        public string BienSo { get => bienSo; set => bienSo = value; }
        public string LoaiXe { get => loaiXe; set => loaiXe = value; }
        public int SoGhe { get => soGhe; set => soGhe = value; }
        public int CongSuat { get => congSuat; set => congSuat = value; }
        public DateTime NgaySanXuat { get => ngaySanXuat; set => ngaySanXuat = value; }
        public int ChuKiBaoHanh { get => chuKiBaoHanh; set => chuKiBaoHanh = value; }
        public string MaTuyen { get => maTuyen; set => maTuyen = value; }
    }
}
