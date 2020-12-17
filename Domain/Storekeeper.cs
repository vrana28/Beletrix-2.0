using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Storekeeper : GeneralDomainObject
    {
        public int StorekeeperId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string GetAllValues()
        {
            return $"'{Name}','{LastName}','{Username}', '{Password}'";
        }

        public string GetName()
        {
            return "Storekeepers";
        }

        public string GetWhereName()
        {
            return $"where Username = '{Username}'";
        }

        public string GetWhereValues()
        {
            return $"where StorekeeperId = {StorekeeperId}";
        }

        public string SetValues()
        {
            return $"Name = '{Name}', LastName = '{LastName}', Username = '{Username}'" +
                $", Password = '{Password}' where StorekeeperId = {StorekeeperId}";
        }
    }
}
