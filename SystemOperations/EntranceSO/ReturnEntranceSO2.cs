using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntranceSO
{
    public class ReturnEntranceSO2 : SystemOperationBase
    {
        public Entrance Result { get; set; }
        public string Uslov { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = (Entrance)repository.Return2(entity, Uslov);
        }
    }
}
