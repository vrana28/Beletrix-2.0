using Domain;
using FrmLogin.FrmEnter;
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
    public class ClientsController
    {

        public ClientsController()
        {

        }

        public Client Client{ get; set; }
        internal void InitdatagridView(FrmGetAllClients frmGetAllClients)
        {
            frmGetAllClients.DGVClients.DataSource = new BindingList<Client>(Communication.Communication.Instance.GetAllClients());
        }

        internal void InitEnterDataGridView(FrmEnterClient frmEnterClient)
        {
            frmEnterClient.DGVClientsToEnter.DataSource = new BindingList<Client>(Communication.Communication.Instance.GetAllClients());
        }

        internal void DoubleClickDataGridView(FrmGetAllClients frmGetAllClients)
        {
            try
            {
                if (frmGetAllClients.DGVClients.ColumnCount > 0)
                {
                    DataGridViewRow row = frmGetAllClients.DGVClients.SelectedRows[0];
                    //Client c = (Client)row.DataBoundItem;
                    MainCoordinator.Instance.OpenFrmClientChange(new Controllers.ClientsController(),row);
                }
                GetAllClients(frmGetAllClients); //refresh
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nema unetih podatak");
            }
        }

        internal void EnterClient(FrmEnterClient frmEnterClient, int signal)
        {
            switch (signal) {
                case 1:
                    DataGridViewRow row = frmEnterClient.DGVClientsToEnter.SelectedRows[0];
                    Client = (Client)row.DataBoundItem;
                    frmEnterClient.frmEntrance.TxtClient.Text = Client.Name;
                    frmEnterClient.Dispose();
                    break;
                case 2:
                    DataGridViewRow row1 = frmEnterClient.DGVClientsToEnter.SelectedRows[0];
                    Client = (Client)row1.DataBoundItem;
                    frmEnterClient.frmFind.TxtClient.Text = Client.Name;
                    frmEnterClient.Dispose();
                    break;
                case 3:
                    DataGridViewRow row2 = frmEnterClient.DGVClientsToEnter.SelectedRows[0];
                    Client = (Client)row2.DataBoundItem;
                    frmEnterClient.frmExit.TxtClient.Text = Client.Name;
                    frmEnterClient.Dispose();
                    break;
            }
        }

        internal void ClientChangeLoad(FrmGetAll.ChangeOrDelete.FrmClientChange frmClientChange, DataGridViewRow row)
        {
            Client c = (Client)row.DataBoundItem;
            frmClientChange.TxtName.Text = c.Name;
            frmClientChange.TxtPlace.Text = c.Place;
            frmClientChange.TxtPib.Text = c.PIB.ToString();
            frmClientChange.TxtTelephone.Text = c.Telephone.ToString();
            frmClientChange.TxtEmail.Text = c.Email;
        }

        internal void Update(FrmClientChange frmClientChange, DataGridViewRow row)
        {
            Client cl = (Client)row.DataBoundItem;

            if (UserControlHelpers.IsNullOrWhiteSpace(frmClientChange.TxtName) | UserControlHelpers.IsNullOrWhiteSpace(frmClientChange.TxtPlace)
               | UserControlHelpers.IsNullOrWhiteSpace(frmClientChange.TxtPib) | UserControlHelpers.IsNullOrWhiteSpace(frmClientChange.TxtTelephone)
               | UserControlHelpers.IsNullOrWhiteSpace(frmClientChange.TxtEmail))
            {

                return;
            }

            if (!UserControlHelpers.IsValidNumber(frmClientChange.TxtPib.Text) || !UserControlHelpers.IsValidNumber(frmClientChange.TxtTelephone.Text))
            {
                MessageBox.Show("Problem sa telefonom i PIB-om.");
                return;
            }

            if (!UserControlHelpers.IsValidEmail(frmClientChange.TxtEmail.Text))
            {
                MessageBox.Show("Problem sa email-om.");
                return;
            }

            Client c = new Client
            {
                ClientId = cl.ClientId,
                Name = frmClientChange.TxtName.Text,
                Place = frmClientChange.TxtPlace.Text,
                PIB = int.Parse(frmClientChange.TxtPib.Text),
                Telephone = int.Parse(frmClientChange.TxtTelephone.Text),
                Email = frmClientChange.TxtEmail.Text
            };

            try
            {

                Communication.Communication.Instance.UpdateClient(c);
                MessageBox.Show("Client update-ovan!");
                frmClientChange.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void Delete(FrmClientChange frmClientChange,DataGridViewRow row)
        {
            Client cl = (Client)row.DataBoundItem;

            var confirmResult = MessageBox.Show("Da li ste sigurni za brisanje klijenta??",
                                     "Potvrdi brisanje!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Communication.Communication.Instance.DeleteClient(cl);
                    MessageBox.Show("Obrisano!");
                    frmClientChange.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                frmClientChange.Dispose();
            }
        }

        internal void Save(FrmAddClient frmAddClient)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(frmAddClient.TxtName) | UserControlHelpers.IsNullOrWhiteSpace(frmAddClient.TxtPlace)
              | UserControlHelpers.IsNullOrWhiteSpace(frmAddClient.TxtPib) | UserControlHelpers.IsNullOrWhiteSpace(frmAddClient.TxtTelephone)
              | UserControlHelpers.IsNullOrWhiteSpace(frmAddClient.TxtEmail))
            {

                return;
            }

            if (!UserControlHelpers.IsValidNumber(frmAddClient.TxtPib.Text) || !UserControlHelpers.IsValidNumber(frmAddClient.TxtTelephone.Text))
            {
                MessageBox.Show("Problem sa telephone or PIB");
                return;
            }

            if (!UserControlHelpers.IsValidEmail(frmAddClient.TxtEmail.Text))
            {
                MessageBox.Show("Problem sa email-om.");
                return;
            }

            Client c = new Client
            {
                Name = frmAddClient.TxtName.Text,
                Place = frmAddClient.TxtPlace.Text,
                PIB = int.Parse(frmAddClient.TxtPib.Text),
                Telephone = int.Parse(frmAddClient.TxtTelephone.Text),
                Email = frmAddClient.TxtEmail.Text
            };

            try
            {
                if (Communication.Communication.Instance.FindClient(c))
                {
                    MessageBox.Show("Već postoji!");
                    UserControlHelpers.ResetTxt(frmAddClient.TxtPib);
                    UserControlHelpers.ResetTxt(frmAddClient.TxtName);
                    return;
                }
                Communication.Communication.Instance.SaveClient(c);
                MessageBox.Show("Klijent je sačuvan!");
                frmAddClient.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void GetAllClients(FrmGetAllClients frmGetAllClients)
        {
            frmGetAllClients.DGVClients.DataSource = null;
            frmGetAllClients.DGVClients.DataSource = Communication.Communication.Instance.GetAllClients();

        }

    }
}
