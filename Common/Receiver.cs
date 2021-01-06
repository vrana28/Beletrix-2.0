using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Receiver
    {
        private readonly Socket socket;
        private NetworkStream stream;
        private BinaryFormatter formatter;
        
        public Receiver(Socket socket)
        {
            this.socket = socket;
            this.stream = new NetworkStream(socket);
            this.formatter = new BinaryFormatter();
        }

        public Object Receive() {
            return formatter.Deserialize(stream);
        }

    }
}
