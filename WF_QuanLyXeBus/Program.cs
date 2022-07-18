using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_QuanLyXeBus.GUI;

namespace WF_QuanLyXeBus
{
    static class Program
    {
        public static ApplicationContext AppContext { get; private set; }
        //Value of checkRoleOfUser equals true is admin, false is staff
        public static bool checkRoleOfUser { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());
            Program.AppContext = new ApplicationContext(new frmLogin());
            Application.Run(AppContext);
        }
        public static void SwitchMainForm(Form newForm)
        {
            var oldMainForm = AppContext.MainForm;
            AppContext.MainForm = newForm;
            oldMainForm?.Close();
            newForm.Show();
        }
    }
}
