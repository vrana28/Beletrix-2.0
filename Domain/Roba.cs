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
    public class Roba : IEntity
    {
        public int RobaId { get; set; }
        public string Name { get; set; }
        public double WeightOfBox { get; set; }

        [Browsable(false)]
        public string TableName => "Roba";
        [Browsable(false)]
        public string InsertValues => $"'{Name}','{WeightOfBox}'";
        [Browsable(false)]
        public string IdName => $"{RobaId}";
        [Browsable(false)]
        public string JoinCondition => throw new NotImplementedException();
        [Browsable(false)]
        public string JoinTable => throw new NotImplementedException();
        [Browsable(false)]
        public string TableAlias => "";
        [Browsable(false)]
        public object SelectValues => "";
        [Browsable(false)]
        public object WhereValues => $" where RobaId = {RobaId}";
        [Browsable(false)]
        public object SetValues => $" set Name = '{Name}', WeightOfBox='{WeightOfBox}' where RobaId={RobaId}";
        [Browsable(false)]
        // za metodu Exist, koja vraca boolean
        public object ExistName => $" where Name = '{Name}'";
        [Browsable(false)]
        public object WhereReturn => $" where Name";
        // samo Roba implementira
        [Browsable(false)]
        public object GetWeightOfBox => $" WeightOfBox from Roba where RobaId = ";
        [Browsable(false)]
        public object Output => throw new NotImplementedException();
        [Browsable(false)]
        public object WherePosition => "";
        [Browsable(false)]
        public string All => throw new NotImplementedException();
        [Browsable(false)]
        public object SetValues2 => throw new NotImplementedException();
        [Browsable(false)]
        public void AddParametres(SqlCommand command)
        {
            
        }

        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                Roba r = new Roba
                {
                    RobaId = (int)reader[0],
                    Name = (string)reader[1],
                   WeightOfBox = (double)reader[2]
                };
                result.Add(r);
            }
            return result;
        }

        public IEntity ReturnEntity(SqlDataReader reader)
        {
            IEntity result = null;
            while (reader.Read())
            {
                Roba r = new Roba
                {
                    RobaId = (int)reader[0],
                    Name = (string)reader[1],
                    WeightOfBox = (double)reader[2]
                };
                result = r;
            }
            return result;
        }

        public override string ToString()
        {
            return $"{Name} ";
        }
    }
}
