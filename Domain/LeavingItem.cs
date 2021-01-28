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
    public class LeavingItem : IEntity
    {
        public int LeavingItemId { get; set; }
        public int EntranceId { get; set; }
        public int Num { get; set; }
        public int RobaId { get; set; }
        public Roba Roba { get; set; }
        public double NumOfBoxes { get; set; }
        public DateTime DateOfLeaving { get; set; }

        [Browsable(false)]
        public string TableName => "LeavingItems";
        [Browsable(false)]
        public string InsertValues => $"'{EntranceId}','{Num}','{RobaId}','{NumOfBoxes}','{DateOfLeaving}'";
        [Browsable(false)]
        public string IdName => throw new NotImplementedException();
        [Browsable(false)]
        public string JoinCondition => throw new NotImplementedException();
        [Browsable(false)]
        public string JoinTable => throw new NotImplementedException();
        [Browsable(false)]
        public string TableAlias => throw new NotImplementedException();
        [Browsable(false)]
        public object SelectValues => throw new NotImplementedException();
        [Browsable(false)]
        public object WhereValues => throw new NotImplementedException();
        [Browsable(false)]
        public object SetValues => throw new NotImplementedException();
        [Browsable(false)]
        public object ExistName => throw new NotImplementedException();
        [Browsable(false)]
        public object WhereReturn => throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEntity ReturnEntity(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
