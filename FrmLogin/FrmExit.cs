using Controller;
using Domain;
using FrmLogin.Controllers;
using FrmLogin.FrmEnter;
using FrmLogin.Helpers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin
{
    public partial class FrmExit : Form
    {

        private readonly LeavingItemsController leavingItemsController;
        public FrmExit(Controllers.LeavingItemsController leavingItemsController)
        {
            this.leavingItemsController = leavingItemsController;
            InitializeComponent();
            leavingItemsController.InitDataGridView(this);
        }

        public DataGridView DGVAllItems{ get => dgvSearchResultExit; }
        public DataGridView DGVSelectedtems { get => dgvItems; }
        public DataGridView DGVLeavingItems { get => dgvLeavingItems; }
        public TextBox TxtClient{ get => txtClient; }
        public TextBox TxtArtikal { get => txtArtikal; }
        public TextBox TxtKolona { get => txtKolona; }
        public TextBox TxtRed { get => txtRed; }
        public TextBox TxtPm { get => txtPaletnoMesto; }
        public TextBox TxtVertikala { get => txtVertikala; }
        public TextBox TxtNum { get => txtNum; }
        public TextBox TxtEntranceId { get => txtEntranceId; }
        public TextBox TxtName { get => txtName; }
        public TextBox TxtNumOfBoxes { get => txtNumOfBoxes; }
        public TextBox TxtDateOfLeaving { get => txtDateOfLeaving; }
        public Panel PnlIzmena{ get=>pnlIzmena; }
        public Label LblPozicija{ get=>lblPozicija; }

        public string kolona;
        public string red;
        public string pm;
        public string vertikala;

        // deo za izaberi klijenta
        private void Button1_Click(object sender, EventArgs e)
        {
            leavingItemsController.OpenFrmEnterClient(this);
        }

        // izaberi artikal
        private void button2_Click(object sender, EventArgs e)
        {
            leavingItemsController.OpenFrmEnterArtikal(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            leavingItemsController.Search(this);
        }

        private void dgvSearchResult_DoubleClick(object sender, EventArgs e)
        {
            leavingItemsController.DoubleClickDGVAllItems(this);
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            leavingItemsController.ExitOfEntrance(this);
        }
        #region Pomocne_metode
        public void RefreshGridView1() {
            leavingItemsController.RefreshGridView1(this);
        }

        #endregion
        // without Roba
        private void button6_Click(object sender, EventArgs e)
        {
            leavingItemsController.SearchWithoutRoba(this);
        }

        private void btnRoba_Click(object sender, EventArgs e)
        {
            leavingItemsController.SearchWithoutClient(this);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            leavingItemsController.Print(this);
        }

        private void btnIzlazDelaPalete_Click(object sender, EventArgs e)
        {
            leavingItemsController.IzlazDelaPalete(this);
        }

        private void btnAddLeavingItem_Click(object sender, EventArgs e)
        {
            leavingItemsController.AddLeavingItem(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            leavingItemsController.RemoveFromLeavingList(this);
        }

        private void btnIzlazDela_Click(object sender, EventArgs e)
        {

            leavingItemsController.IzlazDela(this);
        }
    }
}
