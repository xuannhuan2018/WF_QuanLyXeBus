using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_QuanLyXeBus.DTO
{
    public class DTO_DonViXe
    {
        private String madonvi;
        private String tendonvi;
        private int sodienthoai;
        private String email;
        private String diachi;

       

        public DTO_DonViXe()
        {

        }

        public DTO_DonViXe(String madonvi, String tendonvi, String diachi, String email, int sodienthoai)
        {
            this.Madonvi = madonvi;
            this.Tendonvi = tendonvi;
            this.Email = email;
            this.Sodienthoai = sodienthoai;
            this.Diachi = diachi;
        }

        public string Madonvi { get => madonvi; set => madonvi = value; }
        public string Tendonvi { get => tendonvi; set => tendonvi = value; }
        public int Sodienthoai { get => sodienthoai; set => sodienthoai = value; }
        public string Email { get => email; set => email = value; }
        public string Diachi { get => diachi; set => diachi = value; }
    }
}
