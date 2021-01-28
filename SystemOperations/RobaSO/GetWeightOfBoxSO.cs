using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.RobaSO
{
    public class GetWeightOfBoxSO : SystemOperationBase
    {
        public double Result{ get; set; }
        public int Uslov { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetWeightOfBox(entity,Uslov);
        }
    }
}
