using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Implementation.SqlServer
{
    public class StorageEntranceSqlServer : IStorageEntrance
    {
        private Broker broker = new Broker();
        public void Add(Entrance e)
        {
            try
            {
                broker.OpenConnection();
                broker.AddEntrance(e);
            }
            finally
            {
                broker.CloseConnection();
            }
        }
    }
}
