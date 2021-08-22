using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntranceSO
{
    public class AddNewEntranceSO : SystemOperationBase
    {

        protected override void ExecuteOperation(IEntity entity)
        {
            Entrance e = (Entrance)entity;         
            e.EntranceId = (int)repository.SaveEntrance(entity);
            foreach (EntranceItems ei in e.Items)
            {
                ei.EntranceId = e.EntranceId;
                //IEntity ent = ei;
                repository.SaveEntranceItem(ei);
            }
        }
    }
}
