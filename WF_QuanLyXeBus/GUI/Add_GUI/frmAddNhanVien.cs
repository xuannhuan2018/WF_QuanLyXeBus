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
    public partial class frmAddNhanVien : Form
    {
        private BUS_QLNhanVien bus_QLNhanVien;
        private DTO_TaiKhoan dto_TaiKhoan;
        public frmAddNhanVien()
        {
            InitializeComponent();
            bus_QLNhanVien = new BUS_QLNhanVien();
            loadData();
        }
        public frmAddNhanVien(DTO_TaiKhoan dto_TaiKhoan)
        {
            InitializeComponent();
            bus_QLNhanVien = new BUS_QLNhanVien();
            this.dto_TaiKhoan = dto_TaiKhoan;
        }
        private void frmAddNhanVien_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            if (dto_TaiKhoan == null)
            {
                this.Text = "Thêm tài khoản";
            }
            else
            {
                this.Text = "Chỉnh sửa tài khoản " + dto_TaiKhoan.MaTaiKhoan;
                txtHoTen.Text = dto_TaiKhoan.TenDayDu;
                dtBirthday.Value = dto_TaiKhoan.NgayThangNamSinh;
                mskSDT.Text = dto_TaiKhoan.SoDienThoai;
                txtEmail.Text = dto_TaiKhoan.Email;
                cmbChucVu.Text = dto_TaiKhoan.ChucVu;
                txtTenTaiKhoan.Text = dto_TaiKhoan.TenTaiKhoan;
                txtMatKhau.Text = dto_TaiKhoan.Matkhau;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dto_TaiKhoan == null)
            {
                if (BUS_ValidateInputValue.checkInputValue(this))
                {
                    try
                    {
                        dto_TaiKhoan = new DTO_TaiKhoan();
                        dto_TaiKhoan.MaTaiKhoan = BUS_RandomCodeForPKInDB.genarateCode();
                        commonAssignObject(dto_TaiKhoan);
                        if (bus_QLNhanVien.themTaiKhoan(dto_TaiKhoan))
                        {
                            MessageBox.Show("Thêm thành công mã tài khoản " + dto_TaiKhoan.MaTaiKhoan);
                        };
                        Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.NhanVien));
                    }
                    catch (Exception)
                    {
                        dto_TaiKhoan = null;
                        MessageBox.Show("Thêm tài khoản thất bại!");
                    }
                }
                else
                {
                    dto_TaiKhoan = null;
                }
            }
            else
            {
                if (BUS_ValidateInputValue.checkInputValue(this))
                {
                    try
                    {
                        commonAssignObject(dto_TaiKhoan);
                        if (bus_QLNhanVien.capNhatThongTinTaiKhoan(dto_TaiKhoan))
                        {
                            MessageBox.Show("Cập nhật thành công tài khoản " + dto_TaiKhoan.MaTaiKhoan);
                            Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.NhanVien));
                        };
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cập nhật thất bại!");
                    }
                }
            }
        }
        private void commonAssignObject(DTO_TaiKhoan dto_TaiKhoan)
        {
            dto_TaiKhoan.TenDayDu = txtHoTen.Text;
            dto_TaiKhoan.NgayThangNamSinh = dtBirthday.Value;
            dto_TaiKhoan.SoDienThoai = mskSDT.Text;
            dto_TaiKhoan.Email = txtEmail.Text;
            dto_TaiKhoan.ChucVu = cmbChucVu.Text;
            dto_TaiKhoan.TenTaiKhoan = txtTenTaiKhoan.Text;
            dto_TaiKhoan.Matkhau = txtMatKhau.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.NhanVien));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtHoTen.ResetText();
            mskSDT.ResetText();
            txtEmail.ResetText();
            cmbChucVu.ResetText();
            txtTenTaiKhoan.ResetText();
            txtMatKhau.ResetText();
        }
    }
}
