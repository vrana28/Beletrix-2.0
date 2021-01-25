using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Domain;
using FrmLogin.Controllers;
using FrmLogin.Helpers;

namespace FrmLogin.FrmGetAll.ChangeOrDelete
{
    public partial class FrmClientChange : Form
    {
        private readonly ClientsController clientsController;
        public FrmClientChange(Controllers.ClientsController clientsController, DataGridViewRow row)
        {
            this.clientsController = clientsController;
            InitializeComponent();
            Row = row;
        }

        public DataGridViewRow Row{ get; set; }
        public TextBox TxtName { get => txtName; }
        public TextBox TxtPlace { get => txtPlace; }
        public TextBox TxtPib { get => txtPIB; }
        public TextBox TxtTelephone { get => txtTelephone; }
        public TextBox TxtEmail { get => txtEmail; }

        private void FrmClientChange_Load(object sender, EventArgs e)
        {
            clientsController.ClientChangeLoad(this,Row);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            clientsController.Update(this, Row);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            clientsController.Delete(this,Row);
        }
    }
}
