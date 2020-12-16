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
    public partial class FrmClientChange : Form
    {
        public FrmClientChange(Client c)
        {
            InitializeComponent();
            Client = c;
        }

        public Client Client { get; set; }

        private void FrmClientChange_Load(object sender, EventArgs e)
        {
            txtName.Text = Client.Name;
            txtPlace.Text = Client.Place;
            txtPIB.Text = Client.PIB.ToString();
            txtTelephone.Text = Client.Telephone.ToString();
            txtEmail.Text = Client.Email;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(txtName) | UserControlHelpers.IsNullOrWhiteSpace(txtPlace)
               | UserControlHelpers.IsNullOrWhiteSpace(txtPIB) | UserControlHelpers.IsNullOrWhiteSpace(txtTelephone)
               | UserControlHelpers.IsNullOrWhiteSpace(txtEmail))
            {

                return;
            }

            if (!UserControlHelpers.IsValidNumber(txtPIB.Text) || !UserControlHelpers.IsValidNumber(txtTelephone.Text))
            {
                MessageBox.Show("Problem with telephone or PIB");
                return;
            }

            if (!UserControlHelpers.IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Problem with email.");
                return;
            }

            Client c = new Client
            {
                ClientId = Client.ClientId,
                Name = txtName.Text,
                Place = txtPlace.Text,
                PIB = int.Parse(txtPIB.Text),
                Telephone = int.Parse(txtTelephone.Text),
                Email = txtEmail.Text
            };

            try
            {
                
                Controler.Instance.UpdateClient(c);
                MessageBox.Show("Client updated!");
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
                    Controler.instance.DeleteClient(Client);
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
