using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.PositionSO
{
    public class GetAllPositionsSO : SystemOperationBase
    {
        public List<Position> Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetAll(entity).Cast<Position>().ToList();
        }
    }
}
