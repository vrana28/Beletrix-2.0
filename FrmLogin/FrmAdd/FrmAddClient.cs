
using Domain;
using FrmLogin.Controllers;
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

namespace FrmLogin
{
    public partial class FrmAddClient : Form
    {
        private readonly ClientsController clientsController;
        public FrmAddClient(Controllers.ClientsController clientsController)
        {
            this.clientsController = clientsController;
            InitializeComponent();
        }
        public TextBox TxtName{ get => txtName; }
        public TextBox TxtPlace{ get => txtPlace; }
        public TextBox TxtPib{ get => txtPIB; }
        public TextBox TxtTelephone { get => txtTelephone; }
        public TextBox TxtEmail { get => txtEmail; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            clientsController.Save(this);
        }
    }
}
