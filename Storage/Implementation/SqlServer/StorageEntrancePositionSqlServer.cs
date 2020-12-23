using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Implementation.SqlServer
{
    public class StorageEntrancePositionSqlServer : IStorageEntrancePosition
    {
        Broker broker = new Broker();
        public void AddEntrancePosition(EntrancePosition ep)
        {
            try
            {
                broker.OpenConnection();
                broker.AddEntrancePosition(ep);
            }
            catch (Exception ex)
            {
                broker.CloseConnection();
            }
        }

        public EntrancePosition Find()
        {
            throw new NotImplementedException();
        }

    }
}
