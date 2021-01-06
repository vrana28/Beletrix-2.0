using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Implementation.SqlServer
{
    public class StorageLeavingItems : IStorageLeavingItems
    {
        Broker broker = new Broker();
        public void AddLeavingItems(List<LeavingItem> listaIzlaza)
        {
          
        }

        public void SaveLeavingItems(List<LeavingItem> listaItemaZaIzlaz, List<EntranceItems> listaItemaZaUpdate)
        {
            try
            {
                broker.OpenConnection();
                broker.BeginTransaction();
                foreach (EntranceItems ei in listaItemaZaUpdate) {
                    broker.UpdateEntranceItems(ei);
                }
                foreach (LeavingItem li in listaItemaZaIzlaz) {
                    broker.Insert(li);
                }
                broker.Commit();
            }
            catch (Exception)
            {
                broker.Rollback();
                throw new Exception("Rollbacked!");
            }
            finally {
                broker.CloseConnection();
            }
        }
    }
}
