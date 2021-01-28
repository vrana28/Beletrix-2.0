using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.StorekeeperSO
{
    public class GetAllStorekeepersSO : SystemOperationBase
    {
        public List<Storekeeper> Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetAll(entity).Cast<Storekeeper>().ToList();
        }
    }
}
