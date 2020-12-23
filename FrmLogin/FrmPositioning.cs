using Controller;
using Domain;
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
        public FrmPositioning()
        {
            InitializeComponent();
        }

        public string kolona;
        public string red;
        public string pm;
        public string vertikala;

        private void FrmPositioning_Load(object sender, EventArgs e)
        {

            try
            {
                dgvEntrances.DataSource = Controler.Instance.GetAllEntrancecs();
                dgvPositions.DataSource = Controler.Instance.GetAllPositions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           

            kolona = txtKolona.Text;
            red = txtRed.Text;
             pm = txtPaletnoMesto.Text;
             vertikala = txtVertikala.Text;

            try
            {
                dgvPositions.DataSource = Controler.Instance.FindPositions(ReturnSearchItem());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public string ReturnSearchItem() {
            string item = "";
            if (kolona == "") item += "_";
            else item += kolona;
            if (red == "") item += "_";
            else item += red;
            if (pm == "") item += "_";
            else item += pm;
            if (vertikala == "") item += "_";
            else item += vertikala;
            return item;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshAll();

        }

        private void dgvEntrances_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvEntrances.SelectedRows[0];
                int entranceId = (int)row.Cells[0].Value;
                Entrance entrance = Controler.Instance.FindEntrance(entranceId);
                txtEntranceId.Text = entrance.EntranceId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvPositions_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvPositions.SelectedRows[0];
                Position p = (Position)row.DataBoundItem;
                txtPositionId.Text = p.PositionId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            txtPositionId.Text = "";
            txtEntranceId.Text = "";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(txtEntranceId) | UserControlHelpers.IsNullOrWhiteSpace(txtPositionId)) {
                MessageBox.Show("No data to bind!");
                return;
            }

            EntrancePosition ep = new EntrancePosition {
                EntranceId = int.Parse(txtEntranceId.Text),
                PositionId = txtPositionId.Text
            };

            try
            {
                Controler.Instance.AddEntrancePosition(ep);
                Controler.Instance.SetEntranceTrue(ep.EntranceId);
                Controler.Instance.UpdatePosition(ep.PositionId);
                RefreshAll();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void RefreshAll() {
            txtKolona.Text = "";
            txtRed.Text = "";
            txtPaletnoMesto.Text = "";
            txtVertikala.Text = "";
            txtEntranceId.Text = "";
            txtPositionId.Text = "";
            dgvPositions.DataSource = Controler.Instance.GetAllPositions();
            dgvEntrances.DataSource = Controler.Instance.GetAllEntrancecs();
        }

    }
}
