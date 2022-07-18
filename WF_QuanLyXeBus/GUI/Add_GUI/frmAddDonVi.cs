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
    public partial class frmAddDonVi : Form
    {
        private BUS_QLDonVi bus_QLDonVi;
        private DTO_DonViXe dto_DonVi;
        public frmAddDonVi()
        {
            InitializeComponent();
            bus_QLDonVi = new BUS_QLDonVi();
        }
        public frmAddDonVi(DTO_DonViXe dto_DonVi)
        {
            InitializeComponent();
            bus_QLDonVi = new BUS_QLDonVi();
            this.dto_DonVi = dto_DonVi;
        }
        private void frmAddDonVi_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            if (dto_DonVi == null)
            {
                this.Text = "Thêm đơn vị";
            }
            else
            {
                this.Text = "Chỉnh sửa đơn vị " + dto_DonVi.MaDonVi;
                txtTenDonVi.Text = dto_DonVi.TenDonVi;
                txtDiaChi.Text = dto_DonVi.DiaChi;
                mskSDT.Text = dto_DonVi.SoDienThoai;
                txtEmail.Text = dto_DonVi.Email;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dto_DonVi == null)
            {
                if (BUS_ValidateInputValue.checkInputValue(this))
                {
                    try
                    {
                        dto_DonVi = new DTO_DonViXe();
                        dto_DonVi.MaDonVi = BUS_RandomCodeForPKInDB.genarateCode();
                        commonAssignObject(dto_DonVi);
                        if (bus_QLDonVi.themDonVi(dto_DonVi))
                        {
                            MessageBox.Show("Thêm thành công mã đơn vị " + dto_DonVi.MaDonVi);
                        };
                        Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.DonVi));
                    }
                    catch (Exception)
                    {
                        dto_DonVi = null;
                        MessageBox.Show("Thêm đơn vị thất bại!");
                    }
                }
                else
                {
                    dto_DonVi = null;
                }
            }
            else
            {
                if (BUS_ValidateInputValue.checkInputValue(this))
                {
                    try
                    {
                        commonAssignObject(dto_DonVi);
                        if (bus_QLDonVi.capNhatThongTinDonVi(dto_DonVi))
                        {
                            MessageBox.Show("Cập nhật thành công đơn vị " + dto_DonVi.MaDonVi);
                            Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.DonVi));
                        };
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Cập nhật thất bại!");
                    }
                }
            }
        }
        private void commonAssignObject(DTO_DonViXe dto_DonVi)
        {
            dto_DonVi.TenDonVi = txtTenDonVi.Text;
            dto_DonVi.DiaChi = txtDiaChi.Text;
            dto_DonVi.SoDienThoai = mskSDT.Text;
            dto_DonVi.Email = txtEmail.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.DonVi));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtTenDonVi.ResetText();
            txtDiaChi.ResetText();
            mskSDT.ResetText();
            txtEmail.ResetText();
        }
    }
}
