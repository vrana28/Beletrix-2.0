using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Storage.Implementation.SqlServer;
using System.ComponentModel;
using System.Data;

namespace Controller
{
    public class Controler
    {
        private IStorageClient storageClient;
        private IStorageStorekeeper storageStorekeeper;
        private IStorageRoba storageRoba;
        private IStorageEntrance storageEntrance;
        private IStorageEntranceItems storageEntranceItems;
        private IStoragePosition storagePosition;
        private IStorageEntrancePosition storageEntrancePosition;

        public DataTable GetAllEntrancecs()
        {
            return storageEntrance.GetAllEntrance();
        }

        public List<Position> GetAllPositions()
        {
            return storagePosition.GetAllPositions();
        }

        public Storekeeper Storekeeper{ get; set; }

        public static Controler instance;

        public List<Roba> GetAllRoba()
        {
            return storageRoba.GetAllRoba();
        }

        public Controler()
        {
            storageClient = new StorageClientSqlServer();
            storageStorekeeper = new StorageStorekeeperSqlServer();
            storageRoba = new StorageRobaSqlServer();
            storageEntrance = new StorageEntranceSqlServer();
            storageEntranceItems = new StorageEntranceItemsSqlServer();
            storagePosition = new StoragePositionSql();
            storageEntrancePosition = new StorageEntrancePositionSqlServer();
        }

        public DataTable FindBusyPositions(Client client, Roba roba)
        {
            return storagePosition.FindBusyPosition(client, roba);
        }

        public DataTable ShowEntranceItems(string positionId)
        {
            return storageEntranceItems.ShowItemOnPosition(positionId);
        }

        public List<Position> FindPositions(string v)
        {
           return storagePosition.Find(v);
        }

        public static Controler Instance {
            get {
                if (instance == null) instance = new Controler();
                return instance;
            }
        }

        public List<Storekeeper> GetAllStorekeepers()
        {
            return storageStorekeeper.GetAll();
        }

        public EntrancePosition ReturnEntrancePosition(string pozicija)
        {
            return storageEntrancePosition.ReturnEntrancePosition(pozicija);
        }

        public List<EntranceItems> ReturnEntranceItems(int entranceId)
        {
            return storageEntranceItems.ReturnItems(entranceId);
        }

        public List<Client> GetAllClient()
        {
            return storageClient.GetAll();
        }

        public bool FindStorekeeper(Storekeeper s) {
            return storageStorekeeper.Find(s);
        }

        public void UpdateRoba(Roba r)
        {
            storageRoba.Update(r);
        }

        public bool FindRoba(Roba r)
        {
            return storageRoba.Find(r);
        }

        public void AddRoba(Roba r)
        {
            storageRoba.Add(r);
        }

        public Storekeeper Login(string username, string password)
        {
            List<Storekeeper> users = storageStorekeeper.GetAll();
            foreach (Storekeeper s in users) {
                if (s.Username == username && s.Password == password) {
                    Storekeeper = s;
                    return Storekeeper;
                }
            }
            throw new Exception("Login failed...");
        }

        public Entrance FindEntrance(int entranceId)
        {
            return storageEntrance.Find(entranceId);
        }

        public void LeaveEntrance(EntrancePosition entrancePosition)
        {
            storageEntrancePosition.LeaveEntrancePosition(entrancePosition);
        }

        public DataTable FindBusyPositionsWithPosition(Client client, Roba roba, string v)
        {
            return storagePosition.FindBusyPositionWithPosition(client, roba, v);
        }

        public void DeleteRoba(Roba roba)
        {
            storageRoba.Delete(roba);
        }

        public void UpdateStorekeeper(Storekeeper s)
        {
            storageStorekeeper.Update(s);
        }

        public void AddStorekeeper(Storekeeper s)
        {
            storageStorekeeper.Add(s);
        }

        public void AddEntrance(Entrance ulaz)
        {
            storageEntrance.Add(ulaz);
        }

        public bool FindClient(Client c)
        {
            return storageClient.Find(c);
        }

        public void AddClient(Client c)
        {
            storageClient.Add(c);
        }

        public int GetMaxId()
        {
            return storageEntrance.GetMaxId();
        }

        public void UpdateClient(Client c)
        {
            storageClient.Update(c);
        }

        public void SetEntranceTrue(int entranceId)
        {
            storageEntrance.SetEntranceTrue(entranceId);
        }

        public void UpdatePosition(string positionId)
        {
            storagePosition.UpdatePosition(positionId);
        }

        public void DeleteClient(Client client)
        {
            storageClient.Delete(client);
        }

        public DataTable GetAllEntranceItems(EntranceItems ei, Entrance entrance)
        {
            return storageEntranceItems.GetSpecificItems(ei,entrance);
        }

        public void AddEntrancePosition(EntrancePosition ep)
        {
            storageEntrancePosition.AddEntrancePosition(ep);
        }

        public void DeleteStorekeeper(Storekeeper storekeeper)
        {
            storageStorekeeper.Delete(storekeeper);
        }

        public void AddEntranceItem(EntranceItems ei)
        {
            storageEntranceItems.AddItem(ei);
        }

        public void DeleteEntranceItem(EntranceItems ei)
        {
            storageEntranceItems.DeleteItem(ei);
        }

        public double GetWeightOfBox(int robaId)
        {
            return storageRoba.GetWeightOfBox(robaId);
        }

        public void UpdateEntrance(Entrance entrance, double totalWeight)
        {
             storageEntrance.UpdateEntrance(entrance, totalWeight);
        }

        public void UpdateEntranceItems(EntranceItems item)
        {
            storageEntranceItems.UpdateEntranceItems(item);
        }

        public void SaveEntrance(Entrance entrance)
        {
            storageEntrance.SaveEntrance(entrance);
        }
    }
}
