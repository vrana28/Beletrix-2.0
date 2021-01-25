using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseBroker;

namespace Storage.Implementation.SqlServer
{
    public class StorageClientSqlServer : IStorageClient
    {
        private Broker broker = new Broker();
        public void Add(Client c)
        {
            try
            {
                broker.OpenConnection();
                broker.AddClient(c);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void Delete(Client c)
        {
            try
            {
                broker.OpenConnection();
                broker.DeleteClient(c);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public bool Find(Client c)
        {
            try
            {
                broker.OpenConnection();
                return broker.ExistClient(c);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Client> GetAll()
        {
            try
            {
                broker.OpenConnection();
                return broker.GetAllClients();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public Client ReturnClient(string requestObject)
        {
            try {
                
                broker.OpenConnection();
                return broker.ReturnClient(requestObject);
            }
        
            finally {
                broker.CloseConnection();
            }
        }

        public void Update(Client c)
        {
            try
            {
                broker.OpenConnection();
                broker.UpdateClient(c);
            }
            finally
            {
                broker.CloseConnection();
            }
        }
    }
}
