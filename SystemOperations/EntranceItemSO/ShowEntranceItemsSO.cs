using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntranceItemSO
{
    public class ShowEntranceItemsSO : SystemOperationBase
    {
        public DataTable Result{ get; set; }
        public string Uslov { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.ShowEntranceItems(entity, Uslov);
        }
    }
}
