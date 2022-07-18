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
    public partial class frmXe : Form
    {
        private BUS_QLXe bus_QLXe;
        private String codeOfSelectedRow;
        private frmMain parentForm;
        public frmXe()
        {
            InitializeComponent();
            bus_QLXe = new BUS_QLXe();
        }

        private void frmXe_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            DataTable dt = bus_QLXe.layTatCaThongTinXe();
            dgvXe.DataSource = dt;
            parentForm = (frmMain)this.ParentForm;
            parentForm.btnXe.Focus();
            txtTimKiem.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new frmAddXe());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataTable dt = bus_QLXe.layThongTinXeBangCode(codeOfSelectedRow);
            DTO_Xe dto_Xe = new DTO_Xe();
            var rowResult = dt.Rows[0];
            dto_Xe.MaXe = rowResult.Field<String>("MaXe");
            dto_Xe.BienSo = rowResult.Field<String>("BienSo");
            dto_Xe.LoaiXe = rowResult.Field<String>("LoaiXe");
            dto_Xe.SoGhe = rowResult.Field<int>("SoGhe");
            dto_Xe.CongSuat = rowResult.Field<int>("CongSuat");
            dto_Xe.NgaySanXuat = rowResult.Field<DateTime>("NgaySX");
            dto_Xe.ChuKiBaoHanh = rowResult.Field<int>("ChuKiBaoHanh");
            dto_Xe.MaTuyen = rowResult.Field<String>("MaTuyen");
            Program.SwitchMainForm(new frmAddXe(dto_Xe));
        }

        private void dgvXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            parentForm.btnXe.Focus();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            codeOfSelectedRow = Convert.ToString(dgvXe.Rows[e.RowIndex].Cells[0].Value);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (bus_QLXe.xoaXe(codeOfSelectedRow))
                {
                    MessageBox.Show("Xóa thành công xe " + codeOfSelectedRow);
                }
                else
                {
                    MessageBox.Show("Lỗi, không thể xóa " + codeOfSelectedRow + "do mã xe này còn tồn tại ở bảng quản lí tài xế");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi, không thể xóa xe " + codeOfSelectedRow);
            }
            finally
            {
                Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.Xe));
            }
        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //Lay text vua nhap tu txtTimKiem
            string keyWord = txtTimKiem.Text.Insert(txtTimKiem.SelectionStart, e.KeyChar.ToString());
            DataTable dt = bus_QLXe.timKiemXe(keyWord);
            dgvXe.DataSource = dt;
        }
    }
}
