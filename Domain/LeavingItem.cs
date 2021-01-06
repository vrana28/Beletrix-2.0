using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LeavingItem : GeneralDomainObject
    {
        public int LeavingItemId { get; set; }
        public int EntranceId { get; set; }
        public int Num { get; set; }
        public int RobaId { get; set; }
        public Roba Roba { get; set; }
        public double NumOfBoxes { get; set; }
        public DateTime DateOfLeaving { get; set; }

        public string GetAllValues()
        {
            return $"'{EntranceId}','{Num}','{RobaId}','{NumOfBoxes}','{DateOfLeaving}'";
        }

        public string GetName()
        {
            return "LeavingItems";
        }

        public string GetWhereName()
        {
            throw new NotImplementedException();
        }

        public string GetWhereValues()
        {
            throw new NotImplementedException();
        }

        public string SetValues()
        {
            throw new NotImplementedException();
        }
    }
}
