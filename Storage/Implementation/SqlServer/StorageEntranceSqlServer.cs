using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
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

        public Entrance Find(int entranceId)
        {
            try
            {
                broker.OpenConnection();
                return broker.FindEntrance(entranceId);
            }
            finally 
            {
                broker.CloseConnection();
            }
        }

        public DataTable GetAllEntrance()
        {
            try
            {
                broker.OpenConnection();
                return broker.GetAllEntrances();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public int GetMaxId()
        {
            try
            {
                broker.OpenConnection();
                return broker.GetMaxId();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void SetEntranceTrue(int entranceId)
        {
            try
            {
                broker.OpenConnection();
                broker.SetEntranceTrue(entranceId);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void UpdateEntrance(Entrance entrance, double totalWeight)
        {
            try
            {
                broker.OpenConnection();
                broker.UpdateEntrances(entrance, totalWeight);
            }
            finally
            {
                broker.CloseConnection();
            }
        }
    }
}
