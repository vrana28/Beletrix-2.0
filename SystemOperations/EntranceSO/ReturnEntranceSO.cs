using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntranceSO
{
    public class ReturnEntranceSO : SystemOperationBase
    {
        public Entrance Result{ get; set; }
        public int Uslov{ get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = (Entrance)repository.Return(entity, Uslov);
        }
    }
}
