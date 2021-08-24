using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IGenericRepository
    {
        void Save(IEntity entity);
        List<IEntity> GetAll(IEntity e);
        int GetNewId(IEntity e);
        void Delete(IEntity entity);
        void Update(IEntity entity);
        bool Exist(IEntity entity);
        void UpdateWithParameters2(IEntity ent1, IEntity entity);
        DataTable ShowEntranceItems(IEntity entity, object uslov);
        Position Return3(Position position, string positionId);
        IEntity Return2(IEntity position, object positionId);
        void SaveEntranceItem(EntranceItems ei);
        void UpdateWithParameters3(Entrance e, string entranceId);
        List<IEntity> Search(IEntity entity, object uslov);
        void Delete2(IEntity entity);
        DataTable GetBusyPositions(IEntity entity1, IEntity entity2,  IEntity entity3);
        DataTable GetBusyPositionsWithPosition(IEntity entity, IEntity e1, IEntity e2, object uslov);
        DataTable GetAllJoin(IEntity entity);
        IEntity Return(IEntity entity, object uslov);
        void UpdateWithParameters(IEntity entity, object values);
        IEntity LogIn(IEntity entity);
        int SaveEntrance(IEntity entity);
        double GetWeightOfBox(IEntity entity,object uslov);
        void OpenConnection();
        void CloseConnection();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
