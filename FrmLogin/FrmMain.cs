using FrmLogin.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using FrmLogin.Controllers;

namespace FrmLogin
{
    public partial class FrmMain : Form
    {
        private MainController mainController = new MainController();
        public FrmMain(Storekeeper s, Controllers.MainController mainController)
        {
            InitializeComponent();
            LblUser.Text = $"{Controllers.LoginController.Storekeeper.Name} {Controllers.LoginController.Storekeeper.LastName}";
            this.mainController = mainController;
            if (Controllers.LoginController.Storekeeper.Username != "admin" && Controllers.LoginController.Storekeeper.Password != "admin") {
                addStorekeeperToolStripMenuItem.Visible = false;
            }
        }

        public Panel PnlMain { get=>pnlMain; }
        public Label LblUser{ get => lblUser; }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            mainController.OpenUCMap(this,Controllers.MainController.User);
        }

        public void PanelMethod(UserControl userControl)
        {
            mainController.PanelMethod(this, userControl);
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PanelMethod(new UCMap(new Controllers.MapController()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainController.CloseMainForm();
        }

        private void addStorekeeperToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mainController.OpenAddFormStorekeeper(this);
        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenAddClients(this);
        }

        private void clientsDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenGetAllClients(this);
        }

        private void storekeepersdeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenGetAllStorekeepers(this);
        }

        private void addRobuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenAddRoba(this);
        }

        private void robedeleteupdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.OpenGetAllRoba(this);
        }
    }
}
