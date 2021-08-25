
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
    public partial class FrmEnterArtikal : Form
    {
        private readonly RobaController robaController;

        public int Signal { get; set; }
        public FrmEntrance frmEntrance{ get; set; }
        public FrmFind frmFind { get; set; }
        public FrmExit FrmExit { get; set; }
        public FrmGetAllEntrances frmGetAllEntrances { get; set; }
        public FrmGetAllLeavingEntrances frmGetAllLeavingEntrances { get; set; }
        public DataGridView DGVArtikli { get => dgvRoba; }

        public FrmEnterArtikal(FrmEntrance frmEntrance, Controllers.RobaController robaController)
        {
            this.robaController = robaController;
            this.frmEntrance = frmEntrance;
            InitializeComponent();
            robaController.InitEnterDataGridView(this);
            Signal = 1;
        }

        public FrmEnterArtikal(FrmGetAllEntrances frmGetAllEntrances, Controllers.RobaController robaController)
        {
            this.frmGetAllEntrances = frmGetAllEntrances;
            this.robaController = robaController;
            InitializeComponent();
            robaController.InitEnterDataGridView(this);
            Signal = 4;
        }

        public FrmEnterArtikal(FrmGetAllLeavingEntrances frmGetAllLeavingEntrances, Controllers.RobaController robaController)
        {
            this.frmGetAllLeavingEntrances = frmGetAllLeavingEntrances;
            this.robaController = robaController;
            InitializeComponent();
            robaController.InitEnterDataGridView(this);
            Signal = 5;
        }

        public FrmEnterArtikal(FrmFind frmFind, RobaController robaController)
        {
            this.frmFind = frmFind;
            this.robaController = robaController;
            InitializeComponent();
            robaController.InitEnterDataGridView(this);
            Signal = 2;
        }

        public FrmEnterArtikal(FrmExit frmExit, RobaController robaController)
        {
            this.FrmExit = frmExit;
            this.robaController = robaController;
            InitializeComponent();
            robaController.InitEnterDataGridView(this);
            Signal = 3;
        }

        private void dgvRoba_DoubleClick(object sender, EventArgs e)
        {
            robaController.EnterArtikal(this,Signal);
        }
    }
}
