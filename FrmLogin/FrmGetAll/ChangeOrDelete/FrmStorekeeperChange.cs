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
    public partial class FrmStorekeeperChange : Form
    {
        private readonly StorekeeperController storekeeperController;
        public FrmStorekeeperChange(DataGridViewRow r, Controllers.StorekeeperController storekeeperController)
        {
            this.storekeeperController = storekeeperController;
            InitializeComponent();
            Row = r;
        }

        public DataGridViewRow Row { get; set; }
        public TextBox TxtName{ get => txtName; }
        public TextBox TxtLastName { get => txtLastName; }
        public TextBox TxtUsername { get => txtUsername; }
        public TextBox TxtPassword { get => txtPassword; }

        private void FrmStorekeeperChange_Load(object sender, EventArgs e)
        {
            storekeeperController.InitTextBoxes(this, Row);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            storekeeperController.Update(this,Row);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            storekeeperController.Delete(this, Row);
        }
    }
}
