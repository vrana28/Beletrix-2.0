using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntranceSO
{
    public class RestartDatabase : SystemOperationBase
    {
        public string Uslov { get; set; }
        public List<EntrancePosition> Result { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetAll(entity).Cast<EntrancePosition>().ToList();

            foreach (EntrancePosition ep in Result)
            {   
                
                Entrance e = (Entrance)repository.Return(new Entrance(), ep.EntranceId);
                if (e != null)
                {
                    repository.UpdateWithParameters3(e, ep.PositionId);
                }
            }
        }
    }
}
