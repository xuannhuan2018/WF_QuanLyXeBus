using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_QuanLyXeBus.DTO
{
    public class DTO_TaiXe
    {
        private String maTaiXe;
        private String hoVaTen;
        private DateTime ngaySinh;
        private String gioiTinh;
        private String diaChi;
        private String queQuan;
        private DateTime ngayBDHopDong;
        private int luong;
        private String bangLai;
        private String maXe;

        public string MaTaiXe { get => maTaiXe; set => maTaiXe = value; }
        public string HoVaTen { get => hoVaTen; set => hoVaTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string QueQuan { get => queQuan; set => queQuan = value; }
        public DateTime NgayBDHopDong { get => ngayBDHopDong; set => ngayBDHopDong = value; }
        public int Luong { get => luong; set => luong = value; }
        public string BangLai { get => bangLai; set => bangLai = value; }
        public string MaXe { get => maXe; set => maXe = value; }
    }
}
