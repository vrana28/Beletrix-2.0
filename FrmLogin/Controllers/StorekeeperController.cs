using Domain;
using FrmLogin.Exceptions;
using FrmLogin.FrmGetAll;
using FrmLogin.FrmGetAll.ChangeOrDelete;
using FrmLogin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.Controllers
{
    public class StorekeeperController
    {

        public StorekeeperController()
        {

        }

        public Storekeeper Storekeeper{ get; set; }

        internal void InitDataGridView(FrmGetAllStorekeepers frmGetAllStorekeepers)
        {
            frmGetAllStorekeepers.DgvStoreKeepers.DataSource = new BindingList<Storekeeper>(Communication.Communication.Instance.GetAllStorekeepers());
        }

        internal void Refresh(FrmGetAllStorekeepers frmGetAllStorekeepers)
        {
            frmGetAllStorekeepers.DgvStoreKeepers.DataSource = null;
            frmGetAllStorekeepers.DgvStoreKeepers.DataSource = Communication.Communication.Instance.GetAllStorekeepers();
        }

        internal void Update(FrmStorekeeperChange frmStorekeeperChange, DataGridViewRow row)
        {
            Storekeeper = (Storekeeper)row.DataBoundItem;

            if (UserControlHelpers.IsNullOrWhiteSpace(frmStorekeeperChange.TxtName) | UserControlHelpers.IsNullOrWhiteSpace(frmStorekeeperChange.TxtLastName)
               | UserControlHelpers.IsNullOrWhiteSpace(frmStorekeeperChange.TxtPassword) | UserControlHelpers.IsNullOrWhiteSpace(frmStorekeeperChange.TxtPassword))
            {

                return;
            }

            Storekeeper s = new Storekeeper
            {
                StorekeeperId = Storekeeper.StorekeeperId,
                Name = frmStorekeeperChange.TxtName.Text,
                LastName = frmStorekeeperChange.TxtLastName.Text,
                Username = frmStorekeeperChange.TxtUsername.Text,
                Password = frmStorekeeperChange.TxtPassword.Text
            };
            try
            {
                Communication.Communication.Instance.UpdateStorekeeper(s);
                MessageBox.Show("Magacioner je update-ovan!");
                frmStorekeeperChange.Dispose();
            }
            catch (SystemOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void Delete(FrmStorekeeperChange frmStorekeeperChange, DataGridViewRow row)
        {
            Storekeeper = (Storekeeper)row.DataBoundItem;
            var confirmResult = MessageBox.Show("Da li ste sigurni da želite da obrišete magacinera??",
                                "Potvrdi brisanje!!",
                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Communication.Communication.Instance.DeleteStorekeeper(Storekeeper);
                    MessageBox.Show("Obrisano");
                    frmStorekeeperChange.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                frmStorekeeperChange.Dispose();
            }
        }

        internal void InitTextBoxes(FrmStorekeeperChange frmStorekeeperChange, DataGridViewRow row)
        {
            Storekeeper = (Storekeeper)row.DataBoundItem;
            frmStorekeeperChange.TxtName.Text = Storekeeper.Name;
            frmStorekeeperChange.TxtLastName.Text = Storekeeper.LastName;
            frmStorekeeperChange.TxtUsername.Text = Storekeeper.Username;
            frmStorekeeperChange.TxtPassword.Text = Storekeeper.Password;
        }

        internal void DoubleClickDataGridView(FrmGetAllStorekeepers frmGetAllStorekeepers)
        {
            try
            {
                if (frmGetAllStorekeepers.DgvStoreKeepers.ColumnCount > 0)
                {
                    DataGridViewRow row = frmGetAllStorekeepers.DgvStoreKeepers.SelectedRows[0];
                    MainCoordinator.Instance.OpenFrmStorekeeperChange(row,new Controllers.StorekeeperController());
                }
                Refresh(frmGetAllStorekeepers);
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void Save(FrmAddStorekeeper frmAddStorekeeper)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(frmAddStorekeeper.TxtName) | UserControlHelpers.IsNullOrWhiteSpace(frmAddStorekeeper.TxtLastName)
                | UserControlHelpers.IsNullOrWhiteSpace(frmAddStorekeeper.TxtLastName) | UserControlHelpers.IsNullOrWhiteSpace(frmAddStorekeeper.TxtPassword))
            {

                return;
            }

            Storekeeper s = new Storekeeper
            {
                Name = frmAddStorekeeper.TxtName.Text,
                LastName = frmAddStorekeeper.TxtLastName.Text,
                Username = frmAddStorekeeper.TxtUsername.Text,
                Password = frmAddStorekeeper.TxtPassword.Text
            };

            try
            {
                if (Communication.Communication.Instance.FindStorekeeper(s)) {
                    MessageBox.Show("Već postoji!");
                    frmAddStorekeeper.TxtUsername.Text = "";
                    return;
                }
                Communication.Communication.Instance.SaveStorekeeper(s);
                MessageBox.Show("Magacioner je sačuvan!");
                frmAddStorekeeper.Dispose();
            }
            catch (SystemOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
