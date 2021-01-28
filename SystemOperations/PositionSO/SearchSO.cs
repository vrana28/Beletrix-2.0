using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.PositionSO
{
    public class SearchSO : SystemOperationBase
    {
        public List<Position> Result{ get; set; }
        public string Uslov{ get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.Search(entity, Uslov).Cast<Position>().ToList();
        }
    }
}
