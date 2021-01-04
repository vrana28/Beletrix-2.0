using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class EntrancePosition : GeneralDomainObject
    {
        public int EntranceId { get; set; }
        public Entrance Entrance { get; set; }
        public string PositionId { get; set; }
        public Position Position { get; set; }

        public string GetAllValues()
        {
            return $"'{EntranceId}','{PositionId}''";
        }

        public string GetName()
        {
            return "EntrancePositions";
        }

        public string GetWhereName()
        {
            throw new NotImplementedException();
        }

        public string GetWhereValues()
        {
            return $"where PositionId = {PositionId}";
        }

        public string SetValues()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{EntranceId} {PositionId}";
        }
    }
}
