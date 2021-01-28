using Common;
using FrmLogin.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FrmLogin.Communication
{
    public class CommunicationClient
    {
        private Receiver receiver;
        private Sender sender;

        public CommunicationClient(Socket socket)
        {
           
            receiver = new Receiver(socket);
            sender = new Sender(socket);
        }

        public void SendRequest(Request request) {
            try
            {
                sender.Send(request);
            }
            catch (IOException)
            {
                throw new ServerException();
            }
            catch (SerializationException)
            {
                throw new ServerException();
            }
        }

        public Object GetResponseResult() {

            
                Response response = (Response)receiver.Receive();
                if (response.IsSuccessful)
                {
                    return response.Result;
                }
                else {
                throw new Exception(response.Error);
                }
            }
          
        }


    
}
