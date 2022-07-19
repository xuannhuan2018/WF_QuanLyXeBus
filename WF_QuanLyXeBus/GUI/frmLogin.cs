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
using WF_QuanLyXeBus.GUI;

namespace WF_QuanLyXeBus
{
    public partial class frmLogin : Form
    {
        private BUS_Authentication bus_Auth; 
        public frmLogin()
        {
            InitializeComponent();
            bus_Auth = new BUS_Authentication();
        }

        private void btnDangnhap_Click_1(object sender, EventArgs e)
        {

            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                String role = bus_Auth.checkLoginAndGetRole(txtUsername.Text, txtPassword.Text);
                if (role == null)
                {
                    MessageBox.Show("Sai thông tin tài khoản hoặc mật khẩu.");
                }
                else if (role.Equals("nhanvien"))
                {
                    MessageBox.Show("Đăng nhập thành công với chức vụ là nhân viên.");
                    //frmMain frmM = new frmMain(false);
                    //frmM.ShowDialog();
                    Program.checkRoleOfUser = false;
                    Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.TuyenXe));
                }
                else if(role.Equals("quanly"))
                {
                    MessageBox.Show("Đăng nhập thành công với chức vụ là quản lý.");
                    //this.Hide();
                    Program.checkRoleOfUser = true;
                    frmMain frmM = new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.TuyenXe);
                    //frmM.ShowDialog();
                    Program.SwitchMainForm(new frmMain(true, frmMain.TypeManager.TuyenXe));
                    //this.Close();
                }
            }
            else
            {
                MessageBox.Show("Nhập thiếu thông tin");
            }
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            btnDangnhap.Select();
        }
    }
}
