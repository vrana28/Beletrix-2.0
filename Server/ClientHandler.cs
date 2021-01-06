using Common;
using Controller;
using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private Socket client;
        private Server s;

        public ClientHandler(Server s, Socket client)
        {
            this.client = client;
            this.s = s;
        }

        public void StartHandler() {

            try
            {
                NetworkStream stream = new NetworkStream(client);
                BinaryFormatter formatter = new BinaryFormatter();

                while (true) {
                    Request request = (Request)formatter.Deserialize(stream);
                    Response response;
                    try
                    {
                        response = PorocessRequest(request);
                    }
                    catch (Exception)
                    {
                        response = new Response();
                        response.IsSuccessful = false;
                        response.Error = "Greska kod procesiranja zahteva - SERVER";
                    }
                    formatter.Serialize(stream, response);
                }

            }
            catch (IOException)
            {
                Console.WriteLine("Doslo je do greske - Start handler");
            }

        }

        Storekeeper Storekeeper;
        private Response PorocessRequest(Request request)
        {
            Response response = new Response();
            response.IsSuccessful = true;
            switch (request.Operation) {
                case Operation.Login:
                    Storekeeper = Controler.Instance.Login((Storekeeper)request.RequestObject);
                    response.Result = Storekeeper;
                    break;
            
            
            }
            return response;
        }
    }
}
