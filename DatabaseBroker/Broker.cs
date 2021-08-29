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
using System.Collections.Specialized;
using System.Configuration;

namespace DatabaseBroker
{
    public class Broker
    {
        private SqlTransaction transaction;
        private SqlConnection connection;

        public Broker()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BeletrixDatabase"].ConnectionString);
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

        public DataTable BusyEntrancesWithDate(Entrance entity, Client client, Roba roba, DateTime datumOd, DateTime datumDo)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);

            if (client != null && roba != null)
            {
                command.CommandText = $" {entity.Izvestaj} and r.Name = '{roba.Name}' and c.Name = '{client.Name}' and (MONTH(e.DateOfEntrance) >= {datumOd.Month} and DAY(e.DateOfEntrance) >= {datumOd.Day} and YEAR(e.DateOfEntrance) >= {datumOd.Year} ) and ( MONTH(e.DateOfEntrance) <= {datumDo.Month} and DAY(e.DateOfEntrance) <= {datumDo.Day} and YEAR(e.DateOfEntrance) <= {datumDo.Year} ) {entity.Order}";
            }
            if (client != null && roba == null)
            {
                command.CommandText = $"{entity.Izvestaj} and c.Name = '{client.Name}' and (MONTH(e.DateOfEntrance) >= {datumOd.Month} and DAY(e.DateOfEntrance) >= {datumOd.Day} and YEAR(e.DateOfEntrance) >= {datumOd.Year} ) and ( MONTH(e.DateOfEntrance) <= {datumDo.Month} and DAY(e.DateOfEntrance) <= {datumDo.Day} and YEAR(e.DateOfEntrance) <= {datumDo.Year} ) {entity.Order}";
            }
            if (client == null && roba != null)
            {
                command.CommandText = $"{entity.Izvestaj} and r.Name = '{roba.Name}' and (MONTH(e.DateOfEntrance) >= {datumOd.Month} and DAY(e.DateOfEntrance) >= {datumOd.Day} and YEAR(e.DateOfEntrance) >= {datumOd.Year} ) and ( MONTH(e.DateOfEntrance) <= {datumDo.Month} and DAY(e.DateOfEntrance) <= {datumDo.Day} and YEAR(e.DateOfEntrance) <= {datumDo.Year} ) {entity.Order}";
            }
            if (client == null && roba == null)
            {
                command.CommandText = $"{entity.Izvestaj} and (MONTH(e.DateOfEntrance) >= {datumOd.Month} and DAY(e.DateOfEntrance) >= {datumOd.Day} and YEAR(e.DateOfEntrance) >= {datumOd.Year} ) and ( MONTH(e.DateOfEntrance) <= {datumDo.Month} and DAY(e.DateOfEntrance) <= {datumDo.Day} and YEAR(e.DateOfEntrance) <= {datumDo.Year} ) {entity.Order}";
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;
        }

        public DataTable OutputEntrancesWithDate(Entrance entity, Client client, Roba roba, DateTime datumOd, DateTime datumDo)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);

            if (client != null && roba != null)
            {
                command.CommandText = $" {entity.Izvestaj2} and r.Name = '{roba.Name}' and c.Name = '{client.Name}' and (MONTH(e.DateOfExit) >= {datumOd.Month} and DAY(e.DateOfExit) >= {datumOd.Day} and YEAR(e.DateOfExit) >= {datumOd.Year} ) and ( MONTH(e.DateOfExit) <= {datumDo.Month} and DAY(e.DateOfExit) <= {datumDo.Day} and YEAR(e.DateOfExit) <= {datumDo.Year} )) {entity.Izvestaj2Nastavak} where r.Name = '{roba.Name}' and c.Name = '{client.Name}' and (MONTH(li.DateOfLeaving) >= {datumOd.Month} and DAY(li.DateOfLeaving) >= {datumOd.Day} and YEAR(li.DateOfLeaving) >= {datumOd.Year} ) and ( MONTH(li.DateOfLeaving) <= {datumDo.Month} and DAY(li.DateOfLeaving) <= {datumDo.Day} and YEAR(li.DateOfLeaving) <= {datumDo.Year} ) ) {entity.Order}";
            }
            if (client != null && roba == null)
            {
                command.CommandText = $"{entity.Izvestaj2} and c.Name = '{client.Name}' and (MONTH(e.DateOfExit) >= {datumOd.Month} and DAY(e.DateOfExit) >= {datumOd.Day} and YEAR(e.DateOfExit) >= {datumOd.Year} ) and ( MONTH(e.DateOfExit) <= {datumDo.Month} and DAY(e.DateOfExit) <= {datumDo.Day} and YEAR(e.DateOfExit) <= {datumDo.Year} )) {entity.Izvestaj2Nastavak} where c.Name = '{client.Name}' and (MONTH(li.DateOfLeaving) >= {datumOd.Month} and DAY(li.DateOfLeaving) >= {datumOd.Day} and YEAR(li.DateOfLeaving) >= {datumOd.Year} ) and ( MONTH(li.DateOfLeaving) <= {datumDo.Month} and DAY(li.DateOfLeaving) <= {datumDo.Day} and YEAR(li.DateOfLeaving) <= {datumDo.Year} ) ) {entity.Order}";
            }
            if (client == null && roba != null)
            {
                command.CommandText = $"{entity.Izvestaj2} and r.Name = '{roba.Name}' and (MONTH(e.DateOfExit) >= {datumOd.Month} and DAY(e.DateOfExit) >= {datumOd.Day} and YEAR(e.DateOfExit) >= {datumOd.Year} ) and ( MONTH(e.DateOfExit) <= {datumDo.Month} and DAY(e.DateOfExit) <= {datumDo.Day} and YEAR(e.DateOfExit) <= {datumDo.Year} )) {entity.Izvestaj2Nastavak} where r.Name = '{roba.Name}' and (MONTH(li.DateOfLeaving) >= {datumOd.Month} and DAY(li.DateOfLeaving) >= {datumOd.Day} and YEAR(li.DateOfLeaving) >= {datumOd.Year} ) and (MONTH(li.DateOfLeaving) <= {datumDo.Month} and DAY(li.DateOfLeaving) <= {datumDo.Day} and YEAR(li.DateOfLeaving) <= {datumDo.Year} ) )  {entity.Order}";
            }
            if (client == null && roba == null)
            {
                command.CommandText = $"{entity.Izvestaj2} and (MONTH(e.DateOfExit) >= {datumOd.Month} and DAY(e.DateOfExit) >= {datumOd.Day} and YEAR(e.DateOfExit) >= {datumOd.Year} ) and ( MONTH(e.DateOfExit) <= {datumDo.Month} and DAY(e.DateOfExit) <= {datumDo.Day} and YEAR(e.DateOfExit) <= {datumDo.Year} ) ) {entity.Izvestaj2Nastavak} where  (MONTH(li.DateOfLeaving) >= {datumOd.Month} and DAY(li.DateOfLeaving) >= {datumOd.Day} and YEAR(li.DateOfLeaving) >= {datumOd.Year} ) and ( MONTH(li.DateOfLeaving) <= {datumDo.Month} and DAY(li.DateOfLeaving) <= {datumDo.Day} and YEAR(li.DateOfLeaving) <= {datumDo.Year} ) ) {entity.Order}";
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;
        }

        public DataTable OutputEntrances(Entrance entity, LeavingItem leavingItem, Client client, Roba roba)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);

            if (client != null && roba != null)
            {
                command.CommandText = $" {entity.Izvestaj2} and r.Name = '{roba.Name}' and c.Name = '{client.Name}' ) {entity.Izvestaj2Nastavak} where r.Name = '{roba.Name}' and c.Name = '{client.Name}' ) {entity.Order}";
            }
            if (client != null && roba == null)
            {
                command.CommandText = $"{entity.Izvestaj2} and c.Name = '{client.Name}' ) {entity.Izvestaj2Nastavak} where c.Name = '{client.Name}' ) {entity.Order}";
            }
            if (client == null && roba != null)
            {
                command.CommandText = $"{entity.Izvestaj2} and r.Name = '{roba.Name}' ) {entity.Izvestaj2Nastavak} where r.Name = '{roba.Name}' )  {entity.Order}";
            }
            if (client == null && roba == null)
            {
                command.CommandText = $"{entity.Izvestaj2} ) {entity.Izvestaj2Nastavak} ) {entity.Order}";
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;
        }

        public DataTable BusyEntrances(Entrance entity, Client client, Roba roba)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);

            if (client != null && roba != null)
            {
                command.CommandText = $" {entity.Izvestaj} and r.Name = '{roba.Name}' and c.Name = '{client.Name}' {entity.Order}";
            }
            if (client != null && roba == null)
            {
                command.CommandText = $"{entity.Izvestaj} and c.Name = '{client.Name}' {entity.Order}";
            }
            if (client == null && roba != null)
            {
                command.CommandText = $"{entity.Izvestaj} and r.Name = '{roba.Name}' {entity.Order}";
            }
            if (client == null && roba == null)
            {
                command.CommandText = $"{entity.Izvestaj} {entity.Order}";
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            dataAdapter.Fill(table);
            return table;
        }

        public void Update(IEntity entity)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
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

        // za trazenje entrance - ULAZA
        public IEntity ReturnEntity2(IEntity position, object positionId)
        {
            IEntity result;
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"select * from {position.TableName} where PositionId like '{positionId}' and Aktivno = 1";
            SqlDataReader reader = command.ExecuteReader();
            result = position.ReturnEntity(reader);
            reader.Close();
            return result;
        }

        // za trazenje pozicije

        public Position ReturnEntity3(Position position, string positionId)
        {
            IEntity result;
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"select * from {position.TableName} where PositionId like '{positionId}'";
            SqlDataReader reader = command.ExecuteReader();
            result = position.ReturnEntity(reader);
            reader.Close();
            return (Position)result;
        }

        // id repository
        public void UpdateWithParameter2(IEntity entity, Entrance ent)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"update {entity.TableName} {entity.SetValues2} {ent.EntranceId}";
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Database error!");
            }
        }

        public void SaveEntranceItem(EntranceItems ei)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"insert into EntranceItems values (@Num,@EntranceId,@RobaId,@DeadlineDate,@Deadline,@NumOfBoxes,@DateOfManu)";
            command.Parameters.AddWithValue("@Num", ei.Num);
            command.Parameters.AddWithValue("@EntranceId", ei.EntranceId);
            command.Parameters.AddWithValue("@RobaId", ei.RobaId);
            command.Parameters.AddWithValue("@DeadlineDate", ei.DeadlineDate);
            command.Parameters.AddWithValue("@Deadline", ei.Deadline);
            command.Parameters.AddWithValue("@NumOfBoxes", ei.NumOfBoxes);
            command.Parameters.AddWithValue("@DateOfManu", ei.DateOfManu);
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Database error!");
            }
        }

        public void UpdateEntranceWithPostion(Entrance e, string positionId)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"update {e.TableName} {e.SetValues3} '{positionId}', Obradjen = 1, Aktivno = 1 {e.SetValues4} {e.EntranceId} ";
            if (command.ExecuteNonQuery() != 1)
            {
                throw new Exception("Database error - entrance update!");
            }
        }

        //id entrance
        public void UpdateWithParameter3(IEntity entity, Entrance ent)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"update {entity.TableName} {entity.SetValues2} '{ent.PositionId}'";
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
