using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Roba : GeneralDomainObject
    {
        public int RobaId { get; set; }
        public string Name { get; set; }
        public double WeightOfBox { get; set; }

        public override string ToString()
        {
            return $"{Name} ";
        }

        public string GetAllValues()
        {
            return $"'{Name}','{WeightOfBox}'";
        }

        public string GetName()
        {
            return "Roba";
        }

        public string GetWhereName()
        {
            return $"where Name = '{Name}'";
        }

        public string GetWhereValues()
        {
            return $"where RobaId = {RobaId}";
        }

        public string SetValues()
        {
            return $"Name = '{Name}', WeightOfBox = '{WeightOfBox}' where RobaId = {RobaId}";
        }
    }
}
