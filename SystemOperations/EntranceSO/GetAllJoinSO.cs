using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntranceSO
{
    public class GetAllJoinSO : SystemOperationBase
    {
        public DataTable Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetAllJoin(entity);
        }
    }
}
