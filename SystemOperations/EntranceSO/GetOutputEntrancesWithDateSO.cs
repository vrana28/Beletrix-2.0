using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntranceSO
{
    public class GetOutputEntrancesWithDateSO : SystemOperationBase
    {
        public Client Client { get; set; }
        public Roba Roba { get; set; }
        public DataTable Result { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }

        protected override void ExecuteOperation(IEntity entity)
        {
            Result = repository.GetOutputEntrancesWithDate((Entrance)entity, Client, Roba, DatumOd, DatumDo);
        }
    }
}
