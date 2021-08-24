
using Domain;
using FrmLogin.Controllers;
using FrmLogin.FrmGetAll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.FrmEnter
{
    public partial class FrmEnterClient : Form
    {
        private readonly ClientsController clientController;

        public int Signal { get; set; }
        public FrmEntrance frmEntrance{ get; set; }
        public FrmGetAllEntrances frmGetAllEntrances { get; set; }
        public FrmFind frmFind{ get; set; }
        public FrmExit frmExit { get; set; }
        public DataGridView DGVClientsToEnter { get => dgvClients; }
        public FrmEnterClient(Controllers.ClientsController clientsController)
        {
            this.clientController = clientsController;
            InitializeComponent();
            clientController.InitEnterDataGridView(this);
        }

        public FrmEnterClient(FrmEntrance frmEntrance, ClientsController clientsController)
        {
            this.frmEntrance = frmEntrance;
            this.clientController = clientsController;
            InitializeComponent();
            clientController.InitEnterDataGridView(this);
            Signal = 1;
        }

        public FrmEnterClient(FrmGetAllEntrances frmGetAllEntrance, ClientsController clientsController)
        {
            this.frmGetAllEntrances = frmGetAllEntrance;
            this.clientController = clientsController;
            InitializeComponent();
            clientController.InitEnterDataGridView(this);
            Signal = 4;
        }

        public FrmEnterClient(FrmFind frmFind, ClientsController clientsController)
        {
            this.frmFind = frmFind;
            this.clientController = clientsController;
            InitializeComponent();
            clientController.InitEnterDataGridView(this);
            Signal = 2;
        }

        public FrmEnterClient(FrmExit frmExit, ClientsController clientsController)
        {
            this.frmExit = frmExit;
            this.clientController = clientsController;
            InitializeComponent();
            clientController.InitEnterDataGridView(this);
            Signal = 3;
        }

        private void dgvClients_DoubleClick(object sender, EventArgs e)
        {
            clientController.EnterClient(this,Signal);
        }
       
    }
}
