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
        // serverski soket koji je namenjen islkljucivo jednom klijentu 
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

                try
                {
                    NetworkStream stream = new NetworkStream(client);
                    BinaryFormatter formatter = new BinaryFormatter();

                    while (true)
                    {
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
                    Close();
                }
            }
            catch (Exception)
            {
                Server.OnlineKorisnici.Remove(Storekeeper);
                Console.WriteLine("Klijent je izasao");
            }

        }

        internal void Close()
        {
            client.Close();
        }

        public Storekeeper Storekeeper { get; set; }
        private Response PorocessRequest(Request request)
        {
            Response response = new Response();
            response.IsSuccessful = true;
            switch (request.Operation) {
                case Operation.Login:
                    Storekeeper = Controler.Instance.Login((Storekeeper)request.RequestObject);
                    if (Storekeeper != null) Server.OnlineKorisnici.Add(Storekeeper);
                    response.Result = Storekeeper;
                    break;
                case Operation.SaveStorekeeper:
                    Controler.Instance.AddStorekeeper((Storekeeper)request.RequestObject);
                    break;
                case Operation.GetAllStorekeepers:
                    response.Result = Controler.Instance.GetAllStorekeepers();
                    break;
                case Operation.UpdateStorekeeper:
                    Controler.Instance.UpdateStorekeeper((Storekeeper)request.RequestObject);
                    break;
                case Operation.DeleteStorekeeper:
                    Controler.Instance.DeleteStorekeeper((Storekeeper)request.RequestObject);
                    break;
                case Operation.FindClient:
                   response.Result = Controler.Instance.FindClient((Client)request.RequestObject);
                    break;
                case Operation.SaveClient:
                    Controler.Instance.AddClient((Client)request.RequestObject);
                    break;
                case Operation.GetAllClients:
                    response.Result = Controler.Instance.GetAllClient();
                    break;
                case Operation.UpdateClient:
                    Controler.Instance.UpdateClient((Client)request.RequestObject);
                    break;
                case Operation.DeleteClient:
                    Controler.Instance.DeleteClient((Client)request.RequestObject);
                    break;
                case Operation.FindRoba:
                    response.Result = Controler.Instance.FindRoba((Roba)request.RequestObject);
                    break;
                case Operation.SaveRoba:
                    Controler.Instance.AddRoba((Roba)request.RequestObject);
                    break;
                case Operation.GetAllRoba:
                    response.Result = Controler.Instance.GetAllRoba();
                    break;
                case Operation.UpdateRoba:
                    Controler.Instance.UpdateRoba((Roba)request.RequestObject);
                    break;
                case Operation.DeleteRoba:
                    Controler.Instance.DeleteRoba((Roba)request.RequestObject);
                    break;
                case Operation.SearchProductWith:
                    response.Result = Controler.Instance.FindBusyPositions((Client)request.RequestObject, (Roba)request.RequestObject2);
                    break;
                case Operation.SearchAllParameters:
                    response.Result = Controler.Instance.FindBusyPositionsWithPosition((Client)request.RequestObject, (Roba)request.RequestObject2, request.Text);
                    break;
                case Operation.AddEntrance:
                    Controler.Instance.AddEntrance((Entrance)request.RequestObject);
                    break;
                case Operation.GetAllEntrances:
                    response.Result = Controler.Instance.GetAllEntrancecs();
                    break;
                case Operation.GetAllPositions:
                    response.Result= Controler.Instance.GetAllPositions();
                    break;
                case Operation.FindPositions:
                    response.Result = Controler.Instance.FindPositions(request.Text);
                    break;
                case Operation.AddEntrancePosition:
                    Controler.Instance.AddEntrancePosition((EntrancePosition)request.RequestObject);
                    break;
                case Operation.FindEntrance:
                    response.Result = Controler.Instance.FindEntrance((int)request.RequestObject);
                    break;
                case Operation.FindBusyPosition:
                    response.Result = Controler.Instance.FindBusyPositions((Client)request.RequestObject, (Roba)request.RequestObject2);
                    break;
                case Operation.ReturnEntrancePosition:
                    response.Result = Controler.Instance.ReturnEntrancePosition((string)request.RequestObject);
                    break;
                case Operation.ReturnEntranceItems:
                    response.Result = Controler.Instance.ReturnEntranceItems((int)request.RequestObject);
                    break;
                case Operation.LeaveEntrance:
                    Controler.Instance.LeaveEntrance((Entrance)request.RequestObject);
                    break;
                case Operation.LeavingEntranceItem:
                    Controler.Instance.LeavingEntranceItems((List<LeavingItem>)request.RequestObject, (List<EntranceItems>)request.RequestObject2);
                    break;
                case Operation.ShowEntranceItems:
                    response.Result = Controler.Instance.ShowEntranceItems((string)request.RequestObject);
                    break;
                case Operation.ReturnClient:
                    response.Result = Controler.Instance.ReturnClient((string)request.RequestObject);
                    break;
                case Operation.ReturnRoba:
                    response.Result = Controler.Instance.ReturnRoba((string)request.RequestObject);
                    break;
                case Operation.GetWeightOfBox:
                    response.Result = Controler.Instance.GetWeightOfBox((int)request.RequestObject);
                    break;
                case Operation.FindStorekeeper:
                    response.Result = Controler.Instance.FindStorekeeper((Storekeeper)request.RequestObject);
                    break;
                case Operation.UpdateEntranceAndPositoin:
                    Controler.Instance.UpdateEntranceAndPosition(Int32.Parse((string)(request.RequestObject)), (string)request.RequestObject2);
                    break;
                case Operation.RestartDatabase:
                    Controler.Instance.RestartDatabase();
                    break;
                case Operation.ReturnEntrance:
                    response.Result = Controler.Instance.ReturnEntrances((string)request.RequestObject);
                    break;
                case Operation.DeleteEntrance:
                    Controler.Instance.DeleteEntrance((string)request.RequestObject);
                    break;
            }
            return response;
        }
    }
}
