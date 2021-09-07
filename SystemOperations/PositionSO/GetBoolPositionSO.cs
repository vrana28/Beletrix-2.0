using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.PositionSO
{
    public class GetBoolPositionSO : SystemOperationBase
    {
        public bool Result { get; set; }
        public string Pozicija { get; set; }

        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetBoolPosition(entity, Pozicija);
        }
    }
}
