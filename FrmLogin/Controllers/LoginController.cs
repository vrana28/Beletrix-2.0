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
        public static Storekeeper Storekeeper{ get; set; }
        internal bool Connect()
        {
            try
            {
                Communication.Communication.Instance.Connect();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom povezivanja sa serverom");
                return false;
            }
        }

        internal void Login(TextBox txtUsername, TextBox txtPassword, FrmLogin frmLogin)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(txtUsername) | UserControlHelpers.IsNullOrWhiteSpace(txtPassword)) {
                return;
            }

            try
            {
                Storekeeper = Communication.Communication.Instance.Login(txtUsername.Text, txtPassword.Text);
                if (Storekeeper == null) {
                    MessageBox.Show("Korisnik ne postoji");
                    return;
                }
                MainCoordinator.Instance.Storekeeper = Storekeeper;
                MessageBox.Show($"Korisnik {Storekeeper.Name} {Storekeeper.LastName} se uspesno prijavio");
                MainCoordinator.Instance.OpenMainForm(MainCoordinator.Instance.Storekeeper);
                frmLogin.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        internal void Login(FrmLogin frmLogin)
        {
            if (Connect())
            {
               Login(frmLogin.TxtUsername, frmLogin.TxtPassword, frmLogin);
            }
        }
    }
}
