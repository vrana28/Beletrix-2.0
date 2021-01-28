using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntrancePositionSO
{
    public class ReturnEntrancePositionSO : SystemOperationBase
    {
        public EntrancePosition Result { get; set; }
        public string Uslov { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = (EntrancePosition)repository.Return(entity, Uslov);
        }
    }
}
