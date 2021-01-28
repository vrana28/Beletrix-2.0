using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.RobaSO
{
    public class GetAllRobaSO : SystemOperationBase
    {
        public List<Roba> Result{ get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetAll(entity).Cast<Roba>().ToList();
        }
    }
}
