using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Storage.Implementation.SqlServer;
using System.ComponentModel;

namespace Controller
{
    public class Controler
    {
        private IStorageClient storageClient;
        private IStorageStorekeeper storageStorekeeper;
        private IStorageRoba storageRoba;

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

        public bool FindClient(Client c)
        {
            return storageClient.Find(c);
        }

        public void AddClient(Client c)
        {
            storageClient.Add(c);
        }

        public void UpdateClient(Client c)
        {
            storageClient.Update(c);
        }

        public void DeleteClient(Client client)
        {
            storageClient.Delete(client);
        }

        public void DeleteStorekeeper(Storekeeper storekeeper)
        {
            storageStorekeeper.Delete(storekeeper);
        }
    }
}
