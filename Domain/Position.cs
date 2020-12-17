using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Position : GeneralDomainObject
    {
        public string PositionId { get; set; }
        public bool Slobodna { get; set; }

        public string GetAllValues()
        {
            return $"'{PositionId}','0'";
        }

        public string GetName()
        {
            throw new NotImplementedException();
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
