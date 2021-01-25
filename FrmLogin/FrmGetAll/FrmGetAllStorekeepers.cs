using Controller;
using Domain;
using FrmLogin.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.FrmGetAll
{
    public partial class FrmGetAllStorekeepers : Form
    {
        public  BindingList<Storekeeper> keepers = new BindingList<Storekeeper>();
        private StorekeeperController storekeeperController;
        public FrmGetAllStorekeepers(Controllers.StorekeeperController storekeeperController)
        {
            this.storekeeperController = storekeeperController;
            InitializeComponent();
            storekeeperController.InitDataGridView(this);
  
        }

        public DataGridView DgvStoreKeepers { get => dgvStorekeepers; }

        public override void Refresh() {
            storekeeperController.Refresh(this);
        }

        private void dgvStorekeepers_DoubleClick(object sender, EventArgs e)
        {
            storekeeperController.DoubleClickDataGridView(this);
            
        }
    }
}
