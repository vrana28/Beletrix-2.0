using Domain;
using FrmLogin.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.Controllers
{
    public class MainController
    {
        internal void OpenUCMap(FrmMain frmMain, Domain.Storekeeper user)
        {
            frmMain.PanelMethod(new UCMap(new Controllers.MapController()));
            User = user;
        }

        public static Storekeeper  User{ get; set; }
        internal void CloseMainForm()
        {
            Communication.Communication.Instance.Disconnect();
            MainCoordinator.Instance.OpenLoginForm();
        }

        internal void OpenAddFormStorekeeper(FrmMain frmMain)
        {
            MainCoordinator.Instance.OpenAddFormStorekeeper(new Controllers.StorekeeperController());
        }

        internal void OpenGetAllStorekeepers(FrmMain frmMain)
        {
            MainCoordinator.Instance.OpenFrmGetAllStorekeepers(new Controllers.StorekeeperController());
        }

        internal void OpenAddClients(FrmMain frmMain)
        {
            MainCoordinator.Instance.OpenAddFormClient(new Controllers.ClientsController());
        }

        internal void PanelMethod(FrmMain frmMain, UserControl userControl)
        {
            frmMain.PnlMain.Controls.Clear();
            userControl.Parent = frmMain.PnlMain;
            userControl.Dock = DockStyle.Fill;
        }

        internal void OpenGetAllClients(FrmMain frmMain)
        {
            MainCoordinator.Instance.OpenGetAllClients(new Controllers.ClientsController());
        }

        internal void OpenAddRoba(FrmMain frmMain)
        {
            MainCoordinator.Instance.OpenFrmAddRoba(new Controllers.RobaController());
        }

        internal void OpenGetAllRoba(FrmMain frmMain)
        {
            MainCoordinator.Instance.OpenFrmGetAllRoba(new Controllers.RobaController());
        }

        internal void OpenGetAllEntrances(FrmMain frmMain)
        {
            MainCoordinator.Instance.OpenFrmGetAllEntrances(new Controllers.EntranceController());
        }

        internal void OpenGetAllLeavingEntraces(FrmMain frmMain)
        {
            MainCoordinator.Instance.OpenFrmGetAllLeavingEntrances(new Controllers.EntranceController());
        }
    }
}
