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
    public class EntranceItems : IEntity
    {
        public int Num { get; set; }
        public int EntranceId { get; set; }
        public int RobaId { get; set; }
        public DateTime DeadlineDate { get; set; }
        public DateTime DateOfManu { get; set; }
        public Roba Roba { get; set; }
        public bool Deadline { get; set; }
        public double NumOfBoxes { get; set; }

        [Browsable(false)]
        public string TableName => "EntranceItems";
        [Browsable(false)]
        public string InsertValues => $"'{Num}','{EntranceId}','{RobaId}','{DeadlineDate}','{Deadline}','{NumOfBoxes}','{DateOfManu}'";
        [Browsable(false)]
        public string IdName => throw new NotImplementedException();
        [Browsable(false)]
        public string JoinCondition => throw new NotImplementedException();
        [Browsable(false)]
        public string JoinTable => "Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
               + $" join EntrancePositions ep on (ep.EntranceId = e.EntranceId) join Roba r on (ei.RobaId = r.RobaId) join Clients c on (c.ClientId = e.ClientId) where ep.PositionId =";
        [Browsable(false)]
        public string TableAlias => " r.Name as Naziv,(ei.NumOfBoxes*r.WeightOfBox) as Tezina,ei.DateOfManu as Datum, c.Name as Klijent ";
        [Browsable(false)]
        public object SelectValues => throw new NotImplementedException();
        [Browsable(false)]
        public object WhereValues => throw new NotImplementedException();
        [Browsable(false)]
        public object SetValues => $" set NumOfBoxes = {NumOfBoxes} where EntranceId = '{EntranceId}' and Num = '{Num}'";
        [Browsable(false)]
        public object ExistName => throw new NotImplementedException();
        [Browsable(false)]
        public object WhereReturn => throw new NotImplementedException();
        [Browsable(false)]
        public object GetWeightOfBox => " * from EntranceItems ei join Roba r on (ei.RobaId=r.RobaId) where EntranceId = ";
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
                EntranceItems item = new EntranceItems
                {
                    Num = (int)reader[0],
                    EntranceId = (int)reader[1],
                    Roba = new Roba
                    {
                        RobaId = (int)reader[2],
                        Name = (string)reader[8]
                    },
                    RobaId = (int)reader[2],
                    DeadlineDate = (DateTime)reader[3],
                    Deadline = (bool)reader[4],
                    NumOfBoxes = (double)reader[5],
                    DateOfManu = (DateTime)reader[6]
                };
                result.Add(item);
            }
            return result;
        }
        

        public IEntity ReturnEntity(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
