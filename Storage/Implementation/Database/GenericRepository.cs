using DatabaseBroker;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Implementation.Database
{
    public class GenericRepository : IGenericRepository
    {
        Broker broker = new Broker();
        public void BeginTransaction()
        {
            broker.BeginTransaction();
        }

        public void CloseConnection()
        {
            broker.CloseConnection();
        }

        public void Commit()
        {
            broker.Commit();
        }

        public void Delete(IEntity entity)
        {
            broker.Delete(entity);
        }

        public void Delete2(IEntity entity)
        {
            broker.Delete2(entity);
        }

        public bool Exist(IEntity entity)
        {
            return broker.Exist(entity);
        }

        public List<IEntity> GetAll(IEntity e)
        {
            return broker.GetAll(e);
        }

        public DataTable GetAllJoin(IEntity entity)
        {
            return broker.GetAllJoin(entity);
        }

        public DataTable GetBusyPositions(IEntity entity1, IEntity entity2, IEntity entity3)
        {
            return broker.BusyPosition(entity1, entity2, entity3);
        }

        public DataTable GetBusyPositionsWithPosition(IEntity entity, IEntity e1, IEntity e2, object uslov)
        {
            return broker.BusyPositionWithPosition(entity, e1, e2, uslov);
        }

        public int GetNewId(IEntity e)
        {
            throw new NotImplementedException();
        }

        public double GetWeightOfBox(IEntity entity, object uslov)
        {
            return (double)broker.GetWeightOfBox(entity,uslov);
        }

        public IEntity LogIn(IEntity entity)
        {
            return broker.ReturnEntityLogIn(entity);
        }

        public void OpenConnection()
        {
            broker.OpenConnection();
        }


        public IEntity Return(IEntity entity, object uslov)
        {
            return broker.ReturnEntity(entity, uslov);
        }

        public IEntity Return2(IEntity position, object positionId)
        {
            return broker.ReturnEntity2(position, positionId);
        }

        public void Rollback()
        {
            broker.Rollback();
        }

        public void Save(IEntity entity)
        {
            broker.Save(entity);
        }

        public int SaveEntrance(IEntity entity)
        {
            return (int)broker.SaveEntrance(entity); 
        }

        public void SaveEntranceItem(EntranceItems ei)
        {
            broker.SaveEntranceItem(ei);
        }

        public List<IEntity> Search(IEntity entity, object uslov)
        {
            return broker.Search(entity, uslov);
        }

        // show entrance items on position
        public DataTable ShowEntranceItems(IEntity entity, object uslov)
        {
            return broker.GetAllJoinWithParameter(entity, uslov);
        }

        public void Update(IEntity entity)
        {
            broker.Update(entity);
        }

        public void UpdateWithParameters(IEntity entity, object values)
        {
            broker.UpdateWithParameter(entity, values);
        }

        public void UpdateWithParameters2(IEntity ent1, IEntity entity)
        {
            if (ent1.GetType() == typeof(Position))
            {
                broker.UpdateWithParameter3(ent1, (Entrance)entity);
            }
            else {
                broker.UpdateWithParameter2(ent1, (Entrance)entity);
            }
        }

        public void UpdateWithParameters3(Entrance e, string positionId)
        {
            broker.UpdateEntranceWithPostion(e, positionId);
        }
    }
}
