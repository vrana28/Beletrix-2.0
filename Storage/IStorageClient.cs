using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IStorageClient
    {
        List<Client> GetAll();
        void Add(Client c);
        void Delete(Client c);
        void Update(Client c);
        bool Find(Client c);
    }
}
