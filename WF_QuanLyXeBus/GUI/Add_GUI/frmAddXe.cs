using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanLyXeBus.DTO;
using WF_QuanLyXeBus.BUS;

namespace WF_QuanLyXeBus.GUI.Add_GUI
{
    public partial class frmAddXe : Form
    {
        private BUS_QLXe bus_QLXe;
        private BUS_QLTuyenXe bus_QLTuyenXe;
        private DTO_Xe dto_Xe;
        public frmAddXe()
        {
            InitializeComponent();
            bus_QLXe = new BUS_QLXe();
            bus_QLTuyenXe = new BUS_QLTuyenXe();
        }
        public frmAddXe(DTO_Xe dto_Xe)
        {
            InitializeComponent();
            bus_QLXe = new BUS_QLXe();
            bus_QLTuyenXe = new BUS_QLTuyenXe();
            this.dto_Xe = dto_Xe;
        }
        private void frmAddXe_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            //Load danh sach Ma Tuyen den combobox Ma Tuyen
            foreach (DataRow dr in bus_QLTuyenXe.layDanhSachMaTuyenXe().Rows)
            {
                cmbMaTuyen.Items.Add(dr.Field<String>("MaTuyen"));
            }
            if (dto_Xe == null)
            {
                this.Text = "Thêm Xe";
            }
            else
            {
                this.Text = "Chỉnh sửa xe " + dto_Xe.MaXe;
                txtBienSo.Text = dto_Xe.BienSo;
                cmbLoaiXe.Text = dto_Xe.LoaiXe;
                mskSoGhe.Text = Convert.ToString(dto_Xe.SoGhe);
                mskCongSuat.Text = Convert.ToString(dto_Xe.CongSuat);
                mskChuKiBaoHanh.Text = Convert.ToString(dto_Xe.ChuKiBaoHanh);
                dto_Xe.NgaySanXuat = dtNgaySX.Value = dto_Xe.NgaySanXuat;
                cmbMaTuyen.Text = dto_Xe.MaTuyen;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.Xe));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dto_Xe == null)
            {
                if (BUS_ValidateInputValue.checkInputValue(this))
                {
                    try
                    {
                        dto_Xe = new DTO_Xe();
                        dto_Xe.MaXe = BUS_RandomCodeForPKInDB.genarateCode();
                        commonAssignObject(dto_Xe);
                        if (bus_QLXe.themXe(dto_Xe))
                        {
                            MessageBox.Show("Thêm thành công mã xe " + dto_Xe.MaXe);
                        };
                        Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.Xe));
                    }
                    catch (Exception)
                    {
                        dto_Xe = null;
                        MessageBox.Show("Thêm mã xe thất bại!");
                    }
                }
                else
                {
                    dto_Xe = null;
                }
            }
            else
            {
                if (BUS_ValidateInputValue.checkInputValue(this))
                {
                    try
                    {
                        commonAssignObject(dto_Xe);
                        if (bus_QLXe.capNhatThongTinXe(dto_Xe))
                        {
                            MessageBox.Show("Cập nhật thành công mã xe " + dto_Xe.MaXe);
                            Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.Xe));
                        };
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cập nhật thất bại!");
                    }
                }
            }
        }
        private void commonAssignObject(DTO_Xe dto_Xe)
        {
            dto_Xe.BienSo = txtBienSo.Text;
            dto_Xe.LoaiXe = cmbLoaiXe.Text;
            dto_Xe.SoGhe = int.Parse(mskSoGhe.Text);
            dto_Xe.CongSuat = int.Parse(mskCongSuat.Text);
            dto_Xe.ChuKiBaoHanh = int.Parse(mskChuKiBaoHanh.Text.Substring(0, 2));
            dto_Xe.NgaySanXuat = dtNgaySX.Value;
            dto_Xe.MaTuyen = cmbMaTuyen.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtBienSo.ResetText();
            cmbLoaiXe.ResetText();
            mskSoGhe.ResetText();
            mskCongSuat.ResetText();
            mskChuKiBaoHanh.ResetText();
            cmbMaTuyen.ResetText();

        }

        private void dtNgaySX_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
