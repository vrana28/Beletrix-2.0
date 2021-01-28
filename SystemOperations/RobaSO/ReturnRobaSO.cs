using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.RobaSO
{
    public class ReturnRobaSO : SystemOperationBase
    {
        public Roba Result{ get; set; }
        public string Uslov{ get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = (Roba)repository.Return(entity, Uslov);
        }
    }
}
