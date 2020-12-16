using Controller;
using Domain;
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
        public FrmAddRoba( )
        {
            InitializeComponent();
        }

        private void FrmAddRoba_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(txtName))
            {

                return;
            }

            if (!UserControlHelpers.IsValidDouble(txtWeightOfBox.Text) )
            {
                MessageBox.Show("Problem weight of box");
                return;
            }

            Roba r = new Roba
            {
                Name = txtName.Text,
                WeightOfBox = double.Parse(txtWeightOfBox.Text)
            };

            try
            {
                if (Controler.Instance.FindRoba(r))
                {
                    MessageBox.Show("Already exist!");
                    UserControlHelpers.ResetTxt(txtName);
                    return;
                }
                Controler.Instance.AddRoba(r);
                MessageBox.Show("Client saved!");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
