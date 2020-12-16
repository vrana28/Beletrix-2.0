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

namespace FrmLogin
{
    public partial class FrmAddClient : Form
    {
        public FrmAddClient()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(txtName) | UserControlHelpers.IsNullOrWhiteSpace(txtPlace)
               | UserControlHelpers.IsNullOrWhiteSpace(txtPIB) | UserControlHelpers.IsNullOrWhiteSpace(txtTelephone)
               | UserControlHelpers.IsNullOrWhiteSpace(txtEmail))
            {

                return;
            }

            if (!UserControlHelpers.IsValidNumber(txtPIB.Text) || !UserControlHelpers.IsValidNumber(txtTelephone.Text)) {
                MessageBox.Show("Problem with telephone or PIB");
                return;
            }

            if (!UserControlHelpers.IsValidEmail(txtEmail.Text)) {
                MessageBox.Show("Problem with email.");
                return;
            }

            Client c = new Client { 
                Name = txtName.Text,
                Place = txtPlace.Text,
                PIB = int.Parse(txtPIB.Text),
                Telephone = int.Parse(txtTelephone.Text),
                Email = txtEmail.Text
            };

            try
            {
                if (Controler.Instance.FindClient(c))
                {
                    MessageBox.Show("Already exist!");
                    UserControlHelpers.ResetTxt(txtPIB);
                    UserControlHelpers.ResetTxt(txtName);
                    return;
                }
                Controler.Instance.AddClient(c);
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
