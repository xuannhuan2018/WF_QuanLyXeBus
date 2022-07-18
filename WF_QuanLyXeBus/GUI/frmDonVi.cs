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
    public partial class frmDonVi : Form
    {
        private BUS_QLDonVi bus_QLDonVi;
        private String codeOfSelectedRow;
        private frmMain parentForm;
        
        public frmDonVi()
        {
            InitializeComponent();
            bus_QLDonVi = new BUS_QLDonVi();

        }
        private void frmDonVi_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            DataTable dt = bus_QLDonVi.layTatCaThongTinDonVi();
            dgvDonVi.DataSource = dt;
            parentForm = (frmMain)this.ParentForm;
            parentForm.btnDonVi.Focus();
            txtTimKiem.ResetText();

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new frmAddDonVi());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataTable dt = bus_QLDonVi.layThongTinDonViByCode(codeOfSelectedRow);
            DTO_DonViXe dto_DonVi = new DTO_DonViXe();
            var rowResult = dt.Rows[0];
            dto_DonVi.MaDonVi = rowResult.Field<String>("MaDonVi");
            dto_DonVi.TenDonVi = rowResult.Field<String>("TenDonVi");
            dto_DonVi.DiaChi = rowResult.Field<String>("DiaChi");
            dto_DonVi.SoDienThoai = rowResult.Field<String>("SoDienThoai");
            dto_DonVi.Email = rowResult.Field<String>("Email");
            Program.SwitchMainForm(new frmAddDonVi(dto_DonVi));
        }

        private void dgvDonVi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            parentForm.btnDonVi.Focus();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            codeOfSelectedRow = Convert.ToString(dgvDonVi.Rows[e.RowIndex].Cells[0].Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (bus_QLDonVi.xoaDonVi(codeOfSelectedRow))
                {
                    MessageBox.Show("Xóa thành công đơn vị " + codeOfSelectedRow);
                }
                else
                {
                    MessageBox.Show("Lỗi, không thể xóa " + codeOfSelectedRow + "do mã đơn vị còn tồn tại ở bảng quản lí tuyến xe");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi, không thể xóa đơn vị " + codeOfSelectedRow);
            }
            finally
            {
                Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.DonVi));
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //Lay text vua nhap tu txtTimKiem
            string keyWord = txtTimKiem.Text.Insert(txtTimKiem.SelectionStart, e.KeyChar.ToString());
            DataTable dt = bus_QLDonVi.timKiemDonVi(keyWord);
            dgvDonVi.DataSource = dt;
        }
    }
}
