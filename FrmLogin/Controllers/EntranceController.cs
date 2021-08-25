using Domain;
using FrmLogin.FrmEnter;
using FrmLogin.FrmGetAll;
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
    public class EntranceController
    {
        public EntranceController()
        {

        }

        public Client Client { get; set; }
        public Roba Roba { get; set; }
        public Entrance Entrance { get; set; }
        public List<EntranceItems> Items { get; set; } = new List<EntranceItems>();

        internal void InitDataGridView(FrmGetAllEntrances frmGetAllEntrances)
        {
            throw new NotImplementedException();
        }

        public BindingList<EntranceItems> bindingList = new BindingList<EntranceItems>();
        internal void OpenFrmEnterClient(FrmEntrance frmEntrance)
        {
            FrmEnterClient frmEnterClient = new FrmEnterClient(frmEntrance, new Controllers.ClientsController());
            frmEnterClient.ShowDialog();
        }

        internal void OpenFrmEnterClient(FrmGetAllLeavingEntrances frmGetAllLeavingEntrances)
        {
            FrmEnterClient frmEnterClient = new FrmEnterClient(frmGetAllLeavingEntrances, new Controllers.ClientsController());
            frmEnterClient.ShowDialog();
            Client = Communication.Communication.Instance.ReturnClient(frmGetAllLeavingEntrances.TxtClient.Text);
        }

        internal void OpenFrmEnterClient(FrmGetAllEntrances frmGetAllEntrances)
        {
            FrmEnterClient frmEnterClient = new FrmEnterClient(frmGetAllEntrances, new Controllers.ClientsController());
            frmEnterClient.ShowDialog();
            Client = Communication.Communication.Instance.ReturnClient(frmGetAllEntrances.TxtClient.Text);
        }

        internal void Load(FrmGetAllEntrances frmGetAllEntrances)
        {
            try
            {
                frmGetAllEntrances.DGVEntrances.DataSource = null;
                frmGetAllEntrances.DGVEntrances.DataSource = Communication.Communication.Instance.FindBusyEntrances(Client, Roba);
                frmGetAllEntrances.LblStanje.Text = Izracunaj(frmGetAllEntrances);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void Load(FrmGetAllLeavingEntrances frmGetAllLeavingEntrances)
        {
            try
            {
                frmGetAllLeavingEntrances.DGVLeavingEntrances.DataSource = null;
                frmGetAllLeavingEntrances.DGVLeavingEntrances.DataSource = Communication.Communication.Instance.FindOutputEntrances(Client, Roba);
                frmGetAllLeavingEntrances.LblStanje.Text = Izracunaj(frmGetAllLeavingEntrances);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void Print(FrmGetAllEntrances frmGetAllEntrances)
        {
            if (frmGetAllEntrances.DGVEntrances.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Uskladistenje.pdf";
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
                            PdfPTable pdfTable = new PdfPTable(frmGetAllEntrances.DGVEntrances.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in frmGetAllEntrances.DGVEntrances.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in frmGetAllEntrances.DGVEntrances.Rows)
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
                                Font titleFont = FontFactory.GetFont("Arial", 32);
                                Font regularFont = FontFactory.GetFont("Arial", 36);
                                Paragraph title;
                                title = new Paragraph("Uskladištenje", titleFont);
                                pdfDoc.Add(title);
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
                                headerTable.AddCell("Ukupno uskladišteno:");
                                headerTable.AddCell(frmGetAllEntrances.LblStanje.Text);
                                headerTable.AddCell("Potpis magacionera ");
                                headerTable.AddCell("                   ");

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
                MessageBox.Show("Nema šta da sačuva!!!", "Info");
            }
        }

        internal void SearchWithoutRoba(FrmGetAllEntrances frmGetAllEntrances)
        {
            try
            {
                frmGetAllEntrances.TxtArtikal.Text = "";
                Roba = null;
                frmGetAllEntrances.DGVEntrances.DataSource = null;
                frmGetAllEntrances.DGVEntrances.DataSource = Communication.Communication.Instance.FindBusyEntrances(Client, Roba);
                frmGetAllEntrances.LblStanje.Text = Izracunaj(frmGetAllEntrances);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void SearchWithoutRoba(FrmGetAllLeavingEntrances frmGetAllLeavingEntrances)
        {
            try
            {
                frmGetAllLeavingEntrances.TxtArtikal.Text = "";
                Roba = null;
                frmGetAllLeavingEntrances.DGVLeavingEntrances.DataSource = null;
                frmGetAllLeavingEntrances.DGVLeavingEntrances.DataSource = Communication.Communication.Instance.FindOutputEntrances(Client, Roba);
                frmGetAllLeavingEntrances.LblStanje.Text = Izracunaj(frmGetAllLeavingEntrances);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void Search(FrmGetAllEntrances frmGetAllEntrances)
        {
            if (frmGetAllEntrances.DatumOdDo.Checked) {
                if (frmGetAllEntrances.DateOd.Value > frmGetAllEntrances.DateDo.Value) {
                    MessageBox.Show("Greska!! Datum od mora biti starariji od datuma do.");
                    return;
                }
            }

            try
            {
                frmGetAllEntrances.DGVEntrances.DataSource = null;
                if (!frmGetAllEntrances.DatumOdDo.Checked)
                {
                    frmGetAllEntrances.DGVEntrances.DataSource = Communication.Communication.Instance.FindBusyEntrances(Client, Roba);
                }
                else {
                    frmGetAllEntrances.DGVEntrances.DataSource = Communication.Communication.Instance.FindBusyEntrancesWithDate(Client, Roba, frmGetAllEntrances.DateOd.Value, frmGetAllEntrances.DateDo.Value);
                }
                frmGetAllEntrances.LblStanje.Text = Izracunaj(frmGetAllEntrances);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void Search(FrmGetAllLeavingEntrances frmGetAllLeavingEntrances)
        {
            if (frmGetAllLeavingEntrances.DatumOdDo.Checked)
            {
                if (frmGetAllLeavingEntrances.DateOd.Value > frmGetAllLeavingEntrances.DateDo.Value)
                {
                    MessageBox.Show("Greska!! Datum od mora biti starariji od datuma do.");
                    return;
                }
            }

            try
            {
                frmGetAllLeavingEntrances.DGVLeavingEntrances.DataSource = null;
                if (!frmGetAllLeavingEntrances.DatumOdDo.Checked)
                {
                    frmGetAllLeavingEntrances.DGVLeavingEntrances.DataSource = Communication.Communication.Instance.FindOutputEntrances(Client, Roba);
                }
                else
                {
                    frmGetAllLeavingEntrances.DGVLeavingEntrances.DataSource = Communication.Communication.Instance.FindOutputEntrancesWithDate(Client, Roba, frmGetAllLeavingEntrances.DateOd.Value, frmGetAllLeavingEntrances.DateDo.Value);
                }
                frmGetAllLeavingEntrances.LblStanje.Text = Izracunaj(frmGetAllLeavingEntrances);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string Izracunaj(FrmGetAllEntrances frmGetAllEntrances)
        {
            double stanje = 0;
            DataGridViewRow row;
            if (frmGetAllEntrances.DGVEntrances.Rows.Count != 0)
            {
                for (int i = 0; i < frmGetAllEntrances.DGVEntrances.Rows.Count; i++)
                {
                    row = frmGetAllEntrances.DGVEntrances.Rows[i];
                    stanje += (double)row.Cells[3].Value;
                }
            }
            return stanje.ToString() + " kg";
        }

        private string Izracunaj(FrmGetAllLeavingEntrances frmGetAllLeavingEntrances)
        {
            double stanje = 0;
            DataGridViewRow row;
            if (frmGetAllLeavingEntrances.DGVLeavingEntrances.Rows.Count != 0)
            {
                for (int i = 0; i < frmGetAllLeavingEntrances.DGVLeavingEntrances.Rows.Count; i++)
                {
                    row = frmGetAllLeavingEntrances.DGVLeavingEntrances.Rows[i];
                    stanje += (double)row.Cells[3].Value;
                }
            }
            return stanje.ToString() + " kg";
        }

        internal void SearchWithoutClient(FrmGetAllEntrances frmGetAllEntrances)
        {
            try
            {
                frmGetAllEntrances.TxtClient.Text = "";
                Client = null;
                frmGetAllEntrances.DGVEntrances.DataSource = null;
                frmGetAllEntrances.DGVEntrances.DataSource = Communication.Communication.Instance.FindBusyEntrances(Client, Roba);
                frmGetAllEntrances.LblStanje.Text = Izracunaj(frmGetAllEntrances);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void SearchWithoutClient(FrmGetAllLeavingEntrances frmGetAllLeavingEntrances)
        {
            try
            {
                frmGetAllLeavingEntrances.TxtClient.Text = "";
                Client = null;
                frmGetAllLeavingEntrances.DGVLeavingEntrances.DataSource = null;
                frmGetAllLeavingEntrances.DGVLeavingEntrances.DataSource = Communication.Communication.Instance.FindOutputEntrances(Client, Roba);
                frmGetAllLeavingEntrances.LblStanje.Text = Izracunaj(frmGetAllLeavingEntrances);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void OpenFrmEnterArtikal(FrmEntrance frmEntrance)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(frmEntrance.TxtClient))
            {
                MessageBox.Show("Greska!! Morate prvo uneti klijenta.");
                return;
            }
            FrmEnterArtikal frmEnterArtikal = new FrmEnterArtikal(frmEntrance, new Controllers.RobaController());
            frmEnterArtikal.ShowDialog();
        }

        internal void OpenFrmEnterArtikal(FrmGetAllEntrances frmGetAllEntrances)
        {
            //if (UserControlHelpers.IsNullOrWhiteSpace(frmGetAllEntrances.TxtClient))
            //{
            //    MessageBox.Show("Greska!! Morate prvo uneti klijenta.");
            //    return;
            //}
            FrmEnterArtikal frmEnterArtikal = new FrmEnterArtikal(frmGetAllEntrances, new Controllers.RobaController());
            frmEnterArtikal.ShowDialog();
            Roba = Communication.Communication.Instance.ReturnRoba(frmGetAllEntrances.TxtArtikal.Text);
        }

        internal void OpenFrmEnterArtikal(FrmGetAllLeavingEntrances frmGetAllLeavingEntrances)
        {
            //if (UserControlHelpers.IsNullOrWhiteSpace(frmGetAllEntrances.TxtClient))
            //{
            //    MessageBox.Show("Greska!! Morate prvo uneti klijenta.");
            //    return;
            //}
            FrmEnterArtikal frmEnterArtikal = new FrmEnterArtikal(frmGetAllLeavingEntrances, new Controllers.RobaController());
            frmEnterArtikal.ShowDialog();
            Roba = Communication.Communication.Instance.ReturnRoba(frmGetAllLeavingEntrances.TxtArtikal.Text);
        }

        internal void AddItems(FrmEntrance frmEntrance)
        {
            var culture = new CultureInfo("de-DE");

            if (UserControlHelpers.IsNullOrWhiteSpace(frmEntrance.TxtArtikal) | UserControlHelpers.IsNullOrWhiteSpace(frmEntrance.TxtDateOfManu)
                | UserControlHelpers.IsNullOrWhiteSpace(frmEntrance.TxtQuantity))
            {
                return;
            }
            try
            {
                Client = Communication.Communication.Instance.ReturnClient(frmEntrance.TxtClient.Text);
                Roba = Communication.Communication.Instance.ReturnRoba(frmEntrance.TxtArtikal.Text);

                Entrance ulaz = new Entrance
                {
                    DateOfEntrance = frmEntrance.EntranceDate,
                    Dimension = frmEntrance.RTxtDimension.Text,
                    ClientId = Client.ClientId,
                    Storekeeper = Controllers.LoginController.Storekeeper,
                };

                Entrance = ulaz;
                EntranceItems ei = new EntranceItems
                {
                    Num = int.Parse(frmEntrance.TxtNum.Text),
                    Roba = Roba,
                    RobaId = Roba.RobaId,
                    DateOfManu = DateTime.ParseExact(frmEntrance.TxtDateOfManu.Text, "dd.MM.yyyy.", culture),
                    DeadlineDate = DateTime.ParseExact(frmEntrance.TxtDateOfManu.Text, "dd.MM.yyyy.", culture).AddYears(1),
                    NumOfBoxes = float.Parse(frmEntrance.TxtQuantity.Text)
                };
                Items.Add(ei);
                bindingList.Add(ei);
                NewItemReload1(ei,frmEntrance);
                frmEntrance.LblTotalWeight.Text = GetTotalWeight().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void Save(FrmEntrance frmEntrance)
        {
            if (string.IsNullOrEmpty(frmEntrance.LblTotalWeight.Text))
            {
                MessageBox.Show("Nema podataka!");
                return;
            }

            double TotalWeight = double.Parse(frmEntrance.LblTotalWeight.Text);

            try
            {
                Entrance.TotalWeight = TotalWeight;
                Entrance.Items = Items;
                Communication.Communication.Instance.AddEntrance(Entrance);
                MessageBox.Show("Uspešno sačuvan");
                frmEntrance.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void NewItemReload1(EntranceItems ei, FrmEntrance frmEntrance)
        {
            FrmEntrance.num += 1;
            frmEntrance.TxtNum.Text = FrmEntrance.num.ToString();
            frmEntrance.TxtQuantity.Text = "";
            frmEntrance.TxtDateOfEntrance.Text = "";
            frmEntrance.TxtArtikal.Text = "";
            frmEntrance.DGVItems.DataSource = bindingList;
            frmEntrance.DGVItems.Columns["EntranceId"].Visible = false;
            frmEntrance.DGVItems.Columns["DeadlineDate"].HeaderText = "Rok trajanja";
            frmEntrance.DGVItems.Columns["DateOfManu"].HeaderText = "Datum proizvodnje";
            frmEntrance.DGVItems.Columns["RobaId"].Visible = false;
            frmEntrance.DGVItems.Columns["Deadline"].Visible = false;

        }

        internal void RemoveFromList(FrmEntrance frmEntrance)
        {
            if (frmEntrance.DGVItems.Rows.Count == 0)
            {
                MessageBox.Show("Nema podataka");
                return;
            }
            try
            {
                EntranceItems ei = new EntranceItems();
                DataGridViewRow row = frmEntrance.DGVItems.SelectedRows[0];
                ei = (EntranceItems)row.DataBoundItem;
                bindingList.Remove(ei);
                Items.Remove(ei);
                frmEntrance.LblTotalWeight.Text = GetTotalWeight().ToString();
                NewItemReload2(Items,frmEntrance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void NewItemReload2(List<EntranceItems> items, FrmEntrance frmEntrance)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Num = i + 1;
            }
            FrmEntrance.num -= 1;
            frmEntrance.TxtNum.Text = FrmEntrance.num.ToString();
            frmEntrance.TxtQuantity.Text = "";
            frmEntrance.TxtDateOfEntrance.Text = "";
            frmEntrance.TxtArtikal.Text = "";
            frmEntrance.DGVItems.DataSource = bindingList;
        }

        public double GetTotalWeight()
        {
            double suma = 0;
            foreach (EntranceItems ei in bindingList)
            {
                suma += ei.NumOfBoxes * Communication.Communication.Instance.GetWeightOfBox(ei.RobaId);
            }
            return suma;
        }

    }
}
