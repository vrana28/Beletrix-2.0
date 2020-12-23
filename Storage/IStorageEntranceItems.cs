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
        double GetWeightOfBox(EntranceItems e);
        DataTable ShowItemOnPosition(string positionId);
    }
}
