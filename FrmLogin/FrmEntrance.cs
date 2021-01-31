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
using Domain;
using FrmLogin.Controllers;
using FrmLogin.FrmEnter;
using FrmLogin.Helpers;

namespace FrmLogin
{
    public partial class FrmEntrance : Form
    {
        public BindingList<EntranceItems> bindingList = new BindingList<EntranceItems>();
        private readonly EntranceController entranceController;
        public FrmEntrance(Controllers.EntranceController entranceController)
        {
            this.entranceController = entranceController;
            InitializeComponent();
            lblMagacioner.Text = $"{Controllers.LoginController.Storekeeper.Name} {Controllers.LoginController.Storekeeper.LastName}";
            var culture = new CultureInfo("de-DE");
            txtDateOfEntrance.Text = DateTime.Now.ToString(culture);
            EntranceDate = DateTime.Now;
            num = 1;
            txtNum.Text = num.ToString();
        }

        public static int num;
        public DataGridView DGVItems { get => dgvItems; }
        public RichTextBox RTxtDimension{ get => rtbVrstaPalete; }
        public DateTime EntranceDate { get; set; }
        public TextBox TxtQuantity { get => txtQuantity; }
        public TextBox TxtNum { get => txtNum; }
        public TextBox TxtDateOfDeadline { get => txtDeadlineDate; }
        public TextBox TxtDateOfEntrance{ get =>txtDateOfEntrance; }
        public TextBox TxtDateOfManu{ get => txtDateOfMan; }
        public TextBox TxtClient { get => txtClient; }
        public TextBox TxtArtikal { get => txtArtikal; }
        public Label LblTotalWeight{ get => lblTotalWeight; }


        private void btnChooseClient_Click(object sender, EventArgs e)
        {
            entranceController.OpenFrmEnterClient(this);
        }

        private void btnChooseArtikal_Click(object sender, EventArgs e)
        {
            entranceController.OpenFrmEnterArtikal(this);
        }

        private void btnAddToItems_Click(object sender, EventArgs e)
        {
            entranceController.AddItems(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            entranceController.RemoveFromList(this);
        }

        private void btnSaveComplete_Click(object sender, EventArgs e)
        {
            entranceController.Save(this);
        }
    }
}
