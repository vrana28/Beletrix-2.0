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

        private void btnFind_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.OpenFrmFind();
        }

        #region Buttons
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

        private void A32_Click(object sender, EventArgs e)
        {
            ShowPosition(A32.Name);
        }

        private void A33_Click(object sender, EventArgs e)
        {
            ShowPosition(A33.Name);
        }

        private void A34_Click(object sender, EventArgs e)
        {
            ShowPosition(A34.Name);
        }

        private void A41_Click(object sender, EventArgs e)
        {
            ShowPosition(A41.Name);
        }

        private void A42_Click(object sender, EventArgs e)
        {
            ShowPosition(A42.Name);
        }

        private void A43_Click(object sender, EventArgs e)
        {
            ShowPosition(A43.Name);
        }

        private void A44_Click(object sender, EventArgs e)
        {
            ShowPosition(A44.Name);
        }

        private void A51_Click(object sender, EventArgs e)
        {
            ShowPosition(A51.Name);
        }

        private void A52_Click(object sender, EventArgs e)
        {
            ShowPosition(A52.Name);
        }

        private void A53_Click(object sender, EventArgs e)
        {
            ShowPosition(A53.Name);
        }

        private void A54_Click(object sender, EventArgs e)
        {
            ShowPosition(A54.Name);
        }

        private void A61_Click(object sender, EventArgs e)
        {
            ShowPosition(A61.Name);
        }

        private void A62_Click(object sender, EventArgs e)
        {
            ShowPosition(A62.Name);
        }

        private void A63_Click(object sender, EventArgs e)
        {
            ShowPosition(A63.Name);
        }

        private void A64_Click(object sender, EventArgs e)
        {
            ShowPosition(A64.Name);
        }

        private void A71_Click(object sender, EventArgs e)
        {
            ShowPosition(A71.Name);
        }

        private void A72_Click(object sender, EventArgs e)
        {
            ShowPosition(A72.Name);
        }

        private void A73_Click(object sender, EventArgs e)
        {
            ShowPosition(A73.Name);
        }

        private void A74_Click(object sender, EventArgs e)
        {
            ShowPosition(A74.Name);
        }

        private void B11_Click(object sender, EventArgs e)
        {
            ShowPosition(B11.Name);
        }

        private void B12_Click(object sender, EventArgs e)
        {
            ShowPosition(B12.Name);
        }

        private void B13_Click(object sender, EventArgs e)
        {
            ShowPosition(B13.Name);
        }

        private void B14_Click(object sender, EventArgs e)
        {
            ShowPosition(B14.Name);
        }

        private void B21_Click(object sender, EventArgs e)
        {
            ShowPosition(B21.Name);
        }

        private void B22_Click(object sender, EventArgs e)
        {
            ShowPosition(B22.Name);
        }

        private void B23_Click(object sender, EventArgs e)
        {
            ShowPosition(B23.Name);
        }

        private void B24_Click(object sender, EventArgs e)
        {
            ShowPosition(B24.Name);
        }

        private void B31_Click(object sender, EventArgs e)
        {
            ShowPosition(B31.Name);
        }

        private void B32_Click(object sender, EventArgs e)
        {
            ShowPosition(B32.Name);
        }

        private void B33_Click(object sender, EventArgs e)
        {
            ShowPosition(B33.Name);
        }

        private void B34_Click(object sender, EventArgs e)
        {
            ShowPosition(B34.Name);
        }

        private void B41_Click(object sender, EventArgs e)
        {
            ShowPosition(B41.Name);
        }

        private void B42_Click(object sender, EventArgs e)
        {
            ShowPosition(B42.Name);
        }

        private void B43_Click(object sender, EventArgs e)
        {
            ShowPosition(B43.Name);
        }

        private void B44_Click(object sender, EventArgs e)
        {
            ShowPosition(B44.Name);
        }

        private void B51_Click(object sender, EventArgs e)
        {
            ShowPosition(B51.Name);
        }

        private void B52_Click(object sender, EventArgs e)
        {
            ShowPosition(B52.Name);
        }

        private void B53_Click(object sender, EventArgs e)
        {
            ShowPosition(B53.Name);
        }

        private void B54_Click(object sender, EventArgs e)
        {
            ShowPosition(B54.Name);
        }

        private void B61_Click(object sender, EventArgs e)
        {
            ShowPosition(B61.Name);
        }

        private void B62_Click(object sender, EventArgs e)
        {
            ShowPosition(B62.Name);
        }

        private void B63_Click(object sender, EventArgs e)
        {
            ShowPosition(B63.Name);
        }

        private void B64_Click(object sender, EventArgs e)
        {
            ShowPosition(B64.Name);
        }

        private void B71_Click(object sender, EventArgs e)
        {
            ShowPosition(B71.Name);
        }

        private void B72_Click(object sender, EventArgs e)
        {
            ShowPosition(B72.Name);
        }

        private void B73_Click(object sender, EventArgs e)
        {
            ShowPosition(B73.Name);
        }

        private void B74_Click(object sender, EventArgs e)
        {
            ShowPosition(B74.Name);
        }

        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.OpenFrmExit();
        }
    }
}
