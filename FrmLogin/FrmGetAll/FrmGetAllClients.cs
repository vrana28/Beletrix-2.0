using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Controller;

namespace FrmLogin.FrmGetAll
{
    public partial class FrmGetAllClients : Form
    {
        private BindingList<Client> clients = new BindingList<Client>();
        public FrmGetAllClients()
        {
            InitializeComponent();
            clients = new BindingList<Client>( Controler.Instance.GetAllClient());
            dgvClients.DataSource = clients;
        }

        private void dgvClients_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvClients.ColumnCount > 0)
                {
                    DataGridViewRow row = dgvClients.SelectedRows[0];
                    Client c = (Client)row.DataBoundItem;
                    MainCoordinator.Instance.OpenFrmClientChange(c);
                }
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nema unetih podatak");
            }
        }

        public override void  Refresh() {
            dgvClients.DataSource = null;
            clients = new BindingList<Client>(Controler.Instance.GetAllClient());
            dgvClients.DataSource = clients;
        }

    }
}
