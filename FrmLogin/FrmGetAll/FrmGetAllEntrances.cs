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

namespace FrmLogin.FrmGetAll
{
    public partial class FrmGetAllEntrances : Form
    {
        private EntranceController entranceController;
        public FrmGetAllEntrances(Controllers.EntranceController entranceController)
        {
            this.entranceController = entranceController;
            InitializeComponent();

        }

        public DataGridView DGVEntrances { get => dgvEntrances; }
        public TextBox TxtClient { get => txtClient; }
        public TextBox TxtArtikal { get => txtArtikal; }
        public Label LblStanje { get => lblStanje; }
        public DateTimePicker DateOd { get => dtpOd; }
        public DateTimePicker DateDo { get => dtpDo; }
        public RadioButton DatumOdDo { get => rbDatumOdDo; }
        private void btnChooseClient_Click_1(object sender, EventArgs e)
        {
            entranceController.OpenFrmEnterClient(this);
        }

        private void btnChooseArtikal_Click(object sender, EventArgs e)
        {
            entranceController.OpenFrmEnterArtikal(this);
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            entranceController.SearchWithoutClient(this);
        }

        private void FrmGetAllEntrances_Load(object sender, EventArgs e)
        {
            entranceController.Load(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            entranceController.Search(this);
        }

        private void btnDeleteArtikal_Click(object sender, EventArgs e)
        {
            entranceController.SearchWithoutRoba(this);
        }
    }
}
