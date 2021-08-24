using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntranceSO
{
    public class DeleteEntranceSO : SystemOperationBase
    {
        public int EntranceId { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Entrance e = (Entrance)repository.Return(entity, EntranceId);
            repository.Delete(e);
        }
    }
}
