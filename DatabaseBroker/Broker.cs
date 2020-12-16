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


        #region Connections
        public void OpenConnection() {
            connection.Open();
        }

        public void CloseConnection() {
            connection.Close();
        }
        #endregion


        public void AddRoba(Roba r)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "insert into Roba values (@Name, @WeightOfBox)";
            command.Parameters.AddWithValue("@Name", r.Name);
            command.Parameters.AddWithValue("@WeightOfBox",r.WeightOfBox);
            command.ExecuteNonQuery();
        }

        public bool FindRoba(Roba r)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Roba where Name = '{r.Name}'";
            Object result = command.ExecuteScalar();
            if (result == null) return false;
            else return true;
        }

        public void DeleteRoba(Roba r)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"delete from Roba where RobaId = {r.RobaId}";
            command.ExecuteNonQuery();
        }

        public List<Storekeeper> GetAllStorekeepers()
        {
            List<Storekeeper> users = new List<Storekeeper>();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from Storekeepers";
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
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

        public void UpdateRoba(Roba r)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"update Roba set Name = '{r.Name}', WeightOfBox = {r.WeightOfBox} where RobaId = {r.RobaId}";
            command.ExecuteNonQuery();
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

        public void DeleteStorekeeper(Storekeeper s)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"delete from Storekeepers where StorekeeperId = {s.StorekeeperId} ";
            command.ExecuteNonQuery();
        }

        public void DeleteClient(Client c)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"delete from Clients where ClientId = {c.ClientId} ";
            command.ExecuteNonQuery();
        }

        public void UpdateStorekeeper(Storekeeper s)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"update Storekeepers set Name = '{s.Name}', LastName = '{s.LastName}'" +
                $", Username = '{s.Username}', Password = '{s.Password}' where StorekeeperId = {s.StorekeeperId}";
            command.ExecuteNonQuery();
        }

        public void UpdateClient(Client c)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"update Clients set Name = '{c.Name}', Place = '{c.Place}', PIB = {c.PIB}," +
                $"Telephone = {c.Telephone}, Email = '{c.Email}' where ClientId = {c.ClientId} ";
            command.ExecuteNonQuery();
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
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "insert into Clients values (@Name, @Place, @PIB, @Telephone, @Email)";
            command.Parameters.AddWithValue("@Name", c.Name);
            command.Parameters.AddWithValue("@Place", c.Place);
            command.Parameters.AddWithValue("@PIB", c.PIB);
            command.Parameters.AddWithValue("@Telephone", c.Telephone);
            command.Parameters.AddWithValue("@Email", c.Email);
            command.ExecuteNonQuery();
        }

        public bool ExistClient(Client c)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Clients where Name = '{c.Name}' or PIB = {c.PIB}";
            Object result = command.ExecuteScalar();
            if (result == null) return false;
            else return true;
        }

        public bool ExistStorekeeper(string username)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from Storekeepers where Username = '{username}'";
            Object result = command.ExecuteScalar();
            if (result == null) return false;
            else return true;
        }

        public void AddStorekeeper(Storekeeper s)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "insert into Storekeepers values (@Name, @LastName, @Username, @Password)";
            command.Parameters.AddWithValue("@Name", s.Name);
            command.Parameters.AddWithValue("@LastName", s.LastName);
            command.Parameters.AddWithValue("@Username", s.Username);
            command.Parameters.AddWithValue("@Password", s.Password);
            command.ExecuteNonQuery();
        }
    }
}
