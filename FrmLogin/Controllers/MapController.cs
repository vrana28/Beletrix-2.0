using FrmLogin.Helpers;
using FrmLogin.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.Controllers
{
    public class MapController
    {

        public MapController()
        {

        }

        internal void Find(UCMap uCMap)
        {
            MainCoordinator.Instance.OpenFrmFind(new Controllers.FindProductController());
        }

        internal void OpenFrmEntrance(UCMap uCMap)
        {
            MainCoordinator.Instance.OpenFrmEntrance(new Controllers.EntranceController());
        }

        internal void OpenFrmPositioning(UCMap uCMap)
        {
            MainCoordinator.Instance.OpenFrmPositioning(new Controllers.PositionController());
        }

        internal void LeavingItems(UCMap uCMap)
        {
            MainCoordinator.Instance.OpenFrmExit(new Controllers.LeavingItemsController());
        }

        internal void ShowPositin(UCMap uCMap, string pozicija)
        {
            string PositionId = pozicija + UserControlHelpers.CkeckedButtons(uCMap.RButtons).Text;
            MessageBox.Show(PositionId);
            try
            {
                uCMap.DGVStanjeNaPoziciji.DataSource = null;
                uCMap.DGVStanjeNaPoziciji.DataSource = Communication.Communication.Instance.ShowEntranceItems(PositionId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
