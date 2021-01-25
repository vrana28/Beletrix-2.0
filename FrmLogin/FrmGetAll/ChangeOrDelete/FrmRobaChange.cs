using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Domain;
using FrmLogin.Controllers;
using FrmLogin.Helpers;

namespace FrmLogin.FrmGetAll.ChangeOrDelete
{
    public partial class FrmRobaChange : Form
    {
        private readonly RobaController robaController;
        public FrmRobaChange(Controllers.RobaController robaController, DataGridViewRow r)
        {
            this.robaController = robaController;
            InitializeComponent();
            robaController.InitTextBoxes(this, r);
            Row = r;
        }

        public TextBox TxtName { get=>txtName; }
        public TextBox TxtWeightOfBox{ get=>txtWeightOfBox; }
        public DataGridViewRow Row { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            robaController.Update(this, Row);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            robaController.Delete(this, Row);
        }
    }
}
