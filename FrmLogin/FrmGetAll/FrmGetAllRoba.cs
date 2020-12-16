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
    public partial class FrmGetAllRoba : Form
    {
        private BindingList<Roba> robe;
        public FrmGetAllRoba()
        {
            InitializeComponent();
            robe = new BindingList<Roba>(Controler.Instance.GetAllRoba());
            dgvRoba.DataSource = robe;
        }

        private void dgvRoba_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvRoba.ColumnCount > 0)
                {
                    DataGridViewRow row = dgvRoba.SelectedRows[0];
                    Roba r = (Roba)row.DataBoundItem;
                    MainCoordinator.Instance.OpenFrmDeleteRoba(r);
                }
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nema unetih podatak");
            }
        }

        public override void Refresh()
        {
            dgvRoba.DataSource = null;
            robe = new BindingList<Roba>(Controler.Instance.GetAllRoba());
            dgvRoba.DataSource = robe;
        }
    }
}
