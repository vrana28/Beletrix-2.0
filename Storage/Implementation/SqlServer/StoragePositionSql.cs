using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Implementation.SqlServer
{
    public class StoragePositionSql : IStoragePosition
    {
        private Broker broker = new Broker();

        public List<Position> Find(string v)
        {
            try
            {
                broker.OpenConnection();
                return broker.FindPositions(v);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Position> GetAllPositions()
        {
            try
            {
                broker.OpenConnection();
                return broker.GetAllPositions();
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void UpdatePosition(string positionId)
        {
            try
            {
                broker.OpenConnection();
                broker.UpdatePosition(positionId);
            }
            finally
            {
                broker.CloseConnection();
            }
        }
    }
}
