using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using FrmLogin;
using FrmLogin.Controllers;
using FrmLogin.FrmAdd;
using FrmLogin.FrmEnter;
using FrmLogin.FrmGetAll;
using FrmLogin.FrmGetAll.ChangeOrDelete;

namespace FrmLogin
{
    public class MainCoordinator
    {
        private static MainCoordinator instance;
        public FrmLogin frmLogin;
        public FrmMain frmMain;
        public FrmAddStorekeeper frmAddStorekeeper;
        public FrmAddClient frmAddClient;
        public FrmGetAllClients frmGetAllClients;
        public FrmClientChange frmClientChange;
        public FrmGetAllStorekeepers frmGetAllStorekeepers;
        public FrmStorekeeperChange frmStorekeeperChange;
        public FrmAddRoba frmAddRoba;
        public FrmGetAllRoba frmGetAllRoba;
        public FrmRobaChange frmRobaChanged;
        public FrmEntrance frmEntrance;
        public FrmEnterClient frmEnterClient;
        public FrmPositioning frmPositioning;
        public FrmFind frmFind;
        public FrmExit frmExit;

        private LoginController loginController = new LoginController();
        private MainController mainController = new MainController();

        public MainCoordinator()
        {

        }

        public Storekeeper Storekeeper { get; set; }
        public static MainCoordinator Instance {
            get {
                if (instance == null) instance = new MainCoordinator();
                return instance;
            }
        }

        internal void OpenGetAllRoba(RobaController robaController)
        {
            
        }

        public void OpenLoginForm()
        {
            frmLogin = new FrmLogin(loginController);
            frmLogin.Show();
        }

        public void OpenMainForm(Storekeeper s)
        {
            frmLogin.Dispose();
            frmMain = new FrmMain(s, mainController);
            frmMain.Show();
        }

        // NA DOLE SE BRISE LOLOLOLOL
        public void OpenFrmExit(LeavingItemsController leavingItemsController)
        {
            frmExit = new FrmExit(leavingItemsController);
            frmExit.ShowDialog();
        }
        public void OpenFrmPositioning(PositionController positionController)
        {
            frmPositioning = new FrmPositioning(positionController);
            frmPositioning.ShowDialog();
        }

        public void OpenAddFormStorekeeper(StorekeeperController storekeeperController)
        {
            frmAddStorekeeper = new FrmAddStorekeeper(storekeeperController);
            frmAddStorekeeper.ShowDialog();
        }

        internal void OpenFrmStorekeeperChange(DataGridViewRow row, StorekeeperController storekeeperController)
        {
            frmStorekeeperChange = new FrmStorekeeperChange(row,storekeeperController);
            frmStorekeeperChange.ShowDialog();
        }

        public void OpenAddFormClient(ClientsController clientsController)
        {
            frmAddClient = new FrmAddClient(clientsController);
            frmAddClient.ShowDialog();
        }

        public void OpenGetAllClients(ClientsController clientsController)
        {
            frmGetAllClients = new FrmGetAllClients(clientsController);
            frmGetAllClients.ShowDialog();
        }

        public void OpenFrmClientChange(ClientsController clientsController, DataGridViewRow row)
        {
            frmClientChange = new FrmClientChange(clientsController, row);
            frmClientChange.ShowDialog();

        }

        public void OpenFrmGetAllStorekeepers(StorekeeperController storekeeperController)
        {
            frmGetAllStorekeepers = new FrmGetAllStorekeepers(storekeeperController);
            frmGetAllStorekeepers.ShowDialog();
        }

        public void OpenFrmGetAllRoba(RobaController robaController)
        {
            frmGetAllRoba = new FrmGetAllRoba(robaController);
            frmGetAllRoba.ShowDialog();
        }

        public void OpenFrmAddRoba(RobaController robaController)
        {
            frmAddRoba = new FrmAddRoba(robaController);
            frmAddRoba.ShowDialog();
        }

        public void OpenFrmDeleteRoba(RobaController robaController, DataGridViewRow r)
        {
            frmRobaChanged = new FrmRobaChange(robaController, r);
            frmRobaChanged.ShowDialog();
        }

        public void OpenFrmEntrance(EntranceController entranceController)
        {
            frmEntrance = new FrmEntrance(entranceController);
            frmEntrance.ShowDialog();
        }

        public void OpenFrmEnterClient()
        {
            frmEnterClient = new FrmEnterClient(new Controllers.ClientsController());
            frmEnterClient.ShowDialog();
        }

        public void OpenFrmFind(FindProductController findProductController)
        {
            frmFind = new FrmFind(findProductController);
            frmFind.ShowDialog();
        }

    }
}
