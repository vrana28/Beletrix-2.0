using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Implementation.SqlServer
{
    public class StorageRobaSqlServer : IStorageRoba
    {
        private Broker broker = new Broker();
        public void Add(Roba r)
        {
            try
            {
                broker.OpenConnection();
                broker.AddRoba(r);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void Delete(Roba r)
        {
            try
            {
                broker.OpenConnection();
                broker.DeleteRoba(r);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public bool Find(Roba r)
        {
            try
            {
                broker.OpenConnection();
                return broker.FindRoba(r);
            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public List<Roba> GetAllRoba()
        {
            try
            {
                broker.OpenConnection();
                return broker.GetAllRoba();

            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public double GetWeightOfBox(int robaId)
        {
            try
            {
                broker.OpenConnection();
                return broker.GetWeightOfBox(robaId);

            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public Roba ReturnRoba(string requestObject)
        {
            try
            {
                broker.OpenConnection();
                return broker.ReturnRoba(requestObject);

            }
            finally
            {
                broker.CloseConnection();
            }
        }

        public void Update(Roba r)
        {
            try
            {
                broker.OpenConnection();
                broker.UpdateRoba(r);
            }
            finally
            {
                broker.CloseConnection();
            }
        }
    }
}
