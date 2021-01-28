using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Storekeeper : IEntity
    {
        public int StorekeeperId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName}";
        }

        [Browsable(false)]
        public string TableName => "Storekeepers";
        [Browsable(false)]
        public string InsertValues => $"'{Name}','{LastName}','{Username}', '{Password}'";
        [Browsable(false)]
        public string IdName => "StorekeeperId";
        [Browsable(false)]
        public string JoinCondition => throw new NotImplementedException();
        [Browsable(false)]
        public string JoinTable => throw new NotImplementedException();
        [Browsable(false)]
        public string TableAlias => throw new NotImplementedException();
        [Browsable(false)]
        public object SelectValues => throw new NotImplementedException();
        [Browsable(false)]
        public object WhereValues => $" where StorekeeperId = {StorekeeperId}";
        [Browsable(false)]
        public object SetValues => $" set Name = '{Name}',LastName = '{LastName}', Username='{Username}'," +
            $" Password = '{Password}' where StorekeeperId = {StorekeeperId}";
        [Browsable(false)]
        public object ExistName => $" where Username = '{Username}'";
        // za log in
        [Browsable(false)]
        public object WhereReturn => $" where Username= '{Username}' and Password='{Password}'";
        [Browsable(false)]
        public object GetWeightOfBox => throw new NotImplementedException();
        [Browsable(false)]
        public object Output => throw new NotImplementedException();
        [Browsable(false)]
        public object WherePosition => "";
        [Browsable(false)]
        public string All => throw new NotImplementedException();
        [Browsable(false)]
        public object SetValues2 => throw new NotImplementedException();

        public void AddParametres(SqlCommand command)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                Storekeeper s = new Storekeeper
                {
                    StorekeeperId = (int)reader[0],
                    Name = (string)reader[1],
                    LastName = (string)reader[2],
                    Username = (string)reader[3],
                    Password = (string)reader[4],
                };
                result.Add(s);
            }
            return result;
        }

        public IEntity ReturnEntity(SqlDataReader reader)
        {
            IEntity result = null;
            while (reader.Read())
            {
                Storekeeper s = new Storekeeper
                {
                    StorekeeperId = (int)reader[0],
                    Name = (string)reader[1],
                    LastName = (string)reader[2],
                    Username = (string)reader[3],
                    Password = (string)reader[4]
                };
                result = s;
            }
            return result;
        }
    }
}
