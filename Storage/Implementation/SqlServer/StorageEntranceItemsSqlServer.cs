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

        public double GetWeightOfBox(EntranceItems e)
        {
            try
            {
                broker.OpenConnection();
                return broker.GetWeightOfBox(e);
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
    }
}
