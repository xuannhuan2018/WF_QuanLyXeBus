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
using WF_QuanLyXeBus.GUI.Add_GUI;
using WF_QuanLyXeBus.DTO;
using System.Globalization;

namespace WF_QuanLyXeBus.GUI
{
    public partial class frmMain : Form
    {
        private bool btnNhanVienEnable;
        private BUS_QLTuyenXe bus_QLTuyenXe;
        private String codeOfSelectedRow;
        private TypeManager typeManager;
        private Form currentFormChild;
        public enum TypeManager { DonVi, TuyenXe, Xe, TaiXe, NhanVien};
       

        public frmMain()
        {
            InitializeComponent();
            bus_QLTuyenXe = new BUS_QLTuyenXe();
        }
        public frmMain(bool btnNhanVienEnable, TypeManager typeManager)
        {
            InitializeComponent();
            bus_QLTuyenXe = new BUS_QLTuyenXe();
            this.btnNhanVienEnable = btnNhanVienEnable;
            this.typeManager = typeManager;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            loadData(typeManager);
        }
        private void loadData(TypeManager typeManager)
        {
            switch (typeManager)
            {
                case TypeManager.TuyenXe:
                    btnNhanVien.Enabled = btnNhanVienEnable;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    DataTable dt = bus_QLTuyenXe.layTatCaThongTinTuyenXe();
                    dgvTuyenXe.DataSource = dt;
                    btnTuyenXe.Select();
                    txtTimKiem.ResetText();
                    foreach (Control p in plbody.Controls)
                    {
                        if (p is Form)
                        {
                            plbody.Controls.Remove(p);
                        }
                    }
                    break;
                case TypeManager.DonVi:
                    OpenChildForm(new frmDonVi());
                    btnDonVi.Select();
                    break;
                case TypeManager.Xe:
                    OpenChildForm(new frmXe());
                    btnXe.Select();
                    break;
                case TypeManager.TaiXe:
                    OpenChildForm(new frmTaiXe());
                    btnTaiXe.Select();
                    break;
                case TypeManager.NhanVien:
                    OpenChildForm(new frmNhanVien());
                    btnNhanVien.Select();
                    break;
            }
        }
        
        private void btnTuyenXe_Click(object sender, EventArgs e)
        {
            loadData(TypeManager.TuyenXe);
            plbody.Visible = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new frmAddTuyenXe());
        
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataTable dt = bus_QLTuyenXe.layThongTinTuyenXeBangCode(codeOfSelectedRow);
            DTO_TuyenXe dto_TuyenXe = new DTO_TuyenXe();
            var rowResult = dt.Rows[0];
            dto_TuyenXe.MaTuyen = rowResult.Field<String>("MaTuyen");
            dto_TuyenXe.MaDonVi = rowResult.Field<String>("MaDonVi");
            dto_TuyenXe.TenTuyen = rowResult.Field<String>("TenTuyen");
            dto_TuyenXe.ThoiGianBatDau = Convert.ToString(rowResult.Field<TimeSpan>("ThoiGianBatDau"));
            dto_TuyenXe.ThoiGianKetThuc = Convert.ToString(rowResult.Field<TimeSpan>("ThoiGianKetThuc"));
            dto_TuyenXe.ThoiGianGianCach = rowResult.Field<int>("ThoiGianGianCach");
            dto_TuyenXe.LoTrinhLuotDi = rowResult.Field<String>("LoTrinhLuotDi");
            dto_TuyenXe.LoTrinhLuotVe = rowResult.Field<String>("LoTrinhLuotVe");
            dto_TuyenXe.LoaiTuyen = rowResult.Field<String>("LoaiTuyen");
            Program.SwitchMainForm(new frmAddTuyenXe(dto_TuyenXe));
        }

        private void dgvTuyenXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnTuyenXe.Select();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            codeOfSelectedRow = Convert.ToString(dgvTuyenXe.Rows[e.RowIndex].Cells[0].Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (bus_QLTuyenXe.xoaTuyenXe(codeOfSelectedRow))
                {
                    MessageBox.Show("Xóa thành công tuyến " + codeOfSelectedRow);
                }
                else
                {
                    MessageBox.Show("Lỗi, không thể xóa tuyến " + codeOfSelectedRow + " do mã tuyến còn tồn tại ở bảng quản lí Xe");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi, không thể xóa tuyến " + codeOfSelectedRow);
            }
            finally
            {
                loadData(TypeManager.TuyenXe);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            loadData(TypeManager.TuyenXe);
        }

        private void btnDonVi_Click(object sender, EventArgs e)
        {
            loadData(TypeManager.DonVi);

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnXe_Click(object sender, EventArgs e)
        {
            loadData(TypeManager.Xe);
        }

        private void btnTaiXe_Click(object sender, EventArgs e)
        {
            loadData(TypeManager.TaiXe);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            loadData(TypeManager.NhanVien);
        }
        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            plbody.Controls.Add(childForm);
            plbody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new frmLogin());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            //Lay text vua nhap tu txtTimKiem
            string keyWord = txtTimKiem.Text.Insert(txtTimKiem.SelectionStart, e.KeyChar.ToString());
            DataTable dt = bus_QLTuyenXe.timKiemTuyenXe(keyWord);
            dgvTuyenXe.DataSource = dt;
        }
    }
}
