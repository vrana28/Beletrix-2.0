using Controller;
using Domain;
using FrmLogin.FrmEnter;
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
    public partial class FrmFind : Form
    {
        public FrmFind()
        {
            InitializeComponent();
        }

        public Client Client { get;  set; }
        public Roba Roba { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmEnterClient frmEnterClients = new FrmEnterClient();
            frmEnterClients.ShowDialog();
            if (frmEnterClients.Client != null)
            {
                Client = frmEnterClients.Client;
                txtClient.Text = Client.Name;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmEnterArtikal frmEnterArtikal = new FrmEnterArtikal();
            frmEnterArtikal.ShowDialog();
            if (frmEnterArtikal.Roba != null)
            {
                Roba = frmEnterArtikal.Roba;
                txtArtikal.Text = Roba.Name;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSearchResult.DataSource = null;
                dgvSearchResult.DataSource = Controler.Instance.FindBusyPositions(Client, Roba);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRoba_Click(object sender, EventArgs e)
        {
            try
            {
                txtClient.Text = "";
                Client = null;
                dgvSearchResult.DataSource = null;
                dgvSearchResult.DataSource = Controler.Instance.FindBusyPositions(Client, Roba);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                txtArtikal.Text = "";
                Roba = null;
                dgvSearchResult.DataSource = null;
                dgvSearchResult.DataSource = Controler.Instance.FindBusyPositions(Client, Roba);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmFind_Load(object sender, EventArgs e)
        {
            try
            {
                dgvSearchResult.DataSource = null;
                dgvSearchResult.DataSource = Controler.Instance.FindBusyPositions(Client, Roba);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
