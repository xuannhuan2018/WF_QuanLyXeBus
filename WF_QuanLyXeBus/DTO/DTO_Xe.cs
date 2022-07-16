using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_QuanLyXeBus.DTO
{
    public class DTO_Xe
    {
        private string maxe;
        private string bienso;
        private string loaixe;
        private int soghe;
        private int congsuat;
        private DateTime ngaysanxuat;
        private int chukybaohanh;
        private string matuyen;


        public string Maxe { get => maxe; set => maxe = value; }
        public string Bienso { get => bienso; set => bienso = value; }
        public string Loaixe { get => loaixe; set => loaixe = value; }
        public int Soghe { get => soghe; set => soghe = value; }
        public int Congsuat { get => congsuat; set => congsuat = value; }
        public DateTime Ngaysanxuat { get => ngaysanxuat; set => ngaysanxuat = value; }
        public int Chukybaohanh { get => chukybaohanh; set => chukybaohanh = value; }
        public string Matuyen { get => matuyen; set => matuyen = value; }


        public DTO_Xe()
        {

        }

        public DTO_Xe(string maxe, string bienso, string loaixe, int soghe, int congsuat, DateTime ngaysx, int chuky, string matuyen)
        {
            this.matuyen = matuyen;
            this.maxe = maxe;
            this.bienso = bienso;
            this.loaixe = loaixe;
            this.congsuat = congsuat;
            this.ngaysanxuat = ngaysx;
            this.chukybaohanh = chuky;
            this.soghe = soghe;
        }
    }
}
