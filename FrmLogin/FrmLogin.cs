using FrmLogin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Controller;

namespace FrmLogin
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            txtUsername.Text = "admin";
            txtPassword.Text = "admin";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ( UserControlHelpers.IsNullOrWhiteSpace(txtUsername) | UserControlHelpers.IsNullOrWhiteSpace(txtPassword)) {
                return;
            }

            Storekeeper st = new Storekeeper
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            try
            {
                Storekeeper s = Controler.Instance.Login(st);
                MessageBox.Show($"Uspesno ste se prijavili {s.Name} {s.LastName}");
                MainCoordinator.Instance.OpenMainForm(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show("User not exist!");
                UserControlHelpers.ResetTxt(txtUsername);
                UserControlHelpers.ResetTxt(txtPassword);
                MessageBox.Show(ex.Message);
            }

        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
