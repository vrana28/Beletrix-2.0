using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.ClientSO
{
    public class GetAllClientsSO : SystemOperationBase
    {
        public List<Client> Result{ get; private set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetAll(entity).Cast<Client>().ToList();
        }
    }
}
