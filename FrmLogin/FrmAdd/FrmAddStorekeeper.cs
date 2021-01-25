using Controller;
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
using FrmLogin.Controllers;

namespace FrmLogin
{
    public partial class FrmAddStorekeeper : Form
    {
        private readonly StorekeeperController storekeeperController;
        public FrmAddStorekeeper(StorekeeperController storekeeperController)
        {
            this.storekeeperController = storekeeperController;
            InitializeComponent();
        }

        public TextBox TxtName { get => txtName; }
        public TextBox TxtLastName { get => txtLastName; }
        public TextBox TxtUsername { get => txtUsername; }
        public TextBox TxtPassword { get => txtPassword; }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            storekeeperController.Save(this);
        }
    }
}
