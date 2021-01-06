using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Sender
    {
        private NetworkStream stream;
        private BinaryFormatter formatter;
        private readonly Socket socket;

        public Sender(Socket socket)
        {
            this.socket = socket; 
            this.stream = new NetworkStream(socket);
            this.formatter = new BinaryFormatter();
        }

        public void Send(object Message) {
            formatter.Serialize(stream,Message);
        }

    }
}
