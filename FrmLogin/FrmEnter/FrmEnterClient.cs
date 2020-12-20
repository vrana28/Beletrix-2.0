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
    public partial class FrmEnterClient : Form
    {
        private BindingList<Client> clients = new BindingList<Client>();
        public FrmEnterClient()
        {
            InitializeComponent();
            clients = new BindingList<Client>(Controler.Instance.GetAllClient());
            dgvClients.DataSource = clients;
        }

        public Client Client { get; set; }

        private void dgvClients_DoubleClick(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvClients.SelectedRows[0];
            Client = (Client)row.DataBoundItem;
            
            this.Dispose();
        }
    }
}
