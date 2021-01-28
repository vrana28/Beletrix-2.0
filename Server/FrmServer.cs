using Domain;
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
using Timer = System.Windows.Forms.Timer;

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
        public DataGridView OnlineKorinsici{ get=>dgvOnlineKorisnici; }
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

        private void Timer_Thick(object sender, EventArgs e)
        {
            OnlineKorinsici.DataSource = null;
            OnlineKorinsici.DataSource = new BindingList<Storekeeper>(Server.OnlineKorisnici);
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

        private void FrmServer_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Thick;
            timer.Start();
        }
    }
}
