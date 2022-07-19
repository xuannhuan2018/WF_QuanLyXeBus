using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanLyXeBus.GUI;
using WF_QuanLyXeBus.DTO;
using WF_QuanLyXeBus.BUS;
using System.Globalization;

namespace WF_QuanLyXeBus.GUI.Add_GUI
{
    public partial class frmAddTuyenXe : Form
    {
        private BUS_QLTuyenXe bus_QLTuyenXe;
        private BUS_QLDonVi bus_QLDonVi;
        private DTO_TuyenXe dto_TuyenXe;
        public frmAddTuyenXe()
        {
            InitializeComponent();
            bus_QLTuyenXe = new BUS_QLTuyenXe();
            bus_QLDonVi = new BUS_QLDonVi();
        }
        public frmAddTuyenXe(DTO_TuyenXe dto_TuyenXe)
        {
            InitializeComponent();
            bus_QLTuyenXe = new BUS_QLTuyenXe();
            bus_QLDonVi = new BUS_QLDonVi();
            this.dto_TuyenXe = dto_TuyenXe;
        }
        private void frmAddTuyenXe_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            //Load danh sach Ma Don Vi den combobox Ma Don Vi
            foreach (DataRow dr in bus_QLDonVi.layDanhSachMaDonVi().Rows)
            {
                cmbMaDV.Items.Add(dr.Field<String>("MaDonVi"));
            }
            if (dto_TuyenXe == null)
            {
                this.Text = "Thêm Tuyến";
            }
            else
            {
                this.Text = "Chỉnh sửa tuyến " + dto_TuyenXe.MaTuyen;
                cmbMaDV.Text = dto_TuyenXe.MaDonVi;
                txtTenTuyen.Text = dto_TuyenXe.TenTuyen;
                mskTgBatDau.Text = dto_TuyenXe.ThoiGianBatDau;
                mskTgKetThuc.Text = dto_TuyenXe.ThoiGianKetThuc;
                mskTgGianCach.Text = Convert.ToString(dto_TuyenXe.ThoiGianGianCach);
                txtLuotDi.Text = dto_TuyenXe.LoTrinhLuotDi;
                txtLuotVe.Text = dto_TuyenXe.LoTrinhLuotVe;
                cmbLoaiTuyen.Text = dto_TuyenXe.LoaiTuyen;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.TuyenXe));
        }

        private void button1_Click(object sender, EventArgs e)
        {        
            //Doi tuong DTO truyen vao la rong thi co nghia la ta them du lieu vao DB
            if (dto_TuyenXe == null)
            {
                if (BUS_ValidateInputValue.checkInputValue(this))
                {
                    try
                    {
                        dto_TuyenXe = new DTO_TuyenXe();
                        dto_TuyenXe.MaTuyen = BUS_RandomCodeForPKInDB.genarateCode();
                        commonAssignObject(dto_TuyenXe);
                        if (bus_QLTuyenXe.themTuyenXe(dto_TuyenXe))
                        {
                            MessageBox.Show("Thêm thành công mã tuyến " + dto_TuyenXe.MaTuyen);
                        };
                        Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.TuyenXe));
                    }
                    catch (Exception)
                    {
                        dto_TuyenXe = null;
                        MessageBox.Show("Thêm tuyến thất bại do bạn nhập khung giờ sai quy định (MAX: 23:59:59 hoặc còn bị trống)");
                    }
                }
                else
                {
                    dto_TuyenXe = null;
                }
            }
            //Doi tuong DTO truyen vao khong rong co nghia la ta chinh sua doi tuong, thay doi du lieu cua no tren DB
            else
            {
                if (BUS_ValidateInputValue.checkInputValue(this))
                {
                    try
                    {
                        commonAssignObject(dto_TuyenXe);
                        if (bus_QLTuyenXe.capNhatThongTinTuyenXe(dto_TuyenXe))
                        {
                            MessageBox.Show("Cập nhật thành công mã tuyến " + dto_TuyenXe.MaTuyen);
                            Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.TuyenXe));
                        };
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cập nhật thất bại mã tuyến do bạn nhập khung giờ sai quy định (MAX: 23:59:59 hoặc còn bị trống)");
                    }
                }
            }

        }
        //Ham dung chung de gan cac thuoc tinh cua doi tuong
        private void commonAssignObject(DTO_TuyenXe dto_TuyenXe)
        {
            dto_TuyenXe.MaDonVi = cmbMaDV.Text;
            dto_TuyenXe.TenTuyen = txtTenTuyen.Text;
            dto_TuyenXe.ThoiGianBatDau = mskTgBatDau.Text;
            dto_TuyenXe.ThoiGianKetThuc = mskTgKetThuc.Text;
            dto_TuyenXe.ThoiGianGianCach = int.Parse(mskTgGianCach.Text.Substring(0, 2));
            dto_TuyenXe.LoTrinhLuotDi = txtLuotDi.Text;
            dto_TuyenXe.LoTrinhLuotVe = txtLuotVe.Text;
            dto_TuyenXe.LoaiTuyen = cmbLoaiTuyen.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtTenTuyen.ResetText();
            mskTgBatDau.ResetText();
            mskTgKetThuc.ResetText();
            mskTgGianCach.ResetText();
            txtLuotDi.ResetText();
            txtLuotVe.ResetText();
        }

        private void txtLuotVe_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
