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
            finally
            {
                broker.CloseConnection();
            }
        }

        public EntrancePosition Find()
        {
            throw new NotImplementedException();
        }

        public void LeaveEntrancePosition(EntrancePosition entrancePosition)
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();
                broker.ExitEntrancePosition(entrancePosition);
                broker.Commit();
            }
            catch (Exception ex) {
                broker.Rollback();
                throw new Exception("Geska kod transakcije");
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public EntrancePosition ReturnEntrancePosition(string pozicija)
        {
            try
            {
                broker.OpenConnection();
                return broker.ReturnEntrancePosition(pozicija);
            }
            finally
            {
                broker.CloseConnection();
            }
        }
    }
}
