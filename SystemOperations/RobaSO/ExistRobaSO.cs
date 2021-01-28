using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.RobaSO
{
    public class ExistRobaSO : SystemOperationBase
    {
        public bool Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.Exist(entity);
        }
    }
}
