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
    public partial class FrmStorekeeperChange : Form
    {
        public FrmStorekeeperChange(Storekeeper s)
        {
            InitializeComponent();
            Storekeeper = s;
        }
        private Storekeeper Storekeeper { get; set; }

        private void FrmStorekeeperChange_Load(object sender, EventArgs e)
        {
            txtName.Text = Storekeeper.Name;
            txtLastName.Text = Storekeeper.LastName;
            txtUsername.Text = Storekeeper.Username;
            txtPassword.Text = Storekeeper.Password;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(txtName) | UserControlHelpers.IsNullOrWhiteSpace(txtLastName)
               | UserControlHelpers.IsNullOrWhiteSpace(txtUsername) | UserControlHelpers.IsNullOrWhiteSpace(txtPassword))
            {

                return;
            }

           

            Storekeeper s = new Storekeeper
            {
                StorekeeperId = Storekeeper.StorekeeperId,
                Name = txtName.Text,
                LastName = txtLastName.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            try
            {

                Controler.Instance.UpdateStorekeeper(s);
                MessageBox.Show("Storekeeper updated!");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    Controler.instance.DeleteStorekeeper(Storekeeper);
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
