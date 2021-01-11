using FrmLogin.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmLogin.Controllers
{
    public class MainController
    {
        internal void OpenUCMap(FrmMain frmMain)
        {
            frmMain.PanelMethod(new UCMap());
        }

        internal void CloseMainForm()
        {
            Communication.Communication.Instance.Disconnect();
            MainCoordinator.Instance.OpenLoginForm();
        }
    }
}
