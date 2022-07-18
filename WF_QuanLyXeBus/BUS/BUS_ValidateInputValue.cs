using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_QuanLyXeBus.BUS
{
    class BUS_ValidateInputValue
    {
        //Kiem tra cac TextBox hoac MaskedTextBox cua Form neu con trong thi hien thong bao nhap thieu
        public static bool checkInputValue(Form f)
        {
            foreach (Control c in f.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        MessageBox.Show("Có thông tin bạn nhập còn trống");
                        return false;
                    }
                }
                else if (c is MaskedTextBox)
                {
                    MaskedTextBox mskTextBox = c as MaskedTextBox;
                    if (!mskTextBox.MaskCompleted)
                    {
                        MessageBox.Show("Có thông tin bạn nhập còn trống (cần điền đầy đủ phần gạch dưới)");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
