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
            MessageBox.Show($"You clicked {C24.Name}{UserControlHelpers.CkeckedButtons(rButtons).Text}");
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
            string PositionId = A01.Name+UserControlHelpers.CkeckedButtons(rButtons).Text;
            try
            {
                dgvStanjeNaPoziciji.DataSource = Controler.Instance.ShowEntranceItems(PositionId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          }
    }
}
