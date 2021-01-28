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
    public class Client : IEntity
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public int PIB { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }

        [Browsable(false)]
        public string TableName => "Clients";
        [Browsable(false)]
        public string InsertValues => $"'{Name}','{Place}','{PIB}','{Telephone}','{Email}'";
        [Browsable(false)]
        public string IdName => $"{ClientId}";
        [Browsable(false)]
        public string JoinCondition => throw new NotImplementedException();
        [Browsable(false)]
        public string JoinTable => throw new NotImplementedException();
        [Browsable(false)]
        public string TableAlias => "";
        [Browsable(false)]
        public object SelectValues => "";
        //primena: delete
        [Browsable(false)]
        public object WhereValues => $" where ClientId = {ClientId}";
        [Browsable(false)]
        public object SetValues => $" set Name = '{Name}',Place = '{Place}', PIB={PIB}," +
            $" Telephone ={Telephone}, Email='{Email}' where ClientId = {ClientId}";
        // za exist metodu, koja vraca bool
        [Browsable(false)]
        public object ExistName => $" where Name = '{Name}' or PIB={PIB}";
        [Browsable(false)]
        public object WhereReturn => $" where Name";
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
                Client c = new Client
                {
                    ClientId = (int)reader[0],
                    Name = (string)reader[1],
                    Place = (string)reader[2],
                    PIB = (int)reader[3],
                    Telephone = (int)reader[4],
                    Email = (string)reader[5]
                };
                result.Add(c);
            }
            return result;
        }

        public IEntity ReturnEntity(SqlDataReader reader)
        {
            IEntity result = null;
            while (reader.Read())
            {
                Client c = new Client
                {
                    ClientId = (int)reader[0],
                    Name = (string)reader[1],
                    Place = (string)reader[2],
                    PIB = (int)reader[3],
                    Telephone = (int)reader[4],
                    Email = (string)reader[5]
                };
                result = c;
            }
            return result;
        }
    }
}
