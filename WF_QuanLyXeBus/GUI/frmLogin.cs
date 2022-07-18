using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanLyXeBus.BAL;
using WF_QuanLyXeBus.GUI;

namespace WF_QuanLyXeBus
{
    public partial class frmLogin : Form
    {
        private BAL_Authentication BUS_Auth; 
        public frmLogin()
        {
            InitializeComponent();
            BUS_Auth = new BAL_Authentication();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            String role = BUS_Auth.checkLoginAndGetRole(txtUsername.Text, txtPassword.Text);
            if (role.Equals("quanly"))
            {
                MessageBox.Show("Đăng nhập thành công với chức vụ là quản lý.");
                //this.Hide();
                Program.checkRoleOfUser = true;
                frmMain frmM = new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.TuyenXe);
                //frmM.ShowDialog();
                Program.SwitchMainForm(new frmMain(true, frmMain.TypeManager.TuyenXe));
                //this.Close();
                                        
            }
            else if (role.Equals("nhanvien"))
            {
                MessageBox.Show("Đăng nhập thành công với chức vụ là nhân viên.");
                //frmMain frmM = new frmMain(false);
                //frmM.ShowDialog();
                Program.checkRoleOfUser = false;
                Program.SwitchMainForm(new frmMain(Program.checkRoleOfUser, frmMain.TypeManager.TuyenXe));               
            }
            else
            {
                MessageBox.Show("Sai thông tin tài khoản hoặc mật khẩu.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
