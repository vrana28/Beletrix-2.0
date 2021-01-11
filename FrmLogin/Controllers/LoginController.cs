using Domain;
using FrmLogin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.Controllers
{
    public class LoginController
    {
        internal void Connect()
        {
            try
            {
                Communication.Communication.Instance.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom povezivvanja sa serverom");
                Environment.Exit(0);
            }
        }

        internal void Login(TextBox txtUsername, TextBox txtPassword, FrmLogin frmLogin)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(txtUsername) | UserControlHelpers.IsNullOrWhiteSpace(txtPassword)) {
                return;
            }

            try
            {
                Storekeeper s = Communication.Communication.Instance.Login(txtUsername.Text, txtPassword.Text);
                MainCoordinator.Instance.Storekeeper = s;
                MessageBox.Show($"Korisnik {s.Name} {s.LastName} se uspesno prijavio");
                MainCoordinator.Instance.OpenMainForm(MainCoordinator.Instance.Storekeeper);
                frmLogin.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
