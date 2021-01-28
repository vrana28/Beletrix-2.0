using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntranceItemSO
{
    public class SearchEntranceItemsSO : SystemOperationBase
    {
        public List<EntranceItems> Result{ get; set; }
        public int Uslov { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.Search(entity, Uslov).Cast<EntranceItems>().ToList();
        }
    }
}
