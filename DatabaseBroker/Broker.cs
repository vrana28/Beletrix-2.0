using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void AddEntrance(Entrance e)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"insert into Entrances values (@Weight,@DateOfEntrance,@DateOfExit, @Dimension,@Obradjen, @ClientId, @StorekeeperId)";
            command.Parameters.AddWithValue("@Weight", e.TotalWeight);
            command.Parameters.AddWithValue("@DateOfEntrance", e.DateOfEntrance);
            command.Parameters.AddWithValue("@DateOfExit", e.DateOfExit);
            command.Parameters.AddWithValue("@Dimension", e.Dimension);
            command.Parameters.AddWithValue("@Obradjen", e.Obradjen);
            command.Parameters.AddWithValue("@ClientId", e.ClientId);
            command.Parameters.AddWithValue("@StorekeeperId", e.Storekeeper.StorekeeperId);
            command.ExecuteNonQuery();
        }


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
