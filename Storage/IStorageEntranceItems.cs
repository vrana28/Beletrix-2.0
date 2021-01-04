using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IStorageEntranceItems
    {

        void AddItem(EntranceItems ei);
        void DeleteItem(EntranceItems ei);
        
        DataTable ShowItemOnPosition(string positionId);
        DataTable GetSpecificItems(EntranceItems ei, Entrance entrance);
        List<EntranceItems> ReturnItems(int entranceId);
        void UpdateEntranceItems(EntranceItems item);
    }
}
