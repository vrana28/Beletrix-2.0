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

namespace FrmLogin.FrmEnter
{
    public partial class FrmEnterArtikal : Form
    {
        private BindingList<Roba> robe;
        public FrmEnterArtikal()
        {
            InitializeComponent();
            robe = new BindingList<Roba>(Controler.Instance.GetAllRoba());
            dgvRoba.DataSource = robe;
        }

        public Roba Roba { get; set; }
        private void dgvRoba_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvRoba.SelectedRows[0];
            Roba = (Roba)row.DataBoundItem;
            this.Dispose();
        }
    }
}
