using Domain;
using FrmLogin.Communication;
using FrmLogin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.Controllers
{
    public class PositionController
    {
        public PositionController()
        {

        }

        private string kolona;
        private string red;
        private string pm;
        private string vertikala;
        internal void InitDataGridViews(FrmPositioning frmPositioning)
        {
            frmPositioning.DGVEntrances.DataSource = Communication.Communication.Instance.GetAllEntrances();
            frmPositioning.DGVPositions.DataSource = Communication.Communication.Instance.GetAllPositions();
        }

        internal void SearchPosition(FrmPositioning frmPositioning)
        {
            kolona = frmPositioning.TxtKolona.Text;
            red = frmPositioning.TxtRed.Text;
            pm = frmPositioning.TxtPM.Text;
            vertikala = frmPositioning.TxtVertikala.Text;

            try
            {
                frmPositioning.DGVPositions.DataSource = Communication.Communication.Instance.FindPositions(ReturnSearchItem());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string ReturnSearchItem()
        {
            string item = "";
            if (kolona == "") item += "_";
            else item += kolona;
            if (red == "") item += "_";
            else item += red;
            if (pm == "") item += "_";
            else item += pm;
            if (vertikala == "") item += "_";
            else item += vertikala;
            return item;
        }

        internal void Refresh(FrmPositioning frmPositioning)
        {
            frmPositioning.TxtKolona.Text = "";
            frmPositioning.TxtRed.Text = "";
            frmPositioning.TxtPM.Text = "";
            frmPositioning.TxtVertikala.Text = "";
            frmPositioning.TxtEntranceId.Text = "";
            frmPositioning.TxtPositionId.Text = "";
            frmPositioning.DGVPositions.DataSource = Communication.Communication.Instance.GetAllPositions();
            frmPositioning.DGVEntrances.DataSource = Communication.Communication.Instance.GetAllEntrances();
        }

        internal void Restart()
        {
            try
            {
                Communication.Communication.Instance.RestartDatabase();
                MessageBox.Show("Uspesan Update Baze - Pozdrav");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void ReturnSelectedPosition(FrmPositioning frmPositioning)
        {
            try
            {
                DataGridViewRow row = frmPositioning.DGVPositions.SelectedRows[0];
                Position p = (Position)row.DataBoundItem;
                frmPositioning.TxtPositionId.Text = p.PositionId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void Connect(FrmPositioning frmPositioning)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(frmPositioning.TxtEntranceId) | UserControlHelpers.IsNullOrWhiteSpace(frmPositioning.TxtPositionId))
            {
                MessageBox.Show("Nema podataka za povezivanje!");
                return;
            }

            //EntrancePosition ep = new EntrancePosition
            //{
            //    EntranceId = int.Parse(frmPositioning.TxtEntranceId.Text),
            //    PositionId = frmPositioning.TxtPositionId.Text
            //};
            

            try
            {
                //Communication.Communication.Instance.AddEntrancePosition(ep);
                Communication.Communication.Instance.UpdateEntranceAndPosition(frmPositioning.TxtEntranceId.Text, frmPositioning.TxtPositionId.Text);
                Refresh(frmPositioning);
                MessageBox.Show("Povezano");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void RestartFields(FrmPositioning frmPositioning)
        {
            frmPositioning.TxtPositionId.Text = "";
            frmPositioning.TxtEntranceId.Text = "";
        }

        internal void ReturnSelectedEntrance(FrmPositioning frmPositioning)
        {
            try
            {
                DataGridViewRow row = frmPositioning.DGVEntrances.SelectedRows[0];
                int entranceId = (int)row.Cells[0].Value;
                Entrance entrance = Communication.Communication.Instance.FindEntrance(entranceId);
                frmPositioning.TxtEntranceId.Text = entrance.EntranceId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
