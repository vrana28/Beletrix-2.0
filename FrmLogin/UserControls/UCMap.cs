using Controller;
using FrmLogin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.UserControls
{
    public partial class UCMap : UserControl
    {
        private List<RadioButton> rButtons = new List<RadioButton>();
        public UCMap()
        {
            InitializeComponent();
            rButtons.Add(rb1);
            rButtons.Add(rb2);
            rButtons.Add(rb3);
            rButtons.Add(rb4);
            rButtons.Add(rb5);
        }

        private void C24_Click(object sender, EventArgs e)
        {
            ShowPosition(C24.Name);
        }

        private void btnUlaz_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.OpenFrmEntrance();
        }

        private void btnPovezi_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.OpenFrmPositioning();
        }

        private void A01_Click(object sender, EventArgs e)
        {
            ShowPosition(A01.Name);
        }

        private void A02_Click(object sender, EventArgs e)
        {
            ShowPosition(A02.Name);
        }

        private void A03_Click(object sender, EventArgs e)
        {
            ShowPosition(A03.Name);
        }

        public void ShowPosition(string pozicija) {
            string PositionId = pozicija+UserControlHelpers.CkeckedButtons(rButtons).Text;
            MessageBox.Show(PositionId);
            try
            {
                dgvStanjeNaPoziciji.DataSource = null;
                dgvStanjeNaPoziciji.DataSource = Controler.Instance.ShowEntranceItems(PositionId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void A04_Click(object sender, EventArgs e)
        {
            ShowPosition(A04.Name);
        }

        private void A11_Click(object sender, EventArgs e)
        {
            ShowPosition(A11.Name);
        }

        private void A12_Click(object sender, EventArgs e)
        {
            ShowPosition(A12.Name);
        }

        private void A13_Click(object sender, EventArgs e)
        {
            ShowPosition(A13.Name);
        }

        private void A14_Click(object sender, EventArgs e)
        {
            ShowPosition(A14.Name);
        }

        private void A21_Click(object sender, EventArgs e)
        {
            ShowPosition(A21.Name);
        }

        private void A22_Click(object sender, EventArgs e)
        {
            ShowPosition(A22.Name);
        }

        private void A23_Click(object sender, EventArgs e)
        {
            ShowPosition(A23.Name);
        }

        private void A24_Click(object sender, EventArgs e)
        {
            ShowPosition(A24.Name);
        }

        private void A31_Click(object sender, EventArgs e)
        {
            ShowPosition(A31.Name);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.OpenFrmFind();
        }
    }
}
