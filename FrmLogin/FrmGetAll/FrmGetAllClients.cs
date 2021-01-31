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

namespace FrmLogin.FrmGetAll
{
    public partial class FrmGetAllClients : Form
    {
        private ClientsController clientsController;
        public FrmGetAllClients(Controllers.ClientsController clientsController)
        {
            this.clientsController = clientsController;
            InitializeComponent();
            clientsController.InitdatagridView(this);
        }

        public DataGridView DGVClients { get => dgvClients; }
        private void dgvClients_DoubleClick(object sender, EventArgs e)
        {
            clientsController.DoubleClickDataGridView(this);
        }
        public override void Refresh()
        {
            clientsController.GetAllClients(this);
        }
    }
}
