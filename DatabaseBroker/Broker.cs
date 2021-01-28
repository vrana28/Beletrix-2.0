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

        #region GenericMethods
//--------------------------------------------------GENERICS---------------------------------------------------
        public List<IEntity> GetAll(IEntity entity)
        {
            List<IEntity> result;
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"select * from {entity.TableName} {entity.WherePosition}";
            SqlDataReader reader = command.ExecuteReader();
            result = entity.GetEntities(reader);
            reader.Close();
            return result;
        }

        public void Save(IEntity entity)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"insert into {entity.TableName} values ({entity.InsertValues})";
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Database error!");
            }
        }

        public void Update(IEntity entity)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.Transaction = transaction;
            command.CommandText = $"update {entity.TableName} {entity.SetValues}";
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Database error!");
            }
        }

        public void UpdateWithParameter(IEntity entity, object value)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"update {entity.TableName} {entity.SetValues} '{value}'";
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Database error!");
            }
        }
        // id repository
        public void UpdateWithParameter2(IEntity entity, IEntity ent)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"update {entity.TableName} {entity.SetValues2} '{ent.IdName}'";
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Database error!");
            }
        }
        //id entrance
        public void UpdateWithParameter3(IEntity entity, IEntity ent)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"update {entity.TableName} {entity.SetValues2} '{ent.JoinCondition}'";
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Database error!");
            }
        }
        public void Delete2(IEntity entity)
        {

            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"delete from {entity.TableName} {entity.SetValues} {entity.IdName}" +
                $" {entity.SetValues2} '{entity.JoinCondition}'";
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Database error!");
            }
        }


        public void Delete(IEntity entity) {

            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"delete from {entity.TableName} {entity.WhereValues}";
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Database error!");
            }
        }

        public bool Exist(IEntity entity) {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"Select * from {entity.TableName} {entity.ExistName}";
            Object result = command.ExecuteScalar();
            if (result == null) return false;
            else return true;
        }

        public IEntity ReturnEntity(IEntity entity ,object uslov) {
            IEntity result;
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"select * from {entity.TableName} {entity.WhereReturn} ='{uslov}'";
            SqlDataReader reader = command.ExecuteReader();
            result = entity.ReturnEntity(reader);
            reader.Close();
            return result;
        }
        public IEntity ReturnEntityLogIn(IEntity entity)
        {
            IEntity result;
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"select * from {entity.TableName} {entity.WhereReturn}";
            SqlDataReader reader = command.ExecuteReader();
            result = entity.ReturnEntity(reader);
            reader.Close();
            return result;
        }

        public object GetWeightOfBox(IEntity entity, object uslov)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"select {entity.GetWeightOfBox} '{uslov}'";
            object result = command.ExecuteScalar();
            return (double)result;
        }

        public object SaveEntrance(IEntity entity)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"insert into {entity.TableName} {entity.Output} values {entity.InsertValues}";
            entity.AddParametres(command);
            return command.ExecuteScalar();
        }

        public DataTable GetAllJoin(IEntity entity)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"select {entity.TableAlias} from {entity.TableName} {entity.JoinTable}";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;
        }

        public DataTable GetAllJoinWithParameter(IEntity entity, object value)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"select {entity.TableAlias} from {entity.JoinTable} '{value}'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;
        }

        public List<IEntity> Search(IEntity entity, object uslov)
        {
            List<IEntity> result;
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"select {entity.GetWeightOfBox} '{uslov}'";
            SqlDataReader reader = command.ExecuteReader();
            result = entity.GetEntities(reader);
            reader.Close();
            return result;
        }

        public DataTable BusyPosition(IEntity entity,IEntity entityClient, IEntity entityRoba)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);

            if (entityClient != null && entityRoba!= null)
            {
                command.CommandText = $" { entity.JoinTable} {entityClient.IdName} {entity.TableAlias} '{entityRoba.IdName}'";
            }
            if (entityClient != null && entityRoba == null)
            {
                command.CommandText = $"{entity.JoinTable} {entityClient.IdName}";
            }
            if (entityClient == null && entityRoba != null)
            {
                command.CommandText = $"{ entity.JoinCondition} {entityRoba.IdName}";
            }
            if (entityClient == null && entityRoba == null)
            {
                command.CommandText = $"{entity.All} {entity.WhereValues}";
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;
        }

        public DataTable BusyPositionWithPosition(IEntity entity, IEntity entityClient, IEntity entityRoba, object values)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);

            if (entityClient != null && entityRoba != null)
            {
                command.CommandText = $" { entity.JoinTable} {entityClient.IdName} {entity.TableAlias} '{entityRoba.IdName}' {entity.SelectValues} '{values}'";
            }
            if (entityClient != null && entityRoba == null)
            {
                command.CommandText = $"{entity.JoinTable} {entityClient.IdName} {entity.SelectValues} '{values}'";
            }
            if (entityClient == null && entityRoba != null)
            {
                command.CommandText = $"{ entity.JoinCondition} {entityRoba.IdName} {entity.SelectValues} '{values}'";
            }
            if (entityClient == null && entityRoba == null)
            {
                command.CommandText = $"{entity.All} {entity.WhereReturn} '{values}' {entity.WhereValues}";
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;
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
       
    }
}
