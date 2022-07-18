using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanLyXeBus.BUS;
using WF_QuanLyXeBus.DTO;

namespace WF_QuanLyXeBus.GUI.Add_GUI
{
    public partial class frmAddTaiXe : Form
    {
        private BUS_QLTaiXe bus_QLTaiXe;
        private BUS_QLXe bus_QLXe;
        private DTO_TaiXe dto_TaiXe;
        public frmAddTaiXe()
        {
            InitializeComponent();
            bus_QLTaiXe = new BUS_QLTaiXe();
            bus_QLXe = new BUS_QLXe();
        }
        public frmAddTaiXe(DTO_TaiXe dto_TaiXe)
        {
            InitializeComponent();
            bus_QLTaiXe = new BUS_QLTaiXe();
            bus_QLXe = new BUS_QLXe();
            this.dto_TaiXe = dto_TaiXe;
        }

        private void frmAddTaiXe_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            foreach (DataRow dr in bus_QLXe.layDanhSachMaXe().Rows)
            {
                cmbMaXeLai.Items.Add(dr.Field<String>("MaXe"));
            }
            if (dto_TaiXe == null)
            {
                this.Text = "Thêm tài xế";
            }
            else
            {
                this.Text = "Chỉnh sửa tài xế " + dto_TaiXe.MaTaiXe;
                txtHoTen.Text = dto_TaiXe.HoVaTen;
                dtBirthday.Value = dto_TaiXe.NgaySinh;
                cmbGioiTinh.Text = dto_TaiXe.GioiTinh;
                txtDiaChi.Text = dto_TaiXe.DiaChi;
                txtQuequan.Text = dto_TaiXe.QueQuan;
                dtNgayBDLam.Value = dto_TaiXe.NgayBDHopDong;
                txtMaBangLai.Text = dto_TaiXe.BangLai;
                mskLuong.Text = Convert.ToString(dto_TaiXe.Luong);
                cmbMaXeLai.Text = dto_TaiXe.MaXe;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.TaiXe));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtHoTen.ResetText();
            cmbGioiTinh.ResetText();
            txtDiaChi.ResetText();
            txtQuequan.ResetText();
            txtMaBangLai.ResetText();
            mskLuong.ResetText();
            cmbMaXeLai.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dto_TaiXe == null)
            {
                if (BUS_ValidateInputValue.checkInputValue(this))
                {
                    try
                    {
                        dto_TaiXe = new DTO_TaiXe();
                        dto_TaiXe.MaTaiXe = BUS_RandomCodeForPKInDB.genarateCode();
                        commonAssignObject(dto_TaiXe);
                        if (bus_QLTaiXe.themTaiXe(dto_TaiXe))
                        {
                            MessageBox.Show("Thêm thành công tài xế " + dto_TaiXe.MaTaiXe);
                        };
                        Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.TaiXe));
                    }
                    catch (Exception)
                    {
                        dto_TaiXe = null;
                        MessageBox.Show("Thêm mã tài xế thất bại!");
                    }
                }
                else
                {
                    dto_TaiXe = null;
                }
            }
            else
            {
                if (BUS_ValidateInputValue.checkInputValue(this))
                {
                    try
                    {
                        commonAssignObject(dto_TaiXe);
                        if (bus_QLTaiXe.capNhatThongTinTaiXe(dto_TaiXe))
                        {
                            MessageBox.Show("Cập nhật thành công tài xế " + dto_TaiXe.MaTaiXe);
                            Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.TaiXe));
                        };
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cập nhật tài xế thất bại!");
                    }
                }
            }
        }
        private void commonAssignObject(DTO_TaiXe dto_TaiXe)
        {
            dto_TaiXe.HoVaTen = txtHoTen.Text;
            dto_TaiXe.NgaySinh = dtBirthday.Value;
            dto_TaiXe.GioiTinh = cmbGioiTinh.Text;
            dto_TaiXe.DiaChi = txtDiaChi.Text;
            dto_TaiXe.QueQuan = txtQuequan.Text;
            dto_TaiXe.NgayBDHopDong = dtNgayBDLam.Value;
            dto_TaiXe.BangLai = txtMaBangLai.Text;
            dto_TaiXe.Luong = int.Parse(mskLuong.Text);
            dto_TaiXe.MaXe = cmbMaXeLai.Text;

        }
    }
}
