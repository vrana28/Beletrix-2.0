using Controller;
using Domain;
using FrmLogin.FrmEnter;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
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
        public string kolona;
        public string red;
        public string pm;
        public string vertikala;

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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            kolona = txtKolona.Text;
            red = txtReds.Text;
            pm = txtPaletnoMesto.Text;
            vertikala = txtVertikala.Text;
            try
            {
                dgvSearchResult.DataSource = null;
                dgvSearchResult.DataSource = Controler.Instance.FindBusyPositionsWithPosition(Client,Roba,ReturnSearchItem());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvSearchResult.Rows.Count > 0)
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
                            PdfPTable pdfTable = new PdfPTable(dgvSearchResult.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dgvSearchResult.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgvSearchResult.Rows)
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
    }
}
