using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Domain;
using FrmLogin.FrmEnter;
using FrmLogin.Helpers;

namespace FrmLogin
{
    public partial class FrmEntrance : Form
    {
        BindingList<EntranceItems> bindingList = new BindingList<EntranceItems>();
        private DateTime EntranceDate;
        
        public FrmEntrance()
        {
            InitializeComponent();
            
            lblMagacioner.Text = $"{Controler.Instance.Storekeeper.Name} {Controler.Instance.Storekeeper.LastName}";
            Storekeeper = Controler.Instance.Storekeeper;

            var culture = new CultureInfo("de-DE");
            txtDateOfEntrance.Text = DateTime.Now.ToString(culture);
            EntranceDate = DateTime.Now;
        }

        public Client Client{ get; set; }

        public Roba Roba { get; set; }
        public Storekeeper Storekeeper { get; set; }
        public Entrance Entrance{ get; set; }

        private void btnChooseClient_Click(object sender, EventArgs e)
        {
            FrmEnterClient frmEnterClients = new FrmEnterClient();
            frmEnterClients.ShowDialog();
            if (frmEnterClients.Client != null) {
                Client = frmEnterClients.Client;
                txtClient.Text = Client.Name;
            }
           
        }

        private void btnChooseArtikal_Click(object sender, EventArgs e)
        {
            FrmEnterArtikal frmEnterArtikal = new FrmEnterArtikal();
            frmEnterArtikal.ShowDialog();
            if (frmEnterArtikal.Roba != null) {
                Roba = frmEnterArtikal.Roba;
                txtArtikal.Text = Roba.Name;
            }
        }

        private void btnSavePaleta_Click(object sender, EventArgs e)
        {
            if(UserControlHelpers.IsNullOrWhiteSpace(txtClient) | UserControlHelpers.IsNullOrWhiteSpace(txtDateOfEntrance)){
                MessageBox.Show("Niste uneli sve parametre!");
                return;
            }

            Entrance ulaz = new Entrance {
                DateOfEntrance = new DateTime(EntranceDate.Year,EntranceDate.Month,EntranceDate.Day,EntranceDate.Hour, EntranceDate.Minute,EntranceDate.Second),
                Dimension = rtbVrstaPalete.Text,
                ClientId = Client.ClientId,
                Storekeeper = Storekeeper,
                DateOfExit = null

            };

            try
            {
                Controler.Instance.AddEntrance(ulaz);
                MessageBox.Show("Entrance saved");
                panel1.Visible = true;
                Entrance = ulaz;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
