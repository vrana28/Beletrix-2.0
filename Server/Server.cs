using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private Socket listener;

        public Server()
        {
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start() {
            listener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
        }

        public void Listen() {
            listener.Listen(5);
            bool kraj = false;
            try
            {

                while (!kraj)
                {
                    Socket socketClient = listener.Accept();
                    ClientHandler handler = new ClientHandler(socketClient);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
