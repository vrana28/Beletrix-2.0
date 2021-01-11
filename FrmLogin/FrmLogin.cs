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
using FrmLogin.Controllers;

namespace FrmLogin
{
    public partial class FrmLogin : Form
    {
        private LoginController loginController;
        public FrmLogin(Controllers.LoginController loginController)
        {
            InitializeComponent();
            this.loginController = loginController;
            txtUsername.Text = "admin";
            txtPassword.Text = "admin";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            loginController.Connect();
            loginController.Login(txtUsername, txtPassword, this);
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
