using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface GeneralDomainObject
    {
        string GetName();
        string GetAllValues();
        string SetValues();
        string GetWhereValues();
        string GetWhereName();
    }
}
