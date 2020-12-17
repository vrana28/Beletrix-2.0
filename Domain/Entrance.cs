using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Entrance
    {
        public int EntranceId { get; set; }
        public double TotalWeight { get; set; }
        public DateTime DateOfEntrance { get; set; }
        public DateTime DateOfExit { get; set; }
        public string Dimension { get; set; }
        public bool Obradjen { get; set; }
        public int ClientId { get; set; }
    }
}
