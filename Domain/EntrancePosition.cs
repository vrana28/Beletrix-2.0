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
    public class EntrancePosition : IEntity
    {
        public int EntranceId { get; set; }
        public Entrance Entrance { get; set; }
        public string PositionId { get; set; }
        public Position Position { get; set; }

        [Browsable(false)]
        public string TableName => "EntrancePositions";
        [Browsable(false)]
        public string InsertValues => $"'{EntranceId}','{PositionId}'";
        [Browsable(false)]
        public string IdName => $"{EntranceId}";
        [Browsable(false)]
        public string JoinCondition => $"{PositionId}";
        [Browsable(false)]
        public string JoinTable => throw new NotImplementedException();
        [Browsable(false)]
        public string TableAlias => "e.EntranceId";
        [Browsable(false)]
        public object SelectValues => "e.EntranceId";
        [Browsable(false)]
        public object WhereValues => throw new NotImplementedException();
        [Browsable(false)]
        public object SetValues => "where EntranceId =";
        [Browsable(false)]
        public object ExistName => throw new NotImplementedException();
        [Browsable(false)]
        public object WhereReturn => " ep join  Entrance e on (ep.EntranceId = e.EntranceId)" +
              $" where ep.PositionId ";
        [Browsable(false)]
        public object GetWeightOfBox => throw new NotImplementedException();
        [Browsable(false)]
        public object Output => throw new NotImplementedException();
        [Browsable(false)]
        public object WherePosition => "";
        [Browsable(false)]
        public string All => throw new NotImplementedException();
        [Browsable(false)]
        public object SetValues2 => " and PositionId= ";

        public void AddParametres(SqlCommand command)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public IEntity ReturnEntity(SqlDataReader reader)
        {
            IEntity result = null;
            while (reader.Read())
            {
                EntrancePosition ep = new EntrancePosition
                {
                    EntranceId = (int)reader[0],
                    PositionId = (string)reader[1]
                };
                result = ep;
            }
            return result;
        }
    }
}
