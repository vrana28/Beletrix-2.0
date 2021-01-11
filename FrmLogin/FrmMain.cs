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
            lblUser.Text = $"{s.Name} {s.LastName}";
            this.mainController = mainController;
        }

        

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
                mainController.OpenUCMap(this);
        }

        // PANEL METODA GLAVNA
        public void PanelMethod(UserControl userControl)
        {
            pnlMain.Controls.Clear();
            userControl.Parent = pnlMain;
            userControl.Dock = DockStyle.Fill;

        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PanelMethod(new UCMap());
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
            MainCoordinator.Instance.OpenAddFormStorekeeper();
        }

        private void addClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.OpenAddFormClient();
        }

        private void clientsDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.OpenGetAllClients();
        }

        private void storekeepersdeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.OpenFrmGetAllStorekeepers();
        }

        private void addRobuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.OpenFrmAddRoba();
        }

        private void robedeleteupdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainCoordinator.Instance.OpenFrmGetAllRoba();
        }
    }
}
