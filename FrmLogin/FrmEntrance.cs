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
            num = 1;
            txtNum.Text = num.ToString();
        }

        public Client Client{ get; set; }

        public Roba Roba { get; set; }
        public Storekeeper Storekeeper { get; set; }
        public Entrance Entrance{ get; set; }

        public static int num;

        //public List<EntranceItems> items = new List<EntranceItems>();

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
                

            };

            try
            {
                Controler.Instance.AddEntrance(ulaz);
                MessageBox.Show("Entrance saved");
                panel1.Visible = true;
                ulaz.EntranceId = Controler.instance.GetMaxId();
                Entrance = ulaz;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddToItems_Click(object sender, EventArgs e)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(txtArtikal) | UserControlHelpers.IsNullOrWhiteSpace(txtDateOfMan)
                | UserControlHelpers.IsNullOrWhiteSpace(txtQuantity)) {
                return;
            }

            

            try
            {
                EntranceItems ei = new EntranceItems
                {
                    Num = int.Parse(txtNum.Text),
                    EntranceId = Entrance.EntranceId,
                    RobaId = Roba.RobaId,
                    DateOfManu = DateTime.ParseExact(txtDateOfMan.Text, "dd.MM.yyyy.", CultureInfo.InvariantCulture),
                    DeadlineDate = DateTime.ParseExact(txtDateOfMan.Text, "dd.MM.yyyy.", CultureInfo.InvariantCulture).AddYears(1),
                    NumOfBoxes = float.Parse(txtQuantity.Text)
                };

                Controler.instance.AddEntranceItem(ei);
                bindingList.Add(ei);
                NewItemReload();
                lblTotalWeight.Text = GetTotalWeight().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void NewItemReload() {
            num += 1;
            txtNum.Text = num.ToString();
            txtQuantity.Text = "";
            txtDateOfEntrance.Text = "";
            txtArtikal.Text = "";
            dgvItems.DataSource = bindingList;
            //dgvItems.Columns["Num"].Visible = false;
            //dgvItems.Columns["EntranceId"].Visible = false;
            //dgvItems.Columns["RobaId"].Visible = false;
            //dgvItems.Columns["Deadline"].Visible = false;
            //dgvItems.Columns["NumOfBoxes"].Visible = false;
            //colNum.DataPropertyName = "Num";
            //colNum.DataPropertyName = "Roba";
            //colBrKuitja.DataPropertyName = "NumOfBoxes";
            //colJedneKutije.DataPropertyName = "WeightOfBox";
            //colUkupnaTezina.DataPropertyName = "TotalWeight";
        }


        public double GetTotalWeight() {
            double suma = 0;
            foreach (EntranceItems ei in bindingList) {
                suma += ei.NumOfBoxes * Controler.Instance.GetWeightOfBox(ei);
            }
            return suma;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvItems.Rows.Count == 0) {
                MessageBox.Show("No data");
                return;
            }
            

            try
            {
                EntranceItems ei = new EntranceItems();
                DataGridViewRow row = dgvItems.SelectedRows[0];

                ei = (EntranceItems)row.DataBoundItem;

                bindingList.Remove(ei);
                Controler.Instance.DeleteEntranceItem(ei);
                lblTotalWeight.Text = GetTotalWeight().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSaveComplete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblTotalWeight.Text)) {
                MessageBox.Show("No data!");
                return;
            }

            double TotalWeight = double.Parse(lblTotalWeight.Text);

            try
            {
                Controler.Instance.UpdateEntrance(Entrance,TotalWeight);
                MessageBox.Show("Uspesno sacuvan");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }
    }
}
