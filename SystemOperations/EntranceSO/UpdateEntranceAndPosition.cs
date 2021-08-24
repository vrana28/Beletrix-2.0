using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntranceSO
{
    public class UpdateEntranceAndPosition : SystemOperationBase
    {
        public int EntranceId { get; set; }
        public string PositionId { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Entrance e = (Entrance)repository.Return(entity, EntranceId);
            Position p = (Position)repository.Return2(new Position(), PositionId);

            repository.UpdateWithParameters3(e, PositionId);
            repository.UpdateWithParameters(p, p.PositionId);
        }
    }
}
