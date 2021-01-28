using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IEntity
    {
        string TableName { get; }
        string InsertValues { get; }
        string IdName { get; }
        string JoinCondition { get; }
        string JoinTable { get; }
        string TableAlias { get; }
        object SelectValues { get; }
        object WhereValues { get; }
        object SetValues { get; }
        object ExistName { get; }
        object WhereReturn { get; }
        object GetWeightOfBox { get; }
        object Output { get; }
        object WherePosition { get; }
        string All { get; }
        object SetValues2 { get; }

        List<IEntity> GetEntities(SqlDataReader reader);
        IEntity ReturnEntity(SqlDataReader reader);
        void AddParametres(SqlCommand command);

        //List<IEntity> GetEntities(SqlDataReader reader);
    }
}
