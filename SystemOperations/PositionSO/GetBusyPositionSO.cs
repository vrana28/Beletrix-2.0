using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.PositionSO
{
    public class GetBusyPositionSO : SystemOperationBase
    {
        public Client Client{ get; set; }
        public Roba Roba{ get; set; }
        public DataTable Result{ get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetBusyPositions(entity, Client,Roba);
        }
    }
}
