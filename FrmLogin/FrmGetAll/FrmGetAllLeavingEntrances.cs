using FrmLogin.Controllers;
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
    public partial class FrmGetAllLeavingEntrances : Form
    {
        private EntranceController entranceController;
        public FrmGetAllLeavingEntrances(Controllers.EntranceController entranceController)
        {
            this.entranceController = entranceController;
            InitializeComponent();
        }

        public DataGridView DGVLeavingEntrances { get => dgvLeavingEntrances; }
        public TextBox TxtClient { get => txtClient; }
        public TextBox TxtArtikal { get => txtArtikal; }
        public Label LblStanje { get => lblStanje; }
        public DateTimePicker DateOd { get => dtpOd; }
        public DateTimePicker DateDo { get => dtpDo; }
        public RadioButton DatumOdDo { get => rbDatumOdDo; }

        private void btnChooseClient_Click(object sender, EventArgs e)
        {
            entranceController.OpenFrmEnterClient(this);
        }

        private void btnChooseArtikal_Click_1(object sender, EventArgs e)
        {
            entranceController.OpenFrmEnterArtikal(this);
        }

        private void btnDeleteClient_Click_1(object sender, EventArgs e)
        {
            entranceController.SearchWithoutClient(this);
        }

        private void btnDeleteArtikal_Click_1(object sender, EventArgs e)
        {
            entranceController.SearchWithoutRoba(this);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //entranceController.Print(this);
        }

        private void FrmGetAllLeavingEntrances_Load(object sender, EventArgs e)
        {
            entranceController.Load(this);
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            entranceController.Search(this);
        }

    }
}
