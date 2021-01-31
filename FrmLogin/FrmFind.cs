
using Domain;
using FrmLogin.Controllers;
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
        private readonly FindProductController findProductController;
        public FrmFind(Controllers.FindProductController findProductController)
        {
            this.findProductController = findProductController;
            InitializeComponent();
        }

        public TextBox TxtKolona { get => txtKolona; }
        public TextBox TxtRed { get => txtRed; }
        public TextBox TxtPm { get => txtPaletnoMesto; }
        public TextBox TxtVertikala { get => txtVertikala; }
        public TextBox TxtClient{ get => txtClient; }
        public TextBox TxtArtikal{ get => txtArtikal; }
        public DataGridView DGVSearchResult{ get => dgvSearchResult; }
        public Label LblStanje{ get => lblStanje; }


        //choose client button
        private void button1_Click(object sender, EventArgs e)
        {
            findProductController.OpenFrmEnterClient(this);
        }

        // choose product button
        private void button2_Click(object sender, EventArgs e)
        {
            findProductController.OpenFrmEnterArtikal(this);
        }

        // search, sa klijentom i productom
        private void button4_Click(object sender, EventArgs e)
        {
            findProductController.SearchWithClientAndProduct(this);
        }
        // pretrazuj bez klijenta
        private void btnRoba_Click(object sender, EventArgs e)
        {
            findProductController.SearchWithoutClient(this);
        }

        //pretrazuj bez robe
        private void button6_Click(object sender, EventArgs e)
        {
            findProductController.SearchWithoutRoba(this);
        }

        private void FrmFind_Load(object sender, EventArgs e)
        {
            findProductController.Load(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            findProductController.Search(this);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            findProductController.Print(this);
        }
    }
}
