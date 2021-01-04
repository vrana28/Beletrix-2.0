using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IStoragePosition
    {
        List<Position> GetAllPositions();
        List<Position> Find(string v);
        void UpdatePosition(string positionId);
        DataTable FindBusyPosition(Client client, Roba roba);
        DataTable FindBusyPositionWithPosition(Client client, Roba roba, string v);
    }
}
