using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanLyXeBus.GUI.Add_GUI;
using WF_QuanLyXeBus.BUS;
using WF_QuanLyXeBus.DTO;

namespace WF_QuanLyXeBus.GUI
{
    public partial class frmNhanVien : Form
    {
        private BUS_QLNhanVien bus_QLNhanVien;
        private String codeOfSelectedRow;
        private frmMain parentForm;
        public frmNhanVien()
        {
            InitializeComponent();
            bus_QLNhanVien = new BUS_QLNhanVien();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            DataTable dt = bus_QLNhanVien.layTatCaThongTinTaiKhoan();
            dgvNhanVien.DataSource = dt;
            parentForm = (frmMain)this.ParentForm;
            parentForm.btnNhanVien.Focus();
            txtTimKiem.ResetText();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new frmAddNhanVien());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataTable dt = bus_QLNhanVien.layThongTinTaiKhoanBangCode(codeOfSelectedRow);
            DTO_TaiKhoan dto_TaiKhoan = new DTO_TaiKhoan();
            var rowResult = dt.Rows[0];
            dto_TaiKhoan.MaTaiKhoan = rowResult.Field<String>("MaTaiKhoan");
            dto_TaiKhoan.TenDayDu = rowResult.Field<String>("TenDayDu");
            dto_TaiKhoan.NgayThangNamSinh = rowResult.Field<DateTime>("NgayThangNamSinh");
            dto_TaiKhoan.SoDienThoai = rowResult.Field<String>("SoDienThoai");
            dto_TaiKhoan.Email = rowResult.Field<String>("Email");
            dto_TaiKhoan.ChucVu = rowResult.Field<String>("ChucVu");
            dto_TaiKhoan.TenTaiKhoan = rowResult.Field<String>("TenTaiKhoan");
            dto_TaiKhoan.Matkhau = rowResult.Field<String>("Matkhau");
            Program.SwitchMainForm(new frmAddNhanVien(dto_TaiKhoan));
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            parentForm.btnNhanVien.Focus();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            codeOfSelectedRow = Convert.ToString(dgvNhanVien.Rows[e.RowIndex].Cells[0].Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (bus_QLNhanVien.xoaTaiKhoan(codeOfSelectedRow))
                {
                    MessageBox.Show("Xóa thành công tài khoản " + codeOfSelectedRow);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi, không thể xóa tài khoản " + codeOfSelectedRow);
            }
            finally
            {
                Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.NhanVien));
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //Lay text vua nhap tu txtTimKiem
            string keyWord = txtTimKiem.Text.Insert(txtTimKiem.SelectionStart, e.KeyChar.ToString());
            DataTable dt = bus_QLNhanVien.timKiemNhanVien(keyWord);
            dgvNhanVien.DataSource = dt;
        }
    }
}
