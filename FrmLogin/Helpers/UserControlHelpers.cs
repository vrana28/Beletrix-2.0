using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.Helpers
{
    class UserControlHelpers
    {
        public static bool IsNullOrWhiteSpace(TextBox txt) {
            if (string.IsNullOrEmpty(txt.Text))
            {
                txt.BackColor = Color.LightCoral;
                return true;
            }
            else
            {
                txt.BackColor = Color.White;
                return false;
            }
        }

        public static bool IntValidation(TextBox txt) {
            if (!int.TryParse(txt.Text, out _)) {
                txt.BackColor = Color.LightCoral;
                return false;
            }
            else{
                txt.BackColor = Color.White;
                return true;
            }
        }

        public static void ResetTxt(TextBox txt) {
            txt.Text =null;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidNumber(string broj) {

            if (int.TryParse(broj, out _)) {
                return true;
            }
            return false;
        }

        public static bool IsValidDouble(string broj) {
            if (broj != null) return true;
            
                if (double.TryParse(broj, out _))
                {
                    return true;
                }
            
            return false;
        }

        public static RadioButton CkeckedButtons(List<RadioButton> buttons) {

            foreach (RadioButton r in buttons) {
                if (r.Checked) {
                    return r;
                }
            }
            return null;
        }

    }
}
