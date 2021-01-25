using Controller;
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
    public partial class FrmPositioning : Form
    {
        private readonly PositionController positionController;
        public FrmPositioning(Controllers.PositionController positionController)
        {
            this.positionController = positionController;
            InitializeComponent();
            positionController.InitDataGridViews(this);
        }

        public DataGridView DGVEntrances{ get => dgvEntrances; }
        public DataGridView DGVPositions{ get => dgvPositions; }
        public TextBox TxtKolona { get => txtKolona; }
        public TextBox TxtRed { get => txtRed; }
        public TextBox TxtPM { get => txtPaletnoMesto; }
        public TextBox TxtVertikala { get => txtVertikala; }
        public TextBox TxtEntranceId{ get => txtEntranceId; }
        public TextBox TxtPositionId { get => txtPositionId; }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            positionController.SearchPosition(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            positionController.Refresh(this);
        }

        private void dgvEntrances_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            positionController.ReturnSelectedEntrance(this);
        }

        private void dgvPositions_DoubleClick(object sender, EventArgs e)
        {
            positionController.ReturnSelectedPosition(this);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            positionController.RestartFields(this);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            positionController.Connect(this);
        }

    }
}
