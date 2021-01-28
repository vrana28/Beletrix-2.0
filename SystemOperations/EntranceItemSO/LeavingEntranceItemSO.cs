using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.EntranceItemSO
{
    public class LeavingEntranceItemSO : SystemOperationBase
    {
        public List<LeavingItem> LeavingItem { get; set; }
        public List<EntranceItems> EntranceItem { get; set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            foreach (EntranceItems ei in EntranceItem)
            {
                repository.Update(ei);
            }
            foreach (LeavingItem li in LeavingItem)
            {
                repository.Save(li);
            }
        }
    }
}
