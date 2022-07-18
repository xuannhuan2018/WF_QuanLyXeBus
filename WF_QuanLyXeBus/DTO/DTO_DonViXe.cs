using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_QuanLyXeBus.DTO
{
    public class DTO_DonViXe
    {
        private String maDonVi;
        private String tenDonVi;
        private String soDienThoai;
        private String email;
        private String diaChi;

        public string MaDonVi { get => maDonVi; set => maDonVi = value; }
        public string TenDonVi { get => tenDonVi; set => tenDonVi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string Email { get => email; set => email = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
