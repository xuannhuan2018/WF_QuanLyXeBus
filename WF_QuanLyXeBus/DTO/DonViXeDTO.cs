using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_QuanLyXeBus.DTO
{
    public class DonViXeDTO
    {
        private string madonvi;
        private string tendonvi;
        private int sodienthoai;
        private string email;
        private string diachi;

        public string Madonvi { get => madonvi; set => madonvi = value; }
        public string Tendonvi { get => tendonvi; set => tendonvi = value; }
        public int Sodienthoai { get => sodienthoai; set => sodienthoai = value; }
        public string Email { get => email; set => email = value; }
        public string Diachi { get => diachi; set => diachi = value; }

        public DonViXeDTO()
        {

        }

        public DonViXeDTO(string madonvi, string tendonvi, string diachi, string email, int sodienthoai)
        {
            this.madonvi = madonvi;
            this.tendonvi = tendonvi;
            this.email = email;
            this.sodienthoai = sodienthoai;
            this.diachi = diachi;
        }
    }
}
