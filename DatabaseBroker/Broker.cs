using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain;

namespace DatabaseBroker
{
    public class Broker
    {
        private SqlTransaction transaction;
        private SqlConnection connection;

        public Broker()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BeletrixDatabase;Integrated Security=True;");
        }

        public void AddEntrancePosition(EntrancePosition ep)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"insert into EntrancePositions values (@EntranceId,@PositionId)";
            command.Parameters.AddWithValue("@EntranceId", ep.EntranceId);
            command.Parameters.AddWithValue("@PositionId",ep.PositionId );
            command.ExecuteNonQuery();
        }

        //MORA PREKO TRANSAKCIJA
        public void ExitEntrancePosition(EntrancePosition entrancePosition)
        {
            SqlCommand command1 = connection.CreateCommand();
            command1.Transaction = transaction;
            command1.CommandText = $"update Positions set Slobodno = 1 where PositionId = '{entrancePosition.PositionId}'";
            command1.ExecuteNonQuery();

            DateTime date = DateTime.Now;
            
            SqlCommand command3 = connection.CreateCommand();
            command3.Transaction = transaction;
            command3.CommandText = $"update Entrance set DateOfExit = @Date where EntranceId = {entrancePosition.EntranceId}";
            command3.Parameters.AddWithValue("@Date", date);
            command3.ExecuteNonQuery();

            SqlCommand command2 = connection.CreateCommand();
            command2.Transaction = transaction;
            command2.CommandText = $"delete EntrancePositions where EntranceId = {entrancePosition.EntranceId} and " +
                $"PositionId='{entrancePosition.PositionId}'";
            command2.ExecuteNonQuery();

        }

        public void SaveEntranceItem(EntranceItems ei)
        {
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = $"insert into EntranceItems values (@Num,@EntranceId,@RobaId,@DeadlineDate, @Deadline" +
                $", @NumOfBoxes, @DateOfManu)";
            command.Parameters.AddWithValue("@Num", ei.Num);
            command.Parameters.AddWithValue("@EntranceId", ei.EntranceId);
            command.Parameters.AddWithValue("@RobaId", ei.RobaId);
            command.Parameters.AddWithValue("@DeadlineDate", ei.DeadlineDate);
            command.Parameters.AddWithValue("@Deadline", ei.Deadline);
            command.Parameters.AddWithValue("@NumOfBoxes", ei.NumOfBoxes);
            command.Parameters.AddWithValue("@DateOfManu", ei.DateOfManu);
            command.ExecuteNonQuery();
        }

        public int SaveEntrance(Entrance entrance)
        {
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = $"insert into Entrance output inserted.EntranceId values (@Weight,@DateOfEntrance,@DateOfExit, @Dimension,@Obradjen, @ClientId, @StorekeeperId)";
            command.Parameters.AddWithValue("@Weight", entrance.TotalWeight);
            command.Parameters.AddWithValue("@DateOfEntrance", entrance.DateOfEntrance);
            command.Parameters.AddWithValue("@DateOfExit", DBNull.Value);
            command.Parameters.AddWithValue("@Dimension", entrance.Dimension);
            command.Parameters.AddWithValue("@Obradjen", entrance.Obradjen);
            command.Parameters.AddWithValue("@ClientId", entrance.ClientId);
            command.Parameters.AddWithValue("@StorekeeperId", entrance.Storekeeper.StorekeeperId);
            
            return (int)command.ExecuteScalar();

        }

        public double GetWeightOfBox(int robaId)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select WeightOfBox from Roba where RobaId = {robaId}";
            object result = command.ExecuteScalar();
            return (double)result;
        }

        public DataTable FindBusyPositionsWithPosition(Client client, Roba roba, string v)
        {
            string command = "";
            if (client != null && roba != null)
            {
                command = "select r.Name as Product,ep.PositionId as Pozicija,(ei.NumOfBoxes * r.WeightOfBox) as Ukupna_Tezina,ei.NumOfBoxes as Broj_Kutija," +
                   " r.WeightOfBox as Tezina_Kutije, c.Name as Klijent,"
               + $" ei.DateOfManu as Datum_Proiz from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
               + $"join EntrancePositions ep on (e.EntranceId = ep.EntranceId) join Roba r on (r.RobaId = ei.RobaId)"
               + $"join Clients c on (c.ClientId = e.ClientId) where c.ClientId = {client.ClientId} and r.RobaId = {roba.RobaId} and ep.PositionId like '{v}'";
            }
            if (client != null && roba == null)
            {
                command = "select r.Name as Product,ep.PositionId as Pozicija,(ei.NumOfBoxes * r.WeightOfBox) as Tezina,ei.NumOfBoxes as Broj_Kutija," +
                   " r.WeightOfBox as Tezina_Kutije, c.Name as Klijent,"
               + $" ei.DateOfManu as Datum_Proiz from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
               + $"join EntrancePositions ep on (e.EntranceId = ep.EntranceId) join Roba r on (r.RobaId = ei.RobaId)"
               + $"join Clients c on (c.ClientId = e.ClientId) where c.ClientId = {client.ClientId} and ep.PositionId like '{v}'";
            }
            if (client == null && roba != null)
            {
                command = "select r.Name as Product,ep.PositionId as Pozicija,(ei.NumOfBoxes * r.WeightOfBox) as Tezina,ei.NumOfBoxes as Broj_Kutija," +
                   " r.WeightOfBox as Tezina_Kutije,c.Name as Klijent,"
               + $" ei.DateOfManu as Datum_Proiz from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
               + $"join EntrancePositions ep on (e.EntranceId = ep.EntranceId) join Roba r on (r.RobaId = ei.RobaId)"
               + $"join Clients c on (c.ClientId = e.ClientId) where r.RobaId = {roba.RobaId} and ep.PositionId like '{v}'";
            }
            if (client == null && roba == null)
            {
                command = "select r.Name as Product,ep.PositionId as Pozicija,(ei.NumOfBoxes * r.WeightOfBox) as Tezina,ei.NumOfBoxes as Broj_Kutija," +
                   " r.WeightOfBox as Tezina_Kutije,c.Name as Klijent,"
               + $" ei.DateOfManu as Datum_Proiz from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
               + $"join EntrancePositions ep on (e.EntranceId = ep.EntranceId) join Roba r on (r.RobaId = ei.RobaId)"
               + $"join Clients c on (c.ClientId = e.ClientId) where ep.PositionId like '{v}' order by ep.PositionId";
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;
        }

        public void UpdateEntranceItems(EntranceItems item)
        {
            Update(item);
        }

        public EntrancePosition ReturnEntrancePosition(string pozicija)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select e.EntranceId from EntrancePositions ep join  Entrance e on (ep.EntranceId = e.EntranceId)" +
                $"where ep.PositionId = '{pozicija}'";
            object result = command.ExecuteScalar();
            EntrancePosition e = new EntrancePosition
            {
                EntranceId = int.Parse(result.ToString()),
                PositionId = pozicija
            };
            return e;
        }

        public DataTable FindBusyPositions(Client client, Roba roba)
        {
            string command = "";
            if (client != null && roba != null)
            {
                 command = "select r.Name as Product,ep.PositionId as Pozicija,(ei.NumOfBoxes * r.WeightOfBox) as Ukupna_Tezina,ei.NumOfBoxes as Broj_Kutija," +
                    " r.WeightOfBox as Tezina_Kutije, c.Name as Klijent,"
                +$" ei.DateOfManu as Datum_Proiz from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
                +$"join EntrancePositions ep on (e.EntranceId = ep.EntranceId) join Roba r on (r.RobaId = ei.RobaId)"
                +$"join Clients c on (c.ClientId = e.ClientId) where c.ClientId = {client.ClientId} and r.RobaId = {roba.RobaId}";
            }
            if (client != null && roba == null)
            {
                 command = "select r.Name as Product,ep.PositionId as Pozicija,(ei.NumOfBoxes * r.WeightOfBox) as Tezina,ei.NumOfBoxes as Broj_Kutija," +
                    " r.WeightOfBox as Tezina_Kutije, c.Name as Klijent,"
                + $" ei.DateOfManu as Datum_Proiz from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
                + $"join EntrancePositions ep on (e.EntranceId = ep.EntranceId) join Roba r on (r.RobaId = ei.RobaId)"
                + $"join Clients c on (c.ClientId = e.ClientId) where c.ClientId = {client.ClientId}";
            }
            if (client == null && roba != null)
            {
                 command = "select r.Name as Product,ep.PositionId as Pozicija,(ei.NumOfBoxes * r.WeightOfBox) as Tezina,ei.NumOfBoxes as Broj_Kutija," +
                    " r.WeightOfBox as Tezina_Kutije,c.Name as Klijent,"
                + $" ei.DateOfManu as Datum_Proiz from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
                + $"join EntrancePositions ep on (e.EntranceId = ep.EntranceId) join Roba r on (r.RobaId = ei.RobaId)"
                + $"join Clients c on (c.ClientId = e.ClientId) where r.RobaId = {roba.RobaId}";
            }
            if (client == null && roba == null)
            {
                command = "select r.Name as Product,ep.PositionId as Pozicija,(ei.NumOfBoxes * r.WeightOfBox) as Tezina,ei.NumOfBoxes as Broj_Kutija," +
                   " r.WeightOfBox as Tezina_Kutije,c.Name as Klijent,"
               + $" ei.DateOfManu as Datum_Proiz from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
               + $"join EntrancePositions ep on (e.EntranceId = ep.EntranceId) join Roba r on (r.RobaId = ei.RobaId)"
               + $"join Clients c on (c.ClientId = e.ClientId) order by ep.PositionId";
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;

        }

        public List<EntranceItems> ReturnEntranceItems(int entranceId)
        {
            List<EntranceItems> items = new List<EntranceItems>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from EntranceItems ei join Roba r on (ei.RobaId=r.RobaId) where EntranceId = '{entranceId}'";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                EntranceItems item = new EntranceItems
                {
                    Num = (int)reader[0],
                    EntranceId = (int)reader[1],
                    Roba = new Roba { 
                        RobaId = (int)reader[2],
                        Name = (string)reader[8]
                    },
                    RobaId = (int)reader[2],
                    DeadlineDate = (DateTime)reader[3],
                    Deadline = (bool) reader[4],
                    NumOfBoxes = (double) reader[5],
                    DateOfManu = (DateTime) reader[6]
                };
                items.Add(item);
            }
            return items;
        }

        public DataTable GetSpecificItems(EntranceItems ei, Entrance entrance)
        {
            string command = $"select ei.Num as Br,e.EntranceId, r.Name as Product, (ei.NumOfBoxes*r.WeightOfBox) as Tezina," 
            +$" ei.NumOfBoxes as Broj_kutija, ei.DateOfManu as Datum_Proizvodnje,c.Name as Klijent"
            +$" from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
            +$" join Roba r on (ei.RobaId = r.RobaId) join Clients c on (e.ClientId = e.ClientId)"
            +$" where e.EntranceId = {ei.EntranceId} and c.ClientId = {entrance.ClientId}";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command, connection);
            SqlCommandBuilder biulder = new SqlCommandBuilder(dataAdapter);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;
        }

        #region Position

        public List<Position> FindPositions(string v)
        {
            List<Position> pozicije = new List<Position>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Positions where PositionId like '{v}' and Slobodno = 1";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Position p = new Position
                {
                    PositionId = (string)reader[0],
                    Slobodna = (bool)reader[1]
                };
                pozicije.Add(p);
            }
            return pozicije;
        }

        public DataTable ShowItemsOnPosition(string positionId)
        {
            string command = $"Select r.Name as Naziv,(ei.NumOfBoxes*r.WeightOfBox) as Tezina,ei.DateOfManu as Datum, c.Name as Klijent"
            +$" from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
            +$" join EntrancePositions ep on (ep.EntranceId = e.EntranceId) join Roba r on (ei.RobaId = r.RobaId) join Clients c on (c.ClientId = e.ClientId) where ep.PositionId = '{positionId}'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;
        }

        public void SetEntranceTrue(int entranceId)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"update Entrance set Obradjen = {1} where EntranceId = '{entranceId}'";
            command.ExecuteNonQuery();
        }

        public void UpdatePosition(string positionId)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"update Positions set Slobodno = {0} where PositionId = '{positionId}'";
            command.ExecuteNonQuery();
        }

        public List<Position> GetAllPositions()
        {
            List<Position> pozicije = new List<Position>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Positions where Slobodno = {1}";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Position p = new Position
                {
                    PositionId = (string)reader[0],
                    Slobodna = (bool)reader[1]
                };
                pozicije.Add(p);
            }
            return pozicije;
        }
        #endregion

        #region EntranceItem
        public void AddEntranceItem(EntranceItems ei)
        {
            Insert(ei);
        }



        #endregion

        #region Entrance
        public Entrance FindEntrance(int entranceId)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Entrance where EntranceId = {entranceId}";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Entrance e = new Entrance
                {
                    EntranceId = (int)reader[0],
                    TotalWeight = (double)reader[1],
                    DateOfEntrance = (DateTime)reader[2],
                    // DateOfExit  = (DateTime) reader[3],
                    Dimension = (string)reader[4],
                    Obradjen = (bool)reader[5],
                    ClientId = (int)reader[6]
                };
                return e;
            }
            return null;
        }
        public void AddEntrance(Entrance e)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"insert into Entrance values (@Weight,@DateOfEntrance,@DateOfExit, @Dimension,@Obradjen, @ClientId, @StorekeeperId)";
            command.Parameters.AddWithValue("@Weight", e.TotalWeight);
            command.Parameters.AddWithValue("@DateOfEntrance", e.DateOfEntrance);
            command.Parameters.AddWithValue("@DateOfExit", DBNull.Value);
            command.Parameters.AddWithValue("@Dimension", e.Dimension);
            command.Parameters.AddWithValue("@Obradjen", e.Obradjen);
            command.Parameters.AddWithValue("@ClientId", e.ClientId);
            command.Parameters.AddWithValue("@StorekeeperId", e.Storekeeper.StorekeeperId);
            command.ExecuteNonQuery();
        }

        public DataTable GetAllEntrances()
        {
            
            string command = $"select ei.EntranceId as Sifra_Ulaza, r.Name as Product, (ei.NumOfBoxes*r.WeightOfBox) as Tezina, " +
                $"ei.NumOfBoxes as Br_Kuija ,c.Name as Klijent from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
+ "join Clients c on(e.ClientId = c.ClientId) join Roba r on(ei.RobaId = r.RobaId) where e.Weight > 0 and e.Obradjen = 0";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command, connection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;
        }

       

        public void UpdateEntrances(Entrance entrance, double totalWeight)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"update Entrance set Weight = {totalWeight} where EntranceId = {entrance.EntranceId}";
            command.ExecuteNonQuery();
        }

       
        
        #endregion

        #region Other
        public int GetMaxId()
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select max(EntranceId) from Entrance";
            object result = command.ExecuteScalar();
            return (int)result;
        }

        #endregion

        #region GenericMethods
        public void Insert(GeneralDomainObject gdo) {
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = $"insert into {gdo.GetName()} values ({gdo.GetAllValues()})";
            command.ExecuteNonQuery();
        }

        public void Update(GeneralDomainObject gdo)
        {
            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.Transaction = transaction;
            command.CommandText = $"update {gdo.GetName()} set {gdo.SetValues()}";
            command.ExecuteNonQuery();
        }

        public void Delete(GeneralDomainObject gdo) {

            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"delete from {gdo.GetName()} {gdo.GetWhereValues()}";
            command.ExecuteNonQuery();
        }

        public bool Exist(GeneralDomainObject gdo) {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"Select * from {gdo.GetName()} {gdo.GetWhereName()}";
            Object result = command.ExecuteScalar();
            if (result == null) return false;
            else return true;
        }
        #endregion

        #region Connections
        public void OpenConnection() {
            connection.Open();
        }

        public void CloseConnection() {
            connection.Close();
        }

        public void Commit() {
            transaction?.Commit();
        }

        public void Rollback() {
            transaction?.Rollback();
        }

        public void BeginTransaction() {
            transaction = connection.BeginTransaction();
        }

        #endregion

        #region Roba
        public void AddRoba(Roba r)
        {
            Insert(r);
        }

        public bool FindRoba(Roba r)
        {
            return Exist(r);
        }

        public void DeleteRoba(Roba r)
        {
            Delete(r);
        }

        

        public void UpdateRoba(Roba r)
        {
            Update(r);
        }

        public List<Roba> GetAllRoba()
        {
            List<Roba> robe = new List<Roba>();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from Roba";
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Roba r = new Roba
                {
                    RobaId = int.Parse(reader[0].ToString()),
                    Name = (string)reader[1],
                    WeightOfBox = double.Parse(reader[2].ToString()),
                };
                robe.Add(r);
            }
            return robe;
        }
        #endregion

        #region Storekeeper

        public List<Storekeeper> GetAllStorekeepers()
        {
            List<Storekeeper> users = new List<Storekeeper>();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from Storekeepers";
            SqlDataReader reader = command.ExecuteReader();

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
                users.Add(s);
            }
            return users;
        }
        public void DeleteStorekeeper(Storekeeper s)
        {
            Delete(s);
        }

        public void UpdateStorekeeper(Storekeeper s)
        {
            Update(s);
        }

        public bool ExistStorekeeper(Storekeeper s)
        {
            return Exist(s);
        }

        public void AddStorekeeper(Storekeeper s)
        {
            Insert(s);
        }

        #endregion

        #region Client
        public void DeleteClient(Client c)
        {
            Delete(c);
        }
        public void UpdateClient(Client c)
        {
            Update(c);
        }

        public List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from Clients";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                Client c = new Client { 
                    ClientId = (int)reader[0],
                    Name = (string)reader[1],
                    Place = (string) reader[2],
                    PIB = (int) reader[3],
                    Telephone = (int)reader[4],
                    Email = (string) reader[5]
                };
                clients.Add(c);
            }
            return clients;
        }

        public void AddClient(Client c)
        {
            Insert(c);
        }

        public bool ExistClient(Client c)
        {
            return Exist(c);
        }
        #endregion
       
    }
}
