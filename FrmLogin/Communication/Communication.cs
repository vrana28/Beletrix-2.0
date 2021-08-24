using Common;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Collections.Specialized;
using Org.BouncyCastle.Ocsp;

namespace FrmLogin.Communication
{
    public class Communication
    {
        private static Communication instance;
        private Socket socket;
        private CommunicationClient client;

        internal DataTable GetAllEntrances()
        {
            Request r = new Request { Operation = Operation.GetAllEntrances };
            client.SendRequest(r);
            return (DataTable)client.GetResponseResult();
        }

        internal DataTable FindBusyPosition(Client clients, Roba roba)
        {
            Request r = new Request { Operation = Operation.FindBusyPosition, RequestObject = clients, RequestObject2 = roba };
            client.SendRequest(r);
            return (DataTable)client.GetResponseResult();
        }

        internal List<Position> GetAllPositions()
        {
            Request r = new Request { Operation = Operation.GetAllPositions };
            client.SendRequest(r);
            return (List<Position>)client.GetResponseResult();
        }

        public Communication()
        {

        }

        public static  Communication Instance {
            get { 
                if (instance == null) instance = new Communication();
                return instance;
            }
        }

        internal List<Roba> GetAllRoba()
        {
            Request r = new Request { Operation = Operation.GetAllRoba };
            client.SendRequest(r);
            return (List<Roba>)client.GetResponseResult();
        }

        internal Client ReturnClient(string txtClient)
        {
            Request r = new Request { Operation = Operation.ReturnClient, RequestObject = txtClient };
            client.SendRequest(r);
            return (Client)client.GetResponseResult();
        }

        internal Roba ReturnRoba(string txtArtikal)
        {
            Request r = new Request { Operation = Operation.ReturnRoba, RequestObject = txtArtikal};
            client.SendRequest(r);
            return (Roba)client.GetResponseResult();
        }

        internal List<Client> GetAllClients()
        {
            Request r = new Request { Operation = Operation.GetAllClients };
            client.SendRequest(r);
            return (List<Client>)client.GetResponseResult();
        }

        internal void RestartDatabase()
        {
            Request r = new Request { Operation = Operation.RestartDatabase };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal void SaveStorekeeper(Storekeeper s)
        {
            Request r = new Request { Operation = Operation.SaveStorekeeper, RequestObject = s };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal void DeleteEntrance(string entranceId)
        {
            Request r = new Request { Operation = Operation.DeleteEntrance, RequestObject = entranceId };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal DataTable ShowEntranceItems(string positionId)
        {
            Request r = new Request { Operation = Operation.ShowEntranceItems, RequestObject = positionId };
            client.SendRequest(r);
            return (DataTable)client.GetResponseResult();
        }

        internal List<Position> FindPositions(string v)
        {
            Request r = new Request { Operation = Operation.FindPositions, Text = v };
            client.SendRequest(r);
            return (List<Position>)client.GetResponseResult();
        }

        internal void UpdateRoba(Roba roba)
        {
            Request r = new Request { Operation = Operation.UpdateRoba, RequestObject = roba };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal void UpdateEntranceAndPosition(string txtEntranceId, string txtPositionId)
        {
            Request r = new Request { Operation = Operation.UpdateEntranceAndPositoin, RequestObject = txtEntranceId, RequestObject2 = txtPositionId };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal void Disconnect()
        {
                socket.Close();
                socket = null;
        }

        internal List<Storekeeper> GetAllStorekeepers()
        {
            Request r = new Request { Operation = Operation.GetAllStorekeepers };
            client.SendRequest(r);
            return (List<Storekeeper>)client.GetResponseResult();
        }

        internal void DeleteRoba(Roba roba)
        {
            Request r = new Request { Operation = Operation.DeleteRoba, RequestObject = roba};
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal Entrance FindEntrance(int entranceId)
        {
            Request r = new Request { Operation = Operation.FindEntrance, RequestObject = entranceId };
            client.SendRequest(r);
            return (Entrance)client.GetResponseResult();
        }

        internal DataTable SearchProductWith(Client clients, Roba roba)
        {
            Request r = new Request { Operation = Operation.SearchProductWith, RequestObject = clients, RequestObject2 = roba };
            client.SendRequest(r);
            return (DataTable)client.GetResponseResult();
        }

        internal double GetWeightOfBox(int robaId)
        {
            Request r = new Request { Operation = Operation.GetWeightOfBox, RequestObject = robaId };
            client.SendRequest(r);
            return (double)client.GetResponseResult();
        }

        internal bool FindRoba(Roba roba)
        {
            Request r = new Request { Operation = Operation.FindRoba, RequestObject = roba };
            client.SendRequest(r);
            return (bool)client.GetResponseResult();
        }

        internal void AddRoba(Roba roba)
        {
            Request r = new Request { Operation = Operation.SaveRoba, RequestObject = roba };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal EntrancePosition ReturnEntrancePositions(string pozicija)
        {
            Request r = new Request { Operation = Operation.ReturnEntrancePosition, RequestObject = pozicija };
            client.SendRequest(r);
            return (EntrancePosition)client.GetResponseResult();
        }

        internal bool FindStorekeeper(Storekeeper s)
        {
            Request r = new Request { Operation = Operation.FindStorekeeper, RequestObject = s };
            client.SendRequest(r);
            return (bool)client.GetResponseResult();
        }

        internal List<EntranceItems> ReturnEntranceItems(int entranceId)
        {
            Request r = new Request { Operation = Operation.ReturnEntranceItems, RequestObject = entranceId };
            client.SendRequest(r);
            return (List<EntranceItems>)client.GetResponseResult();
        }

        internal void UpdateStorekeeper(Storekeeper s)
        {
            Request r = new Request { Operation = Operation.UpdateStorekeeper, RequestObject = s };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal void DeleteStorekeeper(Storekeeper storekeeper)
        {
            Request r = new Request { Operation = Operation.DeleteStorekeeper, RequestObject = storekeeper };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal void AddEntrancePosition(EntrancePosition ep)
        {
            Request r = new Request { Operation = Operation.AddEntrancePosition, RequestObject = ep };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal bool FindClient(Client c)
        {
            Request r = new Request { Operation = Operation.FindClient, RequestObject = c };
            client.SendRequest(r);
            return (bool)client.GetResponseResult();
        }

        internal void LeaveEntrance(Entrance entrance)
        {
            Request r = new Request { Operation = Operation.LeaveEntrance, RequestObject = entrance };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal void UpdateClient(Client c)
        {
            Request r = new Request { Operation = Operation.UpdateClient, RequestObject = c };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        public void Connect() {

                if (socket != null && socket.Connected)
                {
                    return;
                }
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ConfigurationManager.AppSettings["IP"],int.Parse(ConfigurationManager.AppSettings["Port"]));
                client = new CommunicationClient(socket);
        }

        internal void DeleteClient(Client client)
        {
            Request r = new Request { Operation = Operation.DeleteClient, RequestObject = client };
            this.client.SendRequest(r);
            this.client.GetResponseResult();
        }

        internal DataTable FindBusyPositionsWithPosition(Client clients, Roba roba, string v)
        {
            Request r = new Request { Operation = Operation.SearchAllParameters, RequestObject = clients, RequestObject2 = roba, Text = v };
            client.SendRequest(r);
            return (DataTable)client.GetResponseResult();
        }

        internal void SaveClient(Client c)
        {
            Request r = new Request { Operation = Operation.SaveClient, RequestObject = c };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal Storekeeper Login(string username, string password)
        {
            Request r = new Request
            {
                Operation = Operation.Login,
                RequestObject = new Storekeeper { Username = username, Password = password }
            };
            client.SendRequest(r);
            return (Storekeeper)client.GetResponseResult();
        }

        internal void AddEntrance(Entrance entrance)
        {
            Request r = new Request { Operation = Operation.AddEntrance, RequestObject = entrance };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal void LeavingEntranceItems(List<LeavingItem> listaItemaZaIzlaz, List<EntranceItems> listaItemaZaUpdate)
        {
            Request r = new Request { Operation = Operation.LeavingEntranceItem, RequestObject = listaItemaZaIzlaz, RequestObject2 = listaItemaZaUpdate };
            client.SendRequest(r);
            client.GetResponseResult();
        }

        internal Entrance ReturnEntrance(string pozicija)
        {
            Request r = new Request { Operation = Operation.ReturnEntrance, RequestObject = pozicija };
            client.SendRequest(r);
            return (Entrance)client.GetResponseResult();
        }
    }
}
