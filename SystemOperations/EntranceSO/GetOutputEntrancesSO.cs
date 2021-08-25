using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntranceSO
{
    public class GetOutputEntrancesSO : SystemOperationBase
    {
        public Client Client { get; set; }
        public Roba Roba { get; set; }
        public DataTable Result { get; set; }

        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetOutputEntrances((Entrance)entity,new LeavingItem(), Client, Roba);
        }
    }
}
