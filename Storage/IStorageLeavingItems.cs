using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IStorageLeavingItems
    {
        void AddLeavingItems(List<LeavingItem> listaIzlaza);
        void SaveLeavingItems(List<LeavingItem> listaItemaZaIzlaz, List<EntranceItems> listaItemaZaUpdate);
    }
}
