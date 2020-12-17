using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntrenceItems
    {
        public int Num { get; set; }
        public int EntranceId { get; set; }
        public int RobaId { get; set; }
        public DateTime DeadlineDate { get; set; }
        public bool Deadline { get; set; }
        public double NumOfBoxes { get; set; }

    }
}
