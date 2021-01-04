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
    public class StorageEntranceItemsSqlServer : IStorageEntranceItems
    {

        private Broker broker = new Broker();
        public void AddItem(EntranceItems ei)
        {
            try
            {
                broker.OpenConnection();
                broker.AddEntranceItem(ei);
            }
            finally {

                broker.CloseConnection();
            }
        }

       

        public void DeleteItem(EntranceItems ei)
        {
            try
            {
                broker.OpenConnection();
                broker.Delete(ei);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public DataTable GetSpecificItems(EntranceItems ei,Entrance entrance)
        {
            try
            {
                broker.OpenConnection();
                return broker.GetSpecificItems(ei,entrance);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

       

        

        public List<EntranceItems> ReturnItems(int entranceId)
        {
            try
            {
                broker.OpenConnection();
                return broker.ReturnEntranceItems(entranceId);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public DataTable ShowItemOnPosition(string positionId)
        {
            try
            {
                broker.OpenConnection();
                return broker.ShowItemsOnPosition(positionId);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void UpdateEntranceItems(EntranceItems item)
        {
            try
            {
                broker.OpenConnection();
                broker.UpdateEntranceItems(item);
            }
            finally
            {
                broker.CloseConnection();
            }
        }
    }
}
