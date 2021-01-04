using Controller;
using Domain;
using FrmLogin.FrmEnter;
using FrmLogin.Helpers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin
{
    public partial class FrmExit : Form
    {
        

        public FrmExit()
        {
            InitializeComponent();
        }

        public Client Client { get; set; }
        public Roba Roba { get; private set; }
        public EntrancePosition EntrancePosition { get; set; }

        public EntranceItems EntranceItems { get; set; }

        public string kolona;
        public string red;
        public string pm;
        public string vertikala;
        private void FrmExit_Load(object sender, EventArgs e)
        {
            try
            {
                dgvSearchResultExit.DataSource = null;
                dgvSearchResultExit.DataSource = Controler.Instance.FindBusyPositions(Client, Roba);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
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
            kolona = txtKolona.Text;
            red = txtReds.Text;
            pm = txtPaletnoMesto.Text;
            vertikala = txtVertikala.Text;

            try
            {
                dgvSearchResultExit.DataSource = null;
                dgvSearchResultExit.DataSource = Controler.Instance.FindBusyPositionsWithPosition(Client, Roba,ReturnSearchItem());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSearchResult_DoubleClick(object sender, EventArgs e)
        {
            string pozicija;
            try
            {
                DataGridViewRow row = dgvSearchResultExit.SelectedRows[0];
                pozicija = (string)row.Cells[1].Value;
                lblPozicija.Text = pozicija;
                EntrancePosition = Controler.Instance.ReturnEntrancePosition(pozicija);
                BindingList<EntranceItems> items = new BindingList<EntranceItems>(Controler.instance.ReturnEntranceItems(EntrancePosition.EntranceId));
                dgvItems.DataSource = items;
                InitialGridView();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void InitialGridView()
        {
            dgvItems.Columns["RobaId"].Visible = false;
            dgvItems.Columns["Deadline"].Visible = false;
            //dgvItems.Columns.Add("TotalWeight", "Tezina");
            
            

            for (int i = 0; i <= dgvItems.Columns.Count - 1; i++)
            {
                dgvItems.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            if (dgvItems.Columns.Count == 0) {
                MessageBox.Show("No data to delete");
                return;
            }

            var confirmResult = MessageBox.Show($"Da li ste sigurni da hocete da oslobodite poziciju {EntrancePosition.PositionId}",
                                     "Confirm Exit!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Controler.Instance.LeaveEntrance(EntrancePosition);
                    MessageBox.Show("Izaslo!");
                    RefreshGridView1();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #region Pomocne_metode
        public void RefreshGridView1() {
            dgvSearchResultExit.DataSource = null;
            dgvSearchResultExit.DataSource = Controler.Instance.FindBusyPositions(Client, Roba);
        }

        public string ReturnSearchItem()
        {
            string item = "";
            if (kolona == "") item += "_";
            else item += kolona;
            if (red == "") item += "_";
            else item += red;
            if (pm == "") item += "_";
            else item += pm;
            if (vertikala == "") item += "_";
            else item += vertikala;
            return item;
        }

        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                txtArtikal.Text = "";
                txtArtikal.Text = "";
                txtKolona.Text = "";
                txtReds.Text = "";
                txtPaletnoMesto.Text = "";
                txtVertikala.Text = "";
                Client = null;
                dgvSearchResultExit.DataSource = null;
                dgvSearchResultExit.DataSource = Controler.Instance.FindBusyPositions(Client, Roba);
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
                txtArtikal.Text = "";
                txtKolona.Text = "";
                txtReds.Text = "";
                txtPaletnoMesto.Text = "";
                txtVertikala.Text = "";
                Client = null;
                dgvSearchResultExit.DataSource = null;
                dgvSearchResultExit.DataSource = Controler.Instance.FindBusyPositions(Client, Roba);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgvSearchResultExit.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dgvSearchResultExit.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dgvSearchResultExit.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgvSearchResultExit.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }

        private void btnIzlazDelaPalete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvItems.SelectedRows[0];
                EntranceItems = (EntranceItems)row.DataBoundItem;
                MessageBox.Show(EntranceItems.EntranceId.ToString());
                pnlIzmena.Visible = true;
                txtNum.Text = EntranceItems.Num.ToString();
                txtEntranceId.Text = EntranceItems.EntranceId.ToString();
                txtName.Text = EntranceItems.Roba.Name;
                txtNumOfBoxes.Text = EntranceItems.NumOfBoxes.ToString();

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateEntranceItem_Click(object sender, EventArgs e)
        {
            double broj = EntranceItems.NumOfBoxes;
            EntranceItems item = EntranceItems;

            if (!UserControlHelpers.IsValidDouble(txtNumOfBoxes.Text)) {
                MessageBox.Show("Wrong data!");
                return;
            }

            item.NumOfBoxes = double.Parse(txtNumOfBoxes.Text);
            if (item.NumOfBoxes>broj) {
                MessageBox.Show("Wrong change data!");
                return;
            }

            try
            {
                Controler.Instance.UpdateEntranceItems(item);
                MessageBox.Show("Updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
