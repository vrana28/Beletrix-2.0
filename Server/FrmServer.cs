using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        public FrmServer()
        {
            InitializeComponent();
            btnStart.Visible = true;
            btnStop.Visible = false;
        }

        private Server s;

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                s = new Server();
                s.Start();
                btnStart.Visible = false;
                btnStop.Visible = true;
                Thread thread = new Thread(s.Listen);
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            s.Stop();
            btnStart.Visible = true;
            btnStop.Visible = false;
        }
    }
}
