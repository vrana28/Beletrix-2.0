using Domain;
using FrmLogin.FrmAdd;
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
    public class RobaController
    {
        public RobaController()
        {
                
        }

        public Roba Roba{ get; set; }

        internal void InitDataGridView(FrmGetAllRoba frmGetAllRoba)
        {
            frmGetAllRoba.DGVRoba.DataSource = new BindingList<Roba>(Communication.Communication.Instance.GetAllRoba());
        }

        internal void InitEnterDataGridView(FrmEnterArtikal frmEnterArtikal)
        {
            frmEnterArtikal.DGVArtikli.DataSource = new BindingList<Roba>(Communication.Communication.Instance.GetAllRoba());
        }

        internal void InitTextBoxes(FrmRobaChange frmRobaChange, DataGridViewRow r)
        {
            Roba = (Roba)r.DataBoundItem;
            frmRobaChange.TxtName.Text = Roba.Name;
            frmRobaChange.TxtWeightOfBox.Text = Roba.WeightOfBox.ToString();
            
        }

        internal void EnterArtikal(FrmEnterArtikal frmEnterArtikal, int signal)
        {
            switch (signal) {

                case 1:
                    DataGridViewRow row = frmEnterArtikal.DGVArtikli.SelectedRows[0];
                    Roba = (Roba)row.DataBoundItem;
                    frmEnterArtikal.frmEntrance.TxtArtikal.Text = Roba.Name;
                    frmEnterArtikal.Dispose();
                    break;
                case 2:
                    DataGridViewRow row1 = frmEnterArtikal.DGVArtikli.SelectedRows[0];
                    Roba = (Roba)row1.DataBoundItem;
                    frmEnterArtikal.frmFind.TxtArtikal.Text = Roba.Name;
                    frmEnterArtikal.Dispose();
                    break;
                case 3:
                    DataGridViewRow row2 = frmEnterArtikal.DGVArtikli.SelectedRows[0];
                    Roba = (Roba)row2.DataBoundItem;
                    frmEnterArtikal.FrmExit.TxtArtikal.Text = Roba.Name;
                    frmEnterArtikal.Dispose();
                    break;
            }
        }

        internal void Update(FrmRobaChange frmRobaChange, DataGridViewRow row)
        {
            Roba = (Roba)row.DataBoundItem;
            if (UserControlHelpers.IsNullOrWhiteSpace(frmRobaChange.TxtName))
            {

                return;
            }

            if (!UserControlHelpers.IsValidDouble(frmRobaChange.TxtWeightOfBox.Text))
            {
                MessageBox.Show("Problem sa težinom kutije!");
                return;
            }

            Roba r = new Roba
            {
                RobaId = Roba.RobaId,
                Name = frmRobaChange.TxtName.Text,
                WeightOfBox = double.Parse(frmRobaChange.TxtWeightOfBox.Text)
            };

            try
            {
                Communication.Communication.Instance.UpdateRoba(r);
                MessageBox.Show("Artikal je update-ovan!");
                frmRobaChange.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void Delete(FrmRobaChange frmRobaChange, DataGridViewRow row)
        {
            Roba = (Roba)row.DataBoundItem;
            var confirmResult = MessageBox.Show("Da li ste sigurni da želite da obrišete artikal??",
                                     "Potvrdi brisanje!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Communication.Communication.Instance.DeleteRoba(Roba);
                    MessageBox.Show("Obrisano!");
                    frmRobaChange.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                frmRobaChange.Dispose();
            }
        }

        internal void DoubleClickDataGridView(FrmGetAllRoba frmGetAllRoba)
        {
            try
            {
                if (frmGetAllRoba.DGVRoba.ColumnCount > 0)
                {
                    DataGridViewRow row = frmGetAllRoba.DGVRoba.SelectedRows[0];
                    //Roba r = (Roba)row.DataBoundItem;
                    MainCoordinator.Instance.OpenFrmDeleteRoba(new Controllers.RobaController(),row);
                }
               Refresh(frmGetAllRoba);
            }
            catch (Exception )
            {
                MessageBox.Show("Nema unetih podatak");
            }
        }

        internal void Refresh(FrmGetAllRoba frmGetAllRoba)
        {
            frmGetAllRoba.DGVRoba.DataSource = null;
            frmGetAllRoba.DGVRoba.DataSource = Communication.Communication.Instance.GetAllRoba();
        }

        internal void Save(FrmAddRoba frmAddRoba)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(frmAddRoba.TxtName))
            {

                return;
            }

            if (!UserControlHelpers.IsValidDouble(frmAddRoba.TxtWeightOfBox.Text))
            {
                MessageBox.Show("Problem sa tezinom kutije.");
                return;
            }

            Roba r = new Roba
            {
                Name = frmAddRoba.TxtName.Text,
                WeightOfBox = double.Parse(frmAddRoba.TxtWeightOfBox.Text)
            };


            try
            {
                if (Communication.Communication.Instance.FindRoba(r))
                {
                    MessageBox.Show("Već postoji!");
                    UserControlHelpers.ResetTxt(frmAddRoba.TxtName);
                    return;
                }
                Communication.Communication.Instance.AddRoba(r);
                MessageBox.Show("Artikal je sačuvan!");
                frmAddRoba.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
