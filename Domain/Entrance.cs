using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Entrance : GeneralDomainObject
    {
        public int EntranceId { get; set; }
        public double TotalWeight { get; set; }
        public DateTime DateOfEntrance { get; set; }
        public DateTime? DateOfExit { get; set; }
        public string Dimension { get; set; }
        // u smislu dal je obracunat na kraju meseca
        public bool Obradjen { get; set; }
        public int ClientId { get; set; }
        public Storekeeper Storekeeper { get; set; }
        public List<EntranceItems> Items  { get; set; }

        public string GetAllValues()
        {
            return $"'{TotalWeight}','{DateOfEntrance}','{DateOfExit}','{Dimension}','{Obradjen}'," +
                $"'{ClientId}','{Storekeeper.StorekeeperId}',{Items}";
        }

        public string GetName()
        {
            return "Entrance";
        }

        public string GetWhereName()
        {
            throw new NotImplementedException();
        }

        public string GetWhereValues()
        {
            return $"where EntranceId = {EntranceId}";
        }

        public string SetValues()
        {
            throw new NotImplementedException();
        }
    }
}
