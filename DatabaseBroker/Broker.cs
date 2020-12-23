using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BeletrixData;Integrated Security=True;");
        }

        public void AddEntrancePosition(EntrancePosition ep)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"insert into EntrancePositions values (@EntranceId,@PositionId)";
            command.Parameters.AddWithValue("@EntranceId", ep.EntranceId);
            command.Parameters.AddWithValue("@PositionId",ep.PositionId );
            command.ExecuteNonQuery();
        }

        #region Position

        public List<Position> FindPositions(string v)
        {
            List<Position> pozicije = new List<Position>();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Positions where PositionId like '{v}'";
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
            
            string command = $"select ei.EntranceId, r.Name, e.Weight, c.Name from Entrance e join EntranceItems ei on (e.EntranceId = ei.EntranceId)"
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

       
        public double GetWeightOfBox(EntranceItems e)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select WeightOfBox from Roba r join EntranceItems ei on " +
                $"(r.Robaid = ei.RobaId) where ei.EntranceId = {e.EntranceId} and ei.Num = {e.Num} ";
            object result = command.ExecuteScalar();
            return (double)result;
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
            command.CommandText = $"insert into {gdo.GetName()} values ({gdo.GetAllValues()})";
            command.ExecuteNonQuery();
        }

        public void Update(GeneralDomainObject gdo)
        {
            SqlCommand command = connection.CreateCommand();
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
