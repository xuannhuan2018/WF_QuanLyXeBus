using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_QuanLyXeBus.DTO;
using System.Windows.Forms;
using WF_QuanLyXeBus.DAL;

namespace WF_QuanLyXeBus.BAL
{
    partial class BAL_Authentication
    {
        private DAL_Authentication DAL_Auth;
        public BAL_Authentication()
        {
            DAL_Auth = new DAL_Authentication();

        }
        public bool checkLogin(String username, String password)
        {
            return DAL_Auth.checkLoginInforInDB(username, password);
        }
    }
}
