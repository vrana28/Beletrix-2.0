﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using FrmLogin;
using FrmLogin.FrmAdd;
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

        public MainCoordinator()
        {

        }

        public static MainCoordinator Instance {
            get {
                if (instance == null) instance = new MainCoordinator();
                return instance;
            }
        }

        public void OpenLoginForm() {
            frmLogin = new FrmLogin();
            frmLogin.Show();
        }

        public void OpenMainForm(Storekeeper s) {
            frmLogin.Dispose();
            frmMain = new FrmMain(s);
            frmMain.Show();
        }

        public void OpenAddFormStorekeeper() {
            frmAddStorekeeper = new FrmAddStorekeeper();
            frmAddStorekeeper.ShowDialog();
        }

        internal void OpenFrmStorekeeperChange(Storekeeper s)
        {
            frmStorekeeperChange = new FrmStorekeeperChange(s);
            frmStorekeeperChange.ShowDialog();
        }

        public void OpenAddFormClient() {
            frmAddClient = new FrmAddClient();
            frmAddClient.ShowDialog();
        }

        public void OpenDeleteFormForClients() {
            frmGetAllClients = new FrmGetAllClients();
            frmGetAllClients.ShowDialog();
        }

        public void OpenFrmClientChange(Client c) {
            frmClientChange = new FrmClientChange(c);
            frmClientChange.ShowDialog();

        }

        public void OpenFrmGetAllStorekeepers() {
            frmGetAllStorekeepers = new FrmGetAllStorekeepers();
            frmGetAllStorekeepers.ShowDialog();
        }

        public void OpenFrmGetAllRoba() {
            frmGetAllRoba = new FrmGetAllRoba();
            frmGetAllRoba.ShowDialog();
        }

        public void OpenFrmAddRoba() {
            frmAddRoba = new FrmAddRoba();
            frmAddRoba.ShowDialog();
        }

        public void OpenFrmDeleteRoba(Roba r) {
            frmRobaChanged = new FrmRobaChange(r);
            frmRobaChanged.ShowDialog();
        }

    }
}