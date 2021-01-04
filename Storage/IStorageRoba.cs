using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IStorageRoba
    {
        void Add(Roba r);
        void Delete(Roba r);
        List<Roba> GetAllRoba();
        void Update(Roba r);
        bool Find(Roba r);
        double GetWeightOfBox(int robaId);
    }
}
