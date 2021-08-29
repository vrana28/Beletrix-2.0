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
    public class Position : IEntity
    {
        public string PositionId { get; set; }
        public bool Slobodna { get; set; }

        [Browsable(false)]
        public string TableName => "Positions";
        [Browsable(false)]
        public string InsertValues => throw new NotImplementedException();
        [Browsable(false)]
        public string IdName => throw new NotImplementedException();
        [Browsable(false)]
        public string JoinCondition => "select e.EntranceId as Sifra_Ulaza,r.Name as Artikal,e.PositionId as Pozicija,(ei.NumOfBoxes * r.WeightOfBox) as Tezina,ei.NumOfBoxes as Broj_Kutija," +
                   " r.WeightOfBox as Tezina_Kutije,c.Name as Klijent,"
               + $" ei.DateOfManu as Datum_Proiz from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
               + $"join Roba r on (r.RobaId = ei.RobaId)"
               + $"join Clients c on (c.ClientId = e.ClientId) where e.Aktivno = 1 and r.RobaId = ";
        [Browsable(false)]
        public string JoinTable => "select e.EntranceId as Sifra_Ulaza,r.Name as Artikal,e.PositionId as Pozicija,(ei.NumOfBoxes * r.WeightOfBox) as Ukupna_Tezina,ei.NumOfBoxes as Broj_Kutija," +
                   " r.WeightOfBox as Tezina_Kutije, c.Name as Klijent,"
               + $" ei.DateOfManu as Datum_Proiz from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
               + $"join Roba r on (r.RobaId = ei.RobaId)"
               + $"join Clients c on (c.ClientId = e.ClientId) where e.Aktivno = 1 and c.ClientId = ";
        [Browsable(false)]
        public string TableAlias => " and r.RobaId = ";
 
        [Browsable(false)]
        public object SelectValues => " and e.PositionId like ";
        [Browsable(false)]
        public object WhereValues => "order by e.PositionId";
        [Browsable(false)]
        public object SetValues => " set Slobodno = 0 where PositionId = ";
        [Browsable(false)]
        public object ExistName => throw new NotImplementedException();
        [Browsable(false)]
        public object WhereReturn => "and e.PositionId like ";
        [Browsable(false)]
        public object GetWeightOfBox => " * from Positions where Slobodno = 1 and PositionId like ";
        //    command.CommandText = $"select * from Positions where PositionId like '{v}' and Slobodno = 1";
        [Browsable(false)]
        public object Output => throw new NotImplementedException();
        [Browsable(false)]
        public object WherePosition => $" where Slobodno = '{true}'";
        [Browsable(false)]
        public string All => "select e.EntranceId as Sifra_Ulaza,r.Name as Artikal,e.PositionId as Pozicija,(ei.NumOfBoxes * r.WeightOfBox) as Tezina,ei.NumOfBoxes as Broj_Kutija," +
                   " r.WeightOfBox as Tezina_Kutije,c.Name as Klijent,"
               + $" ei.DateOfManu as Datum_Proiz from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
               + $"join Roba r on (r.RobaId = ei.RobaId) "
               + $"join Clients c on (c.ClientId = e.ClientId) where e.Aktivno = 1";
        [Browsable(false)]
        public object SetValues2 => "set Slobodno = 1 where PositionId =";

        public void AddParametres(SqlCommand command)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetEntities(SqlDataReader reader)
        {
            List<IEntity> result = new List<IEntity>();
            while (reader.Read())
            {
                Position p = new Position
                {
                    PositionId = (string)reader[0],
                    Slobodna= (bool)reader[1],
                   
                };
                result.Add(p);
            }
            return result;
        }

        public IEntity ReturnEntity(SqlDataReader reader)
        {
            IEntity result = null;
            while (reader.Read())
            {
                Position p = new Position
                {
                    PositionId = (string)reader[0],
                    Slobodna = (bool)reader[1],
                };
                result = p;
            }
            return result;
        }
    }
}
