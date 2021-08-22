using Domain;
using FrmLogin.FrmEnter;
using FrmLogin.Helpers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.Controllers
{
    public class LeavingItemsController
    {
        public LeavingItemsController()
        {

        }

        public Client Client{ get; set; }
        public Roba Roba{ get; set; }
        public EntrancePosition EntrancePosition { get; set; }
        public DateTime LeavingDate { get; set; }
        public List<LeavingItem> listaItemaZaIzlaz { get; set; } = new List<LeavingItem>();
        public List<EntranceItems> listaItemaZaUpdate { get; set; } = new List<EntranceItems>();
        public EntranceItems EntranceItems { get; set; }

        public string kolona;
        public string red;
        public string pm;
        public string vertikala;

        internal void InitDataGridView(FrmExit frmExit)
        {
            frmExit.DGVAllItems.DataSource = null;
            frmExit.DGVAllItems.DataSource = Communication.Communication.Instance.FindBusyPosition(Client, Roba);
        }

        internal void OpenFrmEnterClient(FrmExit frmExit)
        {
            FrmEnterClient frmEnterClients = new FrmEnterClient(frmExit,new Controllers.ClientsController());
            frmEnterClients.ShowDialog();
            Client = Communication.Communication.Instance.ReturnClient(frmExit.TxtClient.Text);
        }

        internal void OpenFrmEnterArtikal(FrmExit frmExit)
        {
            FrmEnterArtikal frmEnterArtikal = new FrmEnterArtikal(frmExit, new Controllers.RobaController());
            frmEnterArtikal.ShowDialog();
            Roba = Communication.Communication.Instance.ReturnRoba(frmExit.TxtArtikal.Text);
        }

        internal void SearchWithoutRoba(FrmExit frmExit)
        {
            try
            {
                frmExit.TxtArtikal.Text = "";
                frmExit.TxtKolona.Text = "";
                frmExit.TxtRed.Text = "";
                frmExit.TxtPm.Text = "";
                frmExit.TxtVertikala.Text = "";
                Roba = null;
                frmExit.DGVAllItems.DataSource = null;
                frmExit.DGVAllItems.DataSource = Communication.Communication.Instance.FindBusyPosition(Client, Roba);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void SearchWithoutClient(FrmExit frmExit)
        {
            try
            {
                frmExit.TxtClient.Text = "";
                frmExit.TxtKolona.Text = "";
                frmExit.TxtRed.Text = "";
                frmExit.TxtPm.Text = "";
                frmExit.TxtVertikala.Text = "";
                Client = null;
                frmExit.DGVAllItems.DataSource = null;
                frmExit.DGVAllItems.DataSource = Communication.Communication.Instance.FindBusyPosition(Client, Roba);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void ExitOfEntrance(FrmExit frmExit)
        {
            if (frmExit.DGVSelectedtems.Columns.Count == 0)
            {
                MessageBox.Show("Nema podataka");
                return;
            }

            var confirmResult = MessageBox.Show($"Da li ste sigurni da hocete da oslobodite poziciju {EntrancePosition.PositionId}",
                                     "Potvrdi!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Communication.Communication.Instance.LeaveEntrance(EntrancePosition);
                    MessageBox.Show("Izaslo!");
                    RefreshGridView1(frmExit);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        internal void AddLeavingItem(FrmExit frmExit)
        {
            double broj = EntranceItems.NumOfBoxes;


            if (!UserControlHelpers.IsValidDouble(frmExit.TxtNumOfBoxes.Text))
            {
                MessageBox.Show("Pogrešan podatak!");
                return;
            }

            //item.NumOfBoxes = double.Parse(txtNumOfBoxes.Text);
            if (double.Parse(frmExit.TxtNumOfBoxes.Text) > broj)
            {
                MessageBox.Show("Pogrešan podatak!");
                return;
            }

            try
            {

                LeavingItem li = new LeavingItem
                {
                    EntranceId = EntranceItems.EntranceId,
                    Num = EntranceItems.Num,
                    RobaId = EntranceItems.RobaId,
                    Roba = EntranceItems.Roba,
                    NumOfBoxes = double.Parse(frmExit.TxtNumOfBoxes.Text),
                    DateOfLeaving = LeavingDate
                };

                if (!ExistInList(li))
                {

                    EntranceItems.NumOfBoxes = EntranceItems.NumOfBoxes - li.NumOfBoxes;
                    frmExit.TxtNumOfBoxes.Text = EntranceItems.NumOfBoxes.ToString();

                    listaItemaZaIzlaz.Add(li);
                    frmExit.DGVLeavingItems.DataSource = null;
                    frmExit.DGVLeavingItems.DataSource = listaItemaZaIzlaz;
                    DgvLeavingCorrection(frmExit.DGVLeavingItems);
                }
                else
                {
                    EntranceItems.NumOfBoxes = EntranceItems.NumOfBoxes - li.NumOfBoxes;
                    frmExit.TxtNumOfBoxes.Text = EntranceItems.NumOfBoxes.ToString();
                    frmExit.DGVLeavingItems.DataSource = null;
                    frmExit.DGVLeavingItems.DataSource = listaItemaZaIzlaz;
                    DgvLeavingCorrection(frmExit.DGVLeavingItems);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void IzlazDela(FrmExit frmExit)
        {
            NapraviListuZaUpdate(frmExit);

            try
            {
                if (listaItemaZaUpdate.Count > 0 && listaItemaZaIzlaz.Count > 0)
                {
                    //Controler.Instance.LeavingEntranceItems(listaItemaZaIzlaz, listaItemaZaUpdate);
                    Communication.Communication.Instance.LeavingEntranceItems(listaItemaZaIzlaz, listaItemaZaUpdate);
                    MessageBox.Show("Uspesno sacuvano");
                    RefreshGridView1(frmExit);
                }
                else {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da zapamti izlaz dela palete");
            }
        }

        private void NapraviListuZaUpdate(FrmExit frmExit)
        {
            listaItemaZaUpdate.Clear();
            for (int i = 0; i < frmExit.DGVSelectedtems.RowCount; i++)
            {
                DataGridViewRow row = frmExit.DGVSelectedtems.Rows[i];
                listaItemaZaUpdate.Add((EntranceItems)row.DataBoundItem);
            }
        }

        private void DgvLeavingCorrection(DataGridView dgvLeavingItems)
        {
            dgvLeavingItems.Columns["Num"].Visible = false;
            dgvLeavingItems.Columns["RobaId"].Visible = false;
            dgvLeavingItems.Columns["NumOfBoxes"].HeaderText = "Broj kutija";
            dgvLeavingItems.Columns["LeavingItemId"].Visible = false;
        }

        public bool ExistInList(LeavingItem li)
        {

            if (listaItemaZaIzlaz.Count > 0)
            {
                foreach (LeavingItem l in listaItemaZaIzlaz)
                {
                    if (l.RobaId == li.RobaId)
                    {
                        l.NumOfBoxes += li.NumOfBoxes;
                        return true;
                    }
                }
            }
            return false;
        }

        internal void RemoveFromLeavingList(FrmExit frmExit)
        {
            try
            {
                DataGridViewRow row = frmExit.DGVLeavingItems.SelectedRows[0];
                LeavingItem li = (LeavingItem)row.DataBoundItem;
                if (li.RobaId != EntranceItems.RobaId)
                {
                    MessageBox.Show("Morate prvo da ga ucitate.");
                    return;
                }
                listaItemaZaIzlaz.Remove(li);
                frmExit.DGVLeavingItems.DataSource = null;
                frmExit.DGVLeavingItems.DataSource = listaItemaZaIzlaz;
                EntranceItems.NumOfBoxes += li.NumOfBoxes;
                frmExit.TxtNumOfBoxes.Text = EntranceItems.NumOfBoxes.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void IzlazDelaPalete(FrmExit frmExit)
        {
            try
            {

                DataGridViewRow row = frmExit.DGVSelectedtems.SelectedRows[0];
                EntranceItems = (EntranceItems)row.DataBoundItem;
                MessageBox.Show(EntranceItems.EntranceId.ToString());
                frmExit.PnlIzmena.Visible = true;
                frmExit.TxtNum.Text = EntranceItems.Num.ToString();
                frmExit.TxtEntranceId.Text = EntranceItems.EntranceId.ToString();
                frmExit.TxtName.Text = EntranceItems.Roba.Name;
                frmExit.TxtNumOfBoxes.Text = EntranceItems.NumOfBoxes.ToString();
                var culture = new CultureInfo("de-DE");
                frmExit.TxtDateOfLeaving.Text = DateTime.Now.ToString(culture);
                LeavingDate = DateTime.Now;
            }
            catch (Exception)
            {
                MessageBox.Show("Sistem ne moze da kreira deo izlazne palete");
            }
        }

        internal void DoubleClickDGVAllItems(FrmExit frmExit)
        {
            string pozicija;
            frmExit.DGVLeavingItems.DataSource = null;
            listaItemaZaIzlaz.Clear();
            frmExit.PnlIzmena.Visible = false;
            try
            {
                DataGridViewRow row = frmExit.DGVAllItems.SelectedRows[0];
                pozicija = (string)row.Cells[1].Value;
                frmExit.LblPozicija.Text = pozicija;
                EntrancePosition = Communication.Communication.Instance.ReturnEntrancePositions(pozicija);
                BindingList<EntranceItems> items = new BindingList<EntranceItems>(Communication.Communication.Instance.ReturnEntranceItems(EntrancePosition.EntranceId));
                frmExit.DGVSelectedtems.DataSource = items;
                InitialGridView(frmExit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void RefreshGridView1(FrmExit frmExit)
        {
            frmExit.DGVAllItems.DataSource = null;
            frmExit.DGVAllItems.DataSource = Communication.Communication.Instance.FindBusyPosition(Client, Roba);
            frmExit.DGVSelectedtems.DataSource = null;
            frmExit.DGVLeavingItems.DataSource = null;
            frmExit.PnlIzmena.Visible = false;
        }

        public void InitialGridView(FrmExit frmExit)
        {
            frmExit.DGVSelectedtems.Columns["RobaId"].Visible = false;
            frmExit.DGVSelectedtems.Columns["Deadline"].Visible = false;

            for (int i = 0; i <= frmExit.DGVSelectedtems.Columns.Count - 1; i++)
            {
                frmExit.DGVSelectedtems.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

        }

        internal void Search(FrmExit frmExit)
        {
            kolona = frmExit.TxtKolona.Text;
            red = frmExit.TxtRed.Text;
            pm = frmExit.TxtPm.Text;
            vertikala = frmExit.TxtVertikala.Text;

            try
            {
                frmExit.DGVAllItems.DataSource = null;
                frmExit.DGVAllItems.DataSource = Communication.Communication.Instance.FindBusyPositionsWithPosition(Client, Roba, ReturnSearchItem());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal string ReturnSearchItem()
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

        internal void Print(FrmExit frmExit)
        {
            if (frmExit.DGVAllItems.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Izlaz.pdf";
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
                            PdfPTable pdfTable = new PdfPTable(frmExit.DGVAllItems.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in frmExit.DGVAllItems.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in frmExit.DGVAllItems.Rows)
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

                                //var imagepath = @"D:\..\Logo.png";
                                //using (FileStream fs = new FileStream(imagepath, FileMode.Open))
                                //{
                                //    var png = Image.GetInstance(System.Drawing.Image.FromStream(fs),
                                //        ImageFormat.Png);
                                //    png.ScalePercent(5f);
                                //    png.SetAbsolutePosition(pdfDoc.Left, pdfDoc.Top);
                                //    pdfDoc.Add(png);
                                //}

                                var spacer = new Paragraph("")
                                {
                                    SpacingBefore = 10f,
                                    SpacingAfter = 10f,
                                };
                                pdfDoc.Add(spacer);
                                var headerTable = new PdfPTable(new[] { .75f, 2f })
                                {

                                    WidthPercentage = 75,
                                    DefaultCell = { MinimumHeight = 22f }
                                };
                                var culture = new CultureInfo("de-DE");
                                headerTable.AddCell("Date");
                                headerTable.AddCell(DateTime.Now.ToString(culture));
                                headerTable.AddCell("Klijent:");
                                if (Client == null)
                                {
                                    headerTable.AddCell("");
                                }
                                else
                                {
                                    headerTable.AddCell(Client.Name);
                                }
                                

                                pdfDoc.Add(headerTable);
                                pdfDoc.Add(spacer);

                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Uspešno exportovano!!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Greška :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Nema podataka za export!!!", "Info");
            }
        }
    }
}
