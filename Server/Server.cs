﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;

namespace Server
{
    public class Server
    {
        private Socket listener;
        private List<ClientHandler> onlineKlijenti = new List<ClientHandler>();

        public static List<Storekeeper> OnlineKorisnici { get; set; } = new List<Storekeeper>();

        public Server()
        {
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start() {
            listener.Bind(new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["IP"]),int.Parse(ConfigurationManager.AppSettings["Port"])));
        }

        public void Listen() {
            listener.Listen(5);
            bool kraj = false;
            try
            {

                while (!kraj)
                {
                    Socket socketClient = listener.Accept();
                    ClientHandler handler = new ClientHandler(this,socketClient);
                    onlineKlijenti.Add(handler);
                    Thread thread = new Thread(handler.StartHandler);
                    thread.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                kraj = true;
            }
        }

        internal void Stop()
        {
            listener.Close();
            foreach (ClientHandler ch in onlineKlijenti) {
                ch.Close();
            }
            onlineKlijenti.Clear();
        }
    }
}
