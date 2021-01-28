using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.ClientSO
{
    public class ReturnClientSO : SystemOperationBase
    {
        public Client Result{ get; set; }
        public string Uslov { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = (Client)repository.Return(entity, Uslov);
        }
    }
}
