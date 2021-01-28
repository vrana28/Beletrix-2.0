using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntrancePositionSO
{
    public class ExitEntrancePositionSO : SystemOperationBase
    {

        protected override void ExecuteOperation(IEntity entity)
        {
            IEntity ent1 = new Position();
            IEntity ent2 = new Entrance();
            repository.UpdateWithParameters2(ent1,entity);
            repository.UpdateWithParameters2(ent2,entity);
            repository.Delete2(entity);
        }
    }
}
