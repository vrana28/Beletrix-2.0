using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Implementation.SqlServer
{
    public class StorageStorekeeperSqlServer : IStorageStorekeeper
    {
        private Broker broker = new Broker();
        public void Add(Storekeeper s)
        {
            try
            {
                broker.OpenConnection();
                broker.AddStorekeeper(s);

            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void Delete(Storekeeper s)
        {
            try
            {
                broker.OpenConnection();
                broker.DeleteStorekeeper(s);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        

        public bool Find(Storekeeper s)
        {
            try
            {
                broker.OpenConnection();
                return broker.ExistStorekeeper(s);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Storekeeper> GetAll()
        {
            try
            {
                broker.OpenConnection();
                return broker.GetAllStorekeepers();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void Update(Storekeeper s)
        {
            try
            {
                broker.OpenConnection();
                broker.UpdateStorekeeper(s);
            }
            finally
            {
                broker.CloseConnection();
            }
        }
    }
}
