using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntrancePositionSO
{
    public class AddNewEntrancePositionSO : SystemOperationBase
    {
        public int EntranceId { get; set; }
        public string PositoinId { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            repository.Save(entity);
            IEntity ent = new Entrance();
            repository.UpdateWithParameters(ent, EntranceId);
            ent = new Position();
            repository.UpdateWithParameters(ent, PositoinId);
        }
    }
}
