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
    public partial class FrmGetAllRoba : Form
    {

        private readonly RobaController robaController;
        public FrmGetAllRoba(Controllers.RobaController robaController)
        {
            this.robaController = robaController;
            InitializeComponent();
            robaController.InitDataGridView(this);
        }

        public DataGridView DGVRoba { get => dgvRoba; }
        public DataGridViewRow Row{ get; set; }
        private void dgvRoba_DoubleClick(object sender, EventArgs e)
        {
            robaController.DoubleClickDataGridView(this);
        }

        public override void Refresh()
        {
            robaController.Refresh(this);
        }
    }
}
