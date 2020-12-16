using Controller;
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
using Domain;


namespace FrmLogin
{
    public partial class FrmAddStorekeeper : Form
    {
        public FrmAddStorekeeper()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(txtName) | UserControlHelpers.IsNullOrWhiteSpace(txtLastName)
                | UserControlHelpers.IsNullOrWhiteSpace(txtUsername) | UserControlHelpers.IsNullOrWhiteSpace(txtPassword)) {

                return;
            }

            Storekeeper s = new Storekeeper {
                Name = txtName.Text,
                LastName = txtLastName.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            try
            {
                if (Controler.Instance.FindStorekeeper(s)) {
                    MessageBox.Show("Already exist!");
                    UserControlHelpers.ResetTxt(txtUsername);
                    return;
                }
                Controler.Instance.AddStorekeeper(s);
                MessageBox.Show("Saved");
                this.Dispose();
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);
            }

            

        }
    }
}
