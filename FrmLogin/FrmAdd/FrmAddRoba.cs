
using Domain;
using FrmLogin.Controllers;
using FrmLogin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.FrmAdd
{
    public partial class FrmAddRoba : Form
    {
        private readonly RobaController robaController;
        public FrmAddRoba(Controllers.RobaController robaController)
        {
            this.robaController = robaController;
            InitializeComponent();
            TxtWeightOfBox.Text = "1";
        }
        public TextBox TxtName { get => txtName; }
        public TextBox TxtWeightOfBox { get => txtWeightOfBox; }
        private void btnSave_Click(object sender, EventArgs e)
        {
            robaController.Save(this);
        }
    }
}
