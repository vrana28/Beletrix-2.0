using Controller;
using Domain;
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
    public partial class FrmGetAllStorekeepers : Form
    {
        private BindingList<Storekeeper> keepers = new BindingList<Storekeeper>();
        public FrmGetAllStorekeepers()
        {
            InitializeComponent();
            keepers = new BindingList<Storekeeper>(Controler.Instance.GetAllStorekeepers());
            dgvStorekeepers.DataSource = keepers;
        }

        public override void Refresh() {
            dgvStorekeepers.DataSource = null;
            keepers = new BindingList<Storekeeper>(Controler.Instance.GetAllStorekeepers());
            dgvStorekeepers.DataSource = keepers;
        }

        private void dgvStorekeepers_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvStorekeepers.ColumnCount > 0)
                {
                    DataGridViewRow row = dgvStorekeepers.SelectedRows[0];
                    Storekeeper s = (Storekeeper)row.DataBoundItem;
                    MainCoordinator.Instance.OpenFrmStorekeeperChange(s);
                }
                Refresh();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
