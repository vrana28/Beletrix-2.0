using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IStorageEntrance
    {
        void Add(Entrance e);
        int GetMaxId();
        void UpdateEntrance(Entrance entrance, double totalWeight);
       
        DataTable GetAllEntrance();
        Entrance  Find(int entranceId);
        void SetEntranceTrue(int entranceId);
        void SaveEntrance(Entrance entrance);
    }
}
