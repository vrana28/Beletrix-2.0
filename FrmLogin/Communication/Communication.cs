using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FrmLogin.Communication
{
    public class Communication
    {
        private static Communication instance;
        private Socket socket;
        private CommunicationClient client;
        public Communication()
        {

        }

        public static  Communication Instance {
            get { 
                if (instance == null) instance = new Communication();
                return instance;
            }
        }

        public void Connect() {

            if (socket != null && socket.Connected) {
                return;
            }
            socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9998);
            client = new CommunicationClient(socket);
        }


    }
}
