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
            if(BUS_Auth.checkLogin(txtUsername.Text, txtPassword.Text))
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Fail");
            }
          
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
