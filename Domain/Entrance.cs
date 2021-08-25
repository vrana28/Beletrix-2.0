using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Serializable]
    public class Entrance : IEntity
    {
        public int EntranceId { get; set; }
        public double TotalWeight { get; set; }
        public DateTime DateOfEntrance { get; set; }
        public DateTime DateOfExit { get; set; } 
        public string Dimension { get; set; }
        // u smislu dal je obracunat na kraju meseca
        public bool Obradjen { get; set; }
        public int ClientId { get; set; }
        public Storekeeper Storekeeper { get; set; }
        public List<EntranceItems> Items  { get; set; }
        public string PositionId { get; set; } = null;
        public bool Aktivno { get; set; }
        
        [Browsable(false)]
        public string TableName => "Entrance";
        [Browsable(false)]
        public string InsertValues => $" (@Weight,@DateOfEntrance,@DateOfExit, @Dimension,@Obradjen, @ClientId, @StorekeeperId, @PositionId, @Aktivno)";
        [Browsable(false)]
        public string IdName => "";
        [Browsable(false)]
        public string JoinCondition => throw new NotImplementedException();
        [Browsable(false)]
        public string JoinTable => " e join EntranceItems ei on(e.EntranceId = ei.EntranceId)"
+ " join Clients c on(e.ClientId = c.ClientId) join Roba r on(ei.RobaId = r.RobaId) where e.Weight > 0 and e.Obradjen = 0";
        [Browsable(false)]
        public string TableAlias => " ei.EntranceId as Sifra_Ulaza, r.Name as Product, (ei.NumOfBoxes* r.WeightOfBox) as Tezina, " +
                $"ei.NumOfBoxes as Br_Kuija ,c.Name as Klijent ";
        [Browsable(false)]
        public object SelectValues => "";
        [Browsable(false)]
        public object WhereValues => $" where EntranceId = {EntranceId}";
        [Browsable(false)]
        public object SetValues => " set Obradjen = 1 where EntranceId = ";
        [Browsable(false)]
        public object ExistName => throw new NotImplementedException();
        [Browsable(false)]
        // za return metodu
        public object WhereReturn => " where EntranceId";
        [Browsable(false)]
        public object GetWeightOfBox => throw new NotImplementedException();
        [Browsable(false)]
        public object Output => " output inserted.EntranceId ";
        [Browsable(false)]
        public object WherePosition => "";
        [Browsable(false)]
        public string All => throw new NotImplementedException();
        [Browsable(false)]
        public object SetValues2 => $"set DateOfExit = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' , Aktivno = 0 where EntranceId = ";
        [Browsable(false)]
        public object SetValues3 => $"set PositionId = ";
        [Browsable(false)]
        public object SetValues4 => $" where EntranceId = ";
        [Browsable(false)]
        public string Izvestaj => "select e.EntranceID as Sifra_Ulaza, r.Name as Artikal, e.PositionId as Pozicija, (ei.NumOfBoxes* r.WeightOfBox) as Tezina,ei.NumOfBoxes as Broj_Kutija," +
                   " r.WeightOfBox as Tezina_Kutije, e.Dimension as Dobavljac, c.Name as Klijent, e.DateOfEntrance as Datum_ulaza, "
               + $" ei.DateOfManu as Datum_Proizvodnje from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
               + $"join Roba r on (r.RobaId = ei.RobaId) "
               + $"join Clients c on (c.ClientId = e.ClientId) where e.Aktivno = 1 and e.DateOfExit < '{new DateTime(2019,8,18)}' ";
        [Browsable(false)]
        public string Order => " order by e.PositionId";
        [Browsable(false)]
        public string Izvestaj2 => "(select e.EntranceID as Sifra_Ulaza, r.Name as Artikal, e.PositionId as Pozicija, (ei.NumOfBoxes* r.WeightOfBox) as Tezina,ei.NumOfBoxes as Broj_Kutija," +
                   " r.WeightOfBox as Tezina_Kutije, e.Dimension as Dobavljac, c.Name as Klijent, e.DateOfEntrance as Datum_ulaza, e.DateOfExit as Datum_Izlaza, "
               + $" ei.DateOfManu as Datum_Proizvodnje from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
               + $"join Roba r on (r.RobaId = ei.RobaId) "
               + $"join Clients c on (c.ClientId = e.ClientId) " +
            $" where e.DateOfExit > '{new DateTime(2019, 8, 18)}'  ";
        [Browsable(false)]
        public string Izvestaj2Nastavak => " UNION" +
            $" ( select e.EntranceID as Sifra_Ulaza, r.Name as Artikal, e.PositionId as Pozicija, (li.NumOfBoxes* r.WeightOfBox) as Tezina,li.NumOfBoxes as Broj_Kutija," +
                   " r.WeightOfBox as Tezina_Kutije, e.Dimension as Dobavljac, c.Name as Klijent, e.DateOfEntrance as Datum_ulaza, li.DateOfLeaving as Datum_Izlaza, "
               + $" ei.DateOfManu as Datum_Proizvodnje from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
               + $" join LeavingItems li on (li.EntranceId = e.EntranceId) join Roba r on (r.RobaId = li.RobaId) "
               + $"join Clients c on (c.ClientId = e.ClientId) ";
        public void AddParametres(SqlCommand command)
        {
            command.Parameters.AddWithValue("@Weight", TotalWeight);
            command.Parameters.AddWithValue("@DateOfEntrance", DateOfEntrance);
            command.Parameters.AddWithValue("@DateOfExit", "");
            command.Parameters.AddWithValue("@Dimension", Dimension);
            command.Parameters.AddWithValue("@Obradjen", Obradjen);
            command.Parameters.AddWithValue("@ClientId", ClientId);
            command.Parameters.AddWithValue("@StorekeeperId", Storekeeper.StorekeeperId);
            command.Parameters.AddWithValue("@PositionId", "");
            command.Parameters.AddWithValue("@Aktivno", false);
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
                Entrance e = new Entrance
                {
                    EntranceId = (int)reader[0],
                    TotalWeight = (double)reader[1],
                    DateOfEntrance = (DateTime)reader[2],
                    //DateOfExit = (DateTime) reader[3],
                    Dimension = (string)reader[4],
                    Obradjen = (bool)reader[5],
                    ClientId = (int)reader[6],
                };
                result = e;
            }
            return result;
        }
    }
}
