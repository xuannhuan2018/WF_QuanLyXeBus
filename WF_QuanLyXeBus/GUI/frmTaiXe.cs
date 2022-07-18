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
using WF_QuanLyXeBus.GUI.Add_GUI;

namespace WF_QuanLyXeBus.GUI
{
    public partial class frmTaiXe : Form
    {
        private BUS_QLTaiXe bus_QLTaiXe;
        private String codeOfSelectedRow;
        private frmMain parentForm;
        public frmTaiXe()
        {
            InitializeComponent();
            bus_QLTaiXe = new BUS_QLTaiXe();

        }

        private void frmTaiXe_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            DataTable dt = bus_QLTaiXe.layTatCaThongTinTaiXe();
            dgvTaiXe.DataSource = dt;
            parentForm = (frmMain)this.ParentForm;
            parentForm.btnTaiXe.Focus();
            txtTimKiem.ResetText();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new frmAddTaiXe());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataTable dt = bus_QLTaiXe.layThongTinTaiXeBangCode(codeOfSelectedRow);
            DTO_TaiXe dto_TaiXe = new DTO_TaiXe();
            var rowResult = dt.Rows[0];
            dto_TaiXe.MaTaiXe = rowResult.Field<String>("MaTX");
            dto_TaiXe.HoVaTen = rowResult.Field<String>("HoVaTen");
            dto_TaiXe.GioiTinh = rowResult.Field<String>("GioiTinh");
            dto_TaiXe.NgaySinh = rowResult.Field<DateTime>("NgaySinh");
            dto_TaiXe.DiaChi = rowResult.Field<String>("DiaChi");
            dto_TaiXe.QueQuan = rowResult.Field<String>("QueQuan");
            dto_TaiXe.NgayBDHopDong = rowResult.Field<DateTime>("NgayBDHopDong");
            dto_TaiXe.Luong = rowResult.Field<int>("Luong");
            dto_TaiXe.BangLai = rowResult.Field<String>("BangLai");
            dto_TaiXe.MaXe = rowResult.Field<String>("MaXe");
            Program.SwitchMainForm(new frmAddTaiXe(dto_TaiXe));
        }

        private void dgvTaiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            parentForm.btnTaiXe.Focus();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            codeOfSelectedRow = Convert.ToString(dgvTaiXe.Rows[e.RowIndex].Cells[0].Value);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (bus_QLTaiXe.xoaTaiXe(codeOfSelectedRow))
                {
                    MessageBox.Show("Xóa thành công tài xế " + codeOfSelectedRow);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi, không thể xóa tài xế " + codeOfSelectedRow);
            }
            finally
            {
                Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.TaiXe));
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //Lay text vua nhap tu txtTimKiem
            string keyWord = txtTimKiem.Text.Insert(txtTimKiem.SelectionStart, e.KeyChar.ToString());
            DataTable dt = bus_QLTaiXe.timKiemTaiXe(keyWord);
            dgvTaiXe.DataSource = dt;
        }
    }
}
