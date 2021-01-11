using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Client : GeneralDomainObject
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public int PIB { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }

        public string GetAllValues()
        {
            return $"'{Name}','{Place}','{PIB}','{Telephone}','{Email}'";
        }

        public string GetName()
        {
            return "Clients";
        }

        public string GetWhereName()
        {
            return $"where Name = '{Name}'";
        }

        public string GetWhereValues()
        {
            return $"where ClientId = {ClientId}";
        }



        public string SetValues()
        {
            return $"Name = '{Name}', Place = '{Place}', PIB = {PIB}, Telephone={Telephone}, Email='{Email}'" +
                $" where ClientId = {ClientId}";
        }
    }
}
