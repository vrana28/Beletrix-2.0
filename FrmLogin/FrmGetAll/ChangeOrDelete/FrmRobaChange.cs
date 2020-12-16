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
using FrmLogin.Helpers;

namespace FrmLogin.FrmGetAll.ChangeOrDelete
{
    public partial class FrmRobaChange : Form
    {
        public FrmRobaChange(Roba r)
        {
            InitializeComponent();
            txtName.Text = r.Name;
            txtWeightOfBox.Text = r.WeightOfBox.ToString();
            Roba = r;
        }

        private Roba Roba { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(txtName))
            {

                return;
            }

            if (!UserControlHelpers.IsValidDouble(txtWeightOfBox.Text))
            {
                MessageBox.Show("Problem with weight box!");
                return;
            }

            Roba r = new Roba {
                RobaId = Roba.RobaId,
                Name = txtName.Text,
                WeightOfBox = double.Parse(txtWeightOfBox.Text)
            };

            try
            {
                Controler.Instance.UpdateRoba(r);
                MessageBox.Show("Roba updated!");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Controler.instance.DeleteRoba(Roba);
                    MessageBox.Show("Deleted!");
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                this.Dispose();
            }
        }
    }
}
