using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_QuanLyXeBus.DTO;
using System.Windows.Forms;
using WF_QuanLyXeBus.DAL;

namespace WF_QuanLyXeBus.BUS
{
    partial class BUS_Authentication
    {
        private DAL_Authentication dal_Auth;
        public BUS_Authentication()
        {
            dal_Auth = new DAL_Authentication();

        }
        public String checkLoginAndGetRole(String username, String password)
        {
            return dal_Auth.checkLoginAndGetRoleInDB(username, password);
        }
    }
}
