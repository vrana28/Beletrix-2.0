using Domain;
using FrmLogin.FrmEnter;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.Controllers
{
    public class FindProductController
    {
        public FindProductController()
        {

        }
        
        private string kolona;
        private string red;
        private string pm;
        private string vertikala;
        public Client Client { get; set; }
        public Roba Roba { get; set; }
        internal void OpenFrmEnterClient(FrmFind frmFind)
        {
            FrmEnterClient frmEnterClients = new FrmEnterClient(frmFind,new Controllers.ClientsController());
            frmEnterClients.ShowDialog();
            Client = Communication.Communication.Instance.ReturnClient(frmFind.TxtClient.Text);
        }

        internal void OpenFrmEnterArtikal(FrmFind frmFind)
        {
            FrmEnterArtikal frmEnterArtikal =new FrmEnterArtikal(frmFind, new Controllers.RobaController());
            frmEnterArtikal.ShowDialog();
            Roba = Communication.Communication.Instance.ReturnRoba(frmFind.TxtArtikal.Text);
        }

        internal void SearchWithClientAndProduct(FrmFind frmFind)
        {
            try
            {
                frmFind.DGVSearchResult.DataSource = null;
                frmFind.DGVSearchResult.DataSource = Communication.Communication.Instance.SearchProductWith(Client, Roba);
                frmFind.LblStanje.Text = Izracunaj(frmFind);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void SearchWithoutClient(FrmFind frmFind)
        {
            try
            {
                frmFind.TxtClient.Text = "";
                Client = null;
                frmFind.DGVSearchResult.DataSource = null;
                frmFind.DGVSearchResult.DataSource = Communication.Communication.Instance.FindBusyPosition(Client, Roba);
                frmFind.LblStanje.Text = Izracunaj(frmFind);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void SearchWithoutRoba(FrmFind frmFind)
        {
            try
            {
                frmFind.TxtArtikal.Text = "";
                Roba = null;
                frmFind.DGVSearchResult.DataSource = null;
                frmFind.DGVSearchResult.DataSource = Communication.Communication.Instance.FindBusyPosition(Client, Roba);
                frmFind.LblStanje.Text = Izracunaj(frmFind);
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

        internal void Print(FrmFind frmFind)
        {

            if (frmFind.DGVSearchResult.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Pretraga.pdf";
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
                            PdfPTable pdfTable = new PdfPTable(frmFind.DGVSearchResult.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in frmFind.DGVSearchResult.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in frmFind.DGVSearchResult.Rows)
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
                                    DefaultCell = { MinimumHeight = 22f}
                                };
                                var culture = new CultureInfo("de-DE");
                                headerTable.AddCell("Date");
                                headerTable.AddCell(DateTime.Now.ToString(culture));
                                headerTable.AddCell("Klijent:");
                                if (Client == null)
                                {
                                    headerTable.AddCell("");
                                }
                                else {
                                    headerTable.AddCell(Client.Name);                                    
                                }
                                headerTable.AddCell("Stanje:");
                                headerTable.AddCell(frmFind.LblStanje.Text);

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

        internal void Load(FrmFind frmFind)
        {
            try
            {
                frmFind.DGVSearchResult.DataSource = null;
                frmFind.DGVSearchResult.DataSource = Communication.Communication.Instance.FindBusyPosition(Client, Roba);
                frmFind.LblStanje.Text = Izracunaj(frmFind);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string Izracunaj(FrmFind frmFind)
        {
            double stanje = 0;
            DataGridViewRow row;
            if (frmFind.DGVSearchResult.Rows.Count!=0) {
                for (int i = 0; i < frmFind.DGVSearchResult.Rows.Count; i++) {
                    row = frmFind.DGVSearchResult.Rows[i];
                    stanje += (double)row.Cells[3].Value;
                }
            }
            return stanje.ToString() + " kg";
        }

        internal void Search(FrmFind frmFind)
        {
            kolona = frmFind.TxtKolona.Text;
            red = frmFind.TxtRed.Text;
            pm = frmFind.TxtPm.Text;
            vertikala = frmFind.TxtVertikala.Text;
            try
            {
                frmFind.DGVSearchResult.DataSource = null;
                frmFind.DGVSearchResult.DataSource = Communication.Communication.Instance.FindBusyPositionsWithPosition(Client, Roba, ReturnSearchItem());
                frmFind.LblStanje.Text = Izracunaj(frmFind);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
